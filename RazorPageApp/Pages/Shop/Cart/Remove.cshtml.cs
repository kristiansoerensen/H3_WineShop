using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageApp.Pages.Shop.Cart
{
    public class RemoveModel : PageModel
    {
        private readonly IDataContext _context;
        private readonly ILogger<RemoveModel> _logger;
        private readonly UserManager<User> _userManager;

        public const string SessionKeyBasket = "_BasketId";

        public RemoveModel(IDataContext context, ILogger<RemoveModel> logger, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }
        public IActionResult OnGetAsync()
        {
            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostAsync(int basketItemId)
        {
            BasketItem? basketItem = await this._context.BasketItems.GetById(basketItemId);
            if (basketItem == null)
            {
                return RedirectToPage("./Index");
            }
            this._context.BasketItems.Delete(basketItem);
            await this._context.CommitAsync();
            return RedirectToPage("./Index");
        }

        public async Task<Basket?> GetBasket()
        {
            User? user = await _userManager.GetUserAsync(User);
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
    }
}
