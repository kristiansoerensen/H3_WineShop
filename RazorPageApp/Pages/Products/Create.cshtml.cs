using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageApp.Pages.Products
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
        //ViewData["CategoryId"] = new SelectList((System.Collections.IEnumerable)_context.Products, "Id", "Genre");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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
