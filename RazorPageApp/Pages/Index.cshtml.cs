using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageApp.Pages.Shop.Cart;

namespace RazorPageApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDataContext _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<User> _userManager;

        public List<Category> Categories { get; set; }  = default!;
        public List<Product> Products { get; set; }  = default!;
        public List<Product> BuyAgainProducts { get; set; } = default!;

        public IndexModel(IDataContext context, ILogger<IndexModel> logger, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            this.Categories = await this._context.Categories.GetAll().Include(c => c.Image).Take(6).ToListAsync();
            this.Products = await this._context.Products.GetAll().Where(p => p.Featured == true).Include(p => p.Images).Take(8).ToListAsync();
            User? user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                int[]? basketIds = await this._context.Baskets.GetAll().Where(b => b.UserId == user.Id).Select(b => b.Id).ToArrayAsync();
                this.BuyAgainProducts = await this._context.BasketItems.GetAll().Where(bi => basketIds.Contains(bi.BasketId)).Include(bi => bi.Product).ThenInclude(p => p.Images).Select(bi => bi.Product).Distinct().ToListAsync();
            }
        }
    }
}