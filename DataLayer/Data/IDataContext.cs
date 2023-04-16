using DataLayer.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public interface IDataContext
    {
        IProductRepository Products { get; }
        IProductImageRepository ProductImages { get; }
        ICountryRepository Countries { get; }
        ICategoryRepository Categories { get; }
        IBasketItemRepository BasketItems { get; }
        IBasketRepository Baskets { get; }
        IUserRepository Users { get; }
        IBrandRepository Brands { get; }
        IProductCategoryRepository ProductCategories { get; }
        Task CommitAsync();
    }
}
