using DataLayer.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Core.Utils
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IProductImageRepository ProductImages { get; }
        ICountryRepository Countries { get; }
        IContactRepository Contacts { get; }
        ICategoryRepository Category { get; }
        IBasketItemRepository BasketItems { get; }
        IBasketRepository Baskets { get; }
        Task CommitAsync();
    }
}
