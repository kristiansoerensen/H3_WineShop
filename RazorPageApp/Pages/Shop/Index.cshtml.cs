using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.ExtensionMethods;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System;
using System.Linq;

namespace RazorPageApp.Pages.Shop
{
    public class IndexModel : PageModel
    {
        
        private readonly IDataContext _context;
        private readonly ILogger<IndexModel> _logger;
        public IList<Product> Products { get; set; } = default!;
        public List<SelectListItem> Categories { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public int[] CategoryIds { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string OrderBy { get; set; } = default!;
        public List<SelectListItem> OrderByList { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 9;
        [BindProperty(SupportsGet = true)]
        public int Pages { get; set; } = default!;


        public IndexModel(IDataContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task OnGetAsync(string? SearchTerm, int[] CategoryIds, int CurrentPage = 1, int PageSize = 9, string OrderBy = "1")
        {
            this.OrderByList = new List<SelectListItem>
            {
                new SelectListItem { Text = "None", Value = "1", Selected=true},
                new SelectListItem { Text = "Name ASC", Value = "2"},
                new SelectListItem { Text = "Name DESC", Value = "3"},
                new SelectListItem { Text = "Price ASC", Value = "4"},
                new SelectListItem { Text = "Price DESC", Value = "5"},
            };

            var query = _context.Products.GetAll();
            if (SearchTerm != null)
            {
                query = query.Where(p => p.Name.Contains(SearchTerm));
            }
            if (CategoryIds != null && CategoryIds.Count() > 0)
            {
                //List<ProductCategory> productCategories = await _context.ProductCategories.GetAll().Where(pc => CategoryIds.Contains(pc.CategoryId)).ToListAsync();
                query = query.Where(p => p.ProductCategories.Any(pc => CategoryIds.Contains(pc.CategoryId)));
            }
            switch (OrderBy)
            {
                case "1":
                    break;
                case "2":
                    query = query.OrderBy(p => p.Name);
                    break;
                case "3":
                    query = query.OrderByDescending(p => p.Name);
                    break;
                case "4":
                    query = query.OrderBy(p => p.Price);
                    break;
                case "5":
                    query = query.OrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }

            //this.Products = await querey.Page(CurrentPage, PageSize).Include(p => p.Category).Include(p => p.Brand).Include(p => p.Images).ToListAsync();
            this.Products = await query.Page(CurrentPage, PageSize).Include(p => p.Brand).Include(p => p.Images).Include(p => p.ProductCategories).ToListAsync();
            this.Pages = ((query.Count() - 1) / PageSize) + 1;
            this.Categories = await _context.Categories.GetAll().Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name, Selected = CategoryIds.Contains(i.Id) ? true : false }).ToListAsync();
        }
    }
}
