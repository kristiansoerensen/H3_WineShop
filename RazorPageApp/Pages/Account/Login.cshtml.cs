using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPageApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IDataContext _context;
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public User User { get; set; } = default!;

        public LoginModel(ILogger<IndexModel> logger, IDataContext context)
        {
            _logger = logger;
            this._context = context;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context.Users.GetAll().FirstOrDefaultAsync(u => u.Username == User.Username && u.Password == User.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            HttpContext.Session.SetString("UserId", user.Id.ToString());

            return RedirectToPage("/Index");
        }
    }
}
