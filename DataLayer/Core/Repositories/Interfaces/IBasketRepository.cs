using DataLayer.Core.Utils;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Core.Repositories.Interfaces
{
    public interface IBasketRepository : IGenericRepository<Basket>
    {
        void AddToBasket(Basket basket, Product product, decimal qty = 1.0m);
        IQueryable<BasketItem> GetBasketItems(Basket basket);
    }
}
