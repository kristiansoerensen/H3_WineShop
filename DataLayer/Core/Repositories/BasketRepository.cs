using DataLayer.Core.Repositories.Interfaces;
using DataLayer.Core.Utils;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Core.Repositories
{
    public class BasketRepository : GenericRepositoty<Basket>, IBasketRepository
    {
        public BasketRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {       
        }

        public void AddToBasket(Basket basket, Product product, decimal qty = 1.0m)
        {
            BasketItem? basketItem = this._context.BasketItems.SingleOrDefault(c => c.BasketId == basket.Id && c.ProductId == product.Id);
            _logger.LogInformation($"#####################Adding basket items");
            if (basketItem == null)
            {
                basketItem = new BasketItem
                {
                    Product = product,
                    QTY = qty,
                    Basket = basket
                };
            }
            else
            {
                basketItem.QTY += qty;
            }
            this._context.BasketItems.Update(basketItem);
            this._context.SaveChanges();
        }

        public IQueryable<BasketItem> GetBasketItems(Basket basket) 
        {
            return this._context.BasketItems.Where(bi => bi.Basket == basket);
        }
    }
}
