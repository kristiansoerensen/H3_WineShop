using DataLayer.Core.Repositories;
using DataLayer.Core.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class DataContext : IDataContext, IDisposable
    {
        private readonly AppDbContext _context;
        //private readonly ILogger _logger;

        public IProductRepository Products { get; private set; }

        public IProductImageRepository ProductImages { get; private set; }

        public ICountryRepository Countries { get; private set; }

        public IContactRepository Contacts { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IBasketItemRepository BasketItems { get; private set; }

        public IBasketRepository Baskets { get; private set; }
        public IBrandRepository Brands { get; private set; }
        public IUserRepository Users { get; private set; }
        public IProductCategoryRepository ProductCategories { get; private set; }

    public DataContext(
            AppDbContext context/*, ILogger logger*/)
        {
            _context = context;
            //_logger = logger;

            this.Products = new ProductRepository(context);
            this.ProductImages = new ProductImageRepository(context);
            this.Countries = new CountryRepository(context);
            this.Contacts = new ContactRepository(context);
            this.Categories = new CategoryRepository(context);
            this.BasketItems = new BasketItemRepository(context);
            this.Baskets = new BasketRepository(context);
            this.Brands = new BrandRepository(context);
            this.Users = new UserRepository(context);
            this.ProductCategories = new ProductCategoryRepository(context);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
