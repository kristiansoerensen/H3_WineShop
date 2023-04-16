using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Basket : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
        public List<BasketItem>? CartLines { get; set; }
    }
}
