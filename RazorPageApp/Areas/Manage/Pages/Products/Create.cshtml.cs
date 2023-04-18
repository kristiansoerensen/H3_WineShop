using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageApp.Areas.Manage.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IDataContext _context;

        public CreateModel(IDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Categories == null || Product == null)
            {
                return Page();
            }

            await _context.Products.Add(Product);
            await _context.CommitAsync();

            return RedirectToPage("./Index");
        }
    }
}
