using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageApp.Areas.Manage.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly IDataContext _context;

        public DeleteModel(IDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            Category? category = await _context.Categories.GetById(id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                this.Category = category;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }
            Category? category = await _context.Categories.GetById(id);

            if (category != null)
            {
                this.Category = category;
                _context.Categories.Delete(category);
                await _context.CommitAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
