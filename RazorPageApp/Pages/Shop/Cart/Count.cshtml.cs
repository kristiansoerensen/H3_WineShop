using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPageApp.Pages.Shop.Cart
{
    public class CountModel : PageModel
    {
        private readonly IDataContext _context;
        private readonly ILogger<CountModel> _logger;
        private readonly UserManager<User> _userManager;

        public const string SessionKeyBasket = "_BasketId";

        public CountModel(IDataContext context, ILogger<CountModel> logger, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<JsonResult> OnGet()
        {
            Basket? basket = await GetBasket();
            if (basket == null)
            {
                return new JsonResult(0);
            }
            return new JsonResult(this._context.Baskets.GetBasketItems(basket).Count());
        }

        public async Task<Basket?> GetBasket()
        {
            User? user = await GetUser();
            Basket? basket = null;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyBasket)))
            {
                int? basketId = HttpContext.Session.GetInt32(SessionKeyBasket);
                if (basketId != null)
                {
                    basket = this._context.Baskets.GetAll().Where(b => b.Id == basketId).FirstOrDefault();
                    this._logger.LogInformation($"Found existing basketId: {basket?.Id}");
                    return basket;
                }
            }

            basket = new Basket { };
            if (user != null)
            {
                basket.User = user;
            }
            await this._context.Baskets.Add(basket);
            await this._context.CommitAsync();

            HttpContext.Session.SetInt32(SessionKeyBasket, basket.Id);
            this._logger.LogInformation($"Created new basketId: {basket?.Id}");
            return basket;
        }
        public async Task<User?> GetUser()
        {
            User? user = null;
            string? username = HttpContext.User.Identity?.Name;
            if (username != null)
            {
                user = await _userManager.FindByNameAsync(username);
            }
            _logger.LogInformation($"UserId: {user?.Id}");
            return user;
        }
    }
}
