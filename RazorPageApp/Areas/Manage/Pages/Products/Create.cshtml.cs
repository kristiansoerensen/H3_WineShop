using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace RazorPageApp.Areas.Manage.Pages.Products
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private IHostingEnvironment _environment;
        private readonly IDataContext _context;
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public int[] CategoryIds { get; set; } = default!;
        public List<SelectListItem> Categories { get; set; } = default!;
        public List<SelectListItem> Brands { get; set; } = default!;
        public List<SelectListItem> Images { get; set; } = default!;
        [BindProperty]
        public int[] ImageIds { get; set; } = default!;
        [BindProperty]
        public List<IFormFile> Uploads { get; set; } = default!;
        public CreateModel(IDataContext context, ILogger<IndexModel> logger, IHostingEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
            this.Categories = _context.Categories.GetAll().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList();
            this.Brands = _context.Brands.GetAll().Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Name }).ToList();
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(List<IFormFile> Uploads)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            this._logger.LogInformation(_context.Products.DumpJson(this.Product));

            await _context.Products.Add(this.Product);
            try
            {
                await _context.CommitAsync();
            }
            catch (Exception ex)
            {

            }
            await SaveImages(Uploads);

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
    }
}
