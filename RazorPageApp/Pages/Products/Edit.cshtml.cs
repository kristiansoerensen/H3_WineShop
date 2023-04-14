using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RazorPageApp.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IDataContext _context;
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Product Product { get; set; } = default!;
        public List<SelectListItem> Categories { get; set; } = default!;
        public List<SelectListItem> Brands { get; set; } = default!;
        public List<SelectListItem> Images { get; set; } = default!;
        [BindProperty]
        public int[] ImageIds { get; set; } = default!;

        public EditModel(IDataContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
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
            this.Categories = _context.Categories.GetAll().Select(p => new SelectListItem { Value=p.Id.ToString(), Text=p.Name}).ToList();
            this.Brands = _context.Brands.GetAll().Select(p => new SelectListItem { Value=p.Id.ToString(), Text=p.Name}).ToList();
            this.ImageIds = _context.ProductImages.GetAll().Where(pi => pi.ProductId == product.Id).Select(pi => pi.Id).ToArray();
            this.Images = _context.ProductImages.GetAll().Select(i => new SelectListItem { Value=i.Id.ToString(), Text=i.Id.ToString() }).ToList();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            this._logger.LogInformation(_context.Products.DumpJson(this.Product));
            int[] imageIds = _context.ProductImages.GetAll().Where(pi => pi.ProductId == this.Product.Id).Select(pi => pi.Id).ToArray();
            IEnumerable<int> removeImages = imageIds.Where(val => !this.ImageIds.Contains(val));
            this.Product.Images = _context.ProductImages.GetAll().Where(i => this.ImageIds.Contains(i.Id)).ToList();
            _context.Products.Update(this.Product);
            _context.ProductImages.DeleteRange(_context.ProductImages.GetAll().Where(pi => removeImages.Contains(pi.Id)));

            try
            {
                await _context.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(this.Product.Id))
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

        private bool MovieExists(int id)
        {
            return (_context.Products.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
