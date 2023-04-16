using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System.Security.Claims;

namespace RazorPageApp.Pages.Shop
{
    public class CartModel : PageModel
    {
        private readonly IDataContext _context;
        private readonly ILogger<CartModel> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public List<BasketItem> BasketItems { get; set; } = default!;

        public const string SessionKeyBasket = "_BasketId";

        public CartModel(IDataContext context, ILogger<CartModel> logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Basket? basket = await GetBasket();
            if (basket == null)
            {
                return Page();
            }
            this.BasketItems = await this._context.Baskets.GetBasketItems(basket).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int qty, int productId)
        {
            Basket? basket = await GetBasket();
            if (basket == null)
            {
                return Page();
            }
            Product? product = await this._context.Products.GetById(productId);
            if (product == null)
            {
                return Page();
            }
            this._context.Baskets.AddToBasket(basket, product, qty);
            await this._context.CommitAsync();

            this.BasketItems = await this._context.Baskets.GetBasketItems(basket).ToListAsync();
            _logger.LogInformation($"#####################basketitems: {BasketItems.Count()}");
            return Page();
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
