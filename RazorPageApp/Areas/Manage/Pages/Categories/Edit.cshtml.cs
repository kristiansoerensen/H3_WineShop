using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorPageApp.Areas.Manage.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly IDataContext _context;
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Category Category { get; set; } = default!;

        public EditModel(IDataContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }
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
            this.Category = category;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this._context.Categories.Update(this.Category);

            try
            {
                await _context.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(this.Category.Id))
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

        private bool CategoryExists(int id)
        {
            return (_context.Categories.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
