using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorPageApp.Areas.Manage.Pages.Brands
{
    public class EditModel : PageModel
    {
        private readonly IDataContext _context;
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Brand Brand { get; set; } = default!;

        public EditModel(IDataContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            Brand? brand = await _context.Brands.GetById(id);
            if (brand == null)
            {
                return NotFound();
            }
            this.Brand = brand;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this._context.Brands.Update(this.Brand);

            try
            {
                await _context.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(this.Brand.Id))
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

        private bool BrandExists(int id)
        {
            return (_context.Brands.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
