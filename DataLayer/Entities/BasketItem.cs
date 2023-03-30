using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class BasketItem : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        public Basket ShoppingCart { get; set; } = null!;
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        [Precision(10,2)]
        public decimal QTY { get; set; } // Quantity of products

    }
}
