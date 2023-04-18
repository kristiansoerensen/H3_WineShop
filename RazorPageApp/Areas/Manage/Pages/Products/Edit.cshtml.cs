using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.Security.Cryptography;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;
using System.IO.Pipes;
using Bogus.DataSets;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace RazorPageApp.Areas.Manage.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private IHostingEnvironment _environment;
        private readonly IDataContext _context;
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Product Product { get; set; } = default!;
        [BindProperty]
        public int[] CategoryIds { get; set; } = default!;
        public List<SelectListItem> Categories { get; set; } = default!;
        public List<SelectListItem> Brands { get; set; } = default!;
        public List<SelectListItem> Images { get; set; } = default!;
        [BindProperty]
        public int[] ImageIds { get; set; } = default!;
        [BindProperty]
        public List<IFormFile> Uploads { get; set; } = default!;

        public EditModel(IDataContext context, ILogger<IndexModel> logger, IHostingEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _environment = environment;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            Product? product = await _context.Products.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            this.Product = product;
            this.Categories = _context.Categories.GetAll().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList();
            this.Brands = _context.Brands.GetAll().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList();
            List<Image> images = _context.Images.GetAll().Where(pi => pi.ProductId == product.Id).ToList();
            this.ImageIds = images.Select(pi => pi.Id).ToArray();
            this.Images = images.Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Id.ToString() }).ToList();

            List<Category> categories = this._context.ProductCategories.GetAll().Where(pc => pc.ProductId == this.Product.Id).Select(pc => pc.Category).ToList();
            this.CategoryIds = categories.Select(pc => pc.Id).ToArray();

            OpenImages(images);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(List<IFormFile> Uploads)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            this._logger.LogInformation(_context.Products.DumpJson(this.Product));
            int[] imageIds = _context.Images.GetAll().Where(pi => pi.ProductId == this.Product.Id).Select(pi => pi.Id).ToArray();
            IEnumerable<int> removeImages = imageIds.Where(val => !this.ImageIds.Contains(val));
            this.Product.Images = _context.Images.GetAll().Where(i => this.ImageIds.Contains(i.Id)).ToList();
            _context.Images.DeleteRange(_context.Images.GetAll().Where(pi => removeImages.Contains(pi.Id)));

            await SaveImages(Uploads);
            _context.Products.Update(this.Product);

            try
            {
                await _context.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(this.Product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        public void OpenImages(List<Image> images)
        {
            this.Uploads = new List<IFormFile>();
            foreach (var image in images)
            {
                string filename = $"{image.Name}";
                if (Path.Exists(filename))
                {
                    using (var fileStream = new FileStream(filename, FileMode.Open))
                    {
                        this.Uploads.Add(new FormFile(fileStream, 0, fileStream.Length, "streamFile", image.Name.Split(@"\").Last()));
                    }
                }
            }
        }

        public async Task SaveImages(List<IFormFile> images)
        {
            foreach (var image in images)
            {
                var uniqueFileName = string.Format(@"{0}{1}", Guid.NewGuid(), Path.GetExtension(image.FileName));
                _logger.LogInformation($"Saved image: {uniqueFileName}");
                var file = Path.Combine(_environment.WebRootPath, "Images", uniqueFileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                await this._context.Images.Add(new Image { ProductId = this.Product.Id, Filename = file, Name = file });
            }
            await _context.CommitAsync();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public string ConvertToBase64(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyToAsync(ms).Wait();
                byte[] fileBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(fileBytes);
                return base64String;
            }
        }
    }
}
