using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageApp.Areas.Manage.Pages.Brands
{
    public class DeleteModel : PageModel
    {
        private readonly IDataContext _context;

        public DeleteModel(IDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Brand Brand { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            Brand? brand = await this._context.Brands.GetById(id);

            if (brand == null)
            {
                return NotFound();
            }
            else
            {
                this.Brand = Brand;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }
            Brand? brand = await _context.Brands.GetById(id);

            if (brand != null)
            {
                _context.Brands.Delete(brand);
                await _context.CommitAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
