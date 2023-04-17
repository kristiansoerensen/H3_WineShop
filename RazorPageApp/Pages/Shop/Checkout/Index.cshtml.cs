using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageApp.Pages.Shop.Cart;

namespace RazorPageApp.Pages.Shop.Checkout
{
    public class IndexModel : PageModel
    {
        private readonly IDataContext _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public List<BasketItem> BasketItems { get; set; } = default!;
        public Basket basket { get; set; } = default!;
        public List<SelectListItem> Countries { get; set; } = default!;
        public List<SelectListItem> PaymentProviders { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public Address BillingAddress { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public Address ShippingAddress { get; set; } = default!;

        public const string SessionKeyBasket = "_BasketId";
        

        public IndexModel(IDataContext context, ILogger<IndexModel> logger, UserManager<User> userManager, SignInManager<User> signInManager)
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
            User? user = await _userManager.GetUserAsync(User);
            if (user != null && basket.UserId != null)
            {
                basket.UserId = user.Id;
                await this._context.CommitAsync();
            }
            this.basket = basket;
            this.BasketItems = await this._context.Baskets.GetBasketItems(basket).Include(bi => bi.Product).ToListAsync();
            this.Countries = _context.Countries.GetAll().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            this.PaymentProviders = _context.PaymentProviders.GetAll().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            this.BillingAddress = basket.BillingAddress != null ? basket.BillingAddress : new Address();
            this.ShippingAddress = basket.ShippingAddress != null ? basket.ShippingAddress : new Address();
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            Basket? basket = await GetBasket();
            if (basket == null)
            {
                return RedirectToPage("./Index");
            }
            User? user = await _userManager.GetUserAsync(User);
            if (user != null && basket.UserId != null)
            {
                basket.UserId = user.Id;
                await this._context.CommitAsync();
            }
            this.basket = basket;
            basket.BillingAddress = this.BillingAddress;
            basket.ShippingAddress = this.ShippingAddress;
            basket.state = "done";
            this._context.Baskets.Update(basket);
            await this._context.CommitAsync();
            HttpContext.Session.Remove(SessionKeyBasket);
            return RedirectToPage("/Index");
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
                    basket = this._context.Baskets.GetAll().Where(b => b.Id == basketId).Include(b => b.BillingAddress).Include(b => b.ShippingAddress).FirstOrDefault();
                    if (user != null && basket != null)
                    {
                        basket.User = user;
                    }
                    await this._context.CommitAsync();
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
