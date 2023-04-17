﻿using DataLayer.Data;
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

        public IndexModel(IDataContext context, ILogger<IndexModel> logger, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task OnGetAsync()
        {
            this.Categories = await this._context.Categories.GetAll().Take(6).ToListAsync();
            this.Products = await this._context.Products.GetAll().Include(p => p.Images).Take(8).ToListAsync();
        }
    }
}