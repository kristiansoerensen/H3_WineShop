using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace RazorPageApp.Pages.Shop
{
    public class CartModel : PageModel
    {
        private readonly IDataContext _context;
        private readonly ILogger<CartModel> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public const string SessionKeyCart = "_BasketId";

        public CartModel(IDataContext context, ILogger<CartModel> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async void OnGetAsync()
        {
            string? username = HttpContext.User.Identity?.Name;
            if (username != null)
            {
                User? user = await _userManager.FindByNameAsync(username);
                _logger.LogInformation($"Logged in userid########:{user?.Id}");
            }
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyCart)))
            {
                HttpContext.Session.SetInt32(SessionKeyCart, 73);
                this._logger.LogInformation("Set session key ############");
            }
            this._logger.LogInformation($"Get session key ############:{HttpContext.Session.GetInt32(SessionKeyCart).ToString()}");
            
        }
    }
}
