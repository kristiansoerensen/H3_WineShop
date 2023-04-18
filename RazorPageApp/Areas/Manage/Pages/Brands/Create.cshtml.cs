using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageApp.Areas.Manage.Pages.Brands
{
    [Authorize(Roles = "Admin")]
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
        public Brand Brand { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Categories == null || Brand == null)
            {
                return Page();
            }

            await _context.Brands.Add(Brand);
            await _context.CommitAsync();

            return RedirectToPage("./Index");
        }
    }
}
