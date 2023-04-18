using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageApp.Areas.Manage.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public IndexModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPost(string Name)
        {
            try
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    if (!(await _roleManager.RoleExistsAsync(Name)))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(Name));
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToPage();
            }
            catch
            {
                return RedirectToPage();
            }
        }
    }
}
