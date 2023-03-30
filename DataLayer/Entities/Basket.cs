using System;
using System.Collections.Generic;
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
        public int ContactId { get; set; }
        public Contact Contact { get; set; } = null!;
        public List<BasketItem>? CartLines { get; set; }
    }
}
