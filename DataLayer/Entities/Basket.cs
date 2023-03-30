using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Basket : Entity
    {
        public int ContactId { get; set; }
        public Contact Contact { get; set; } = null!;
        public List<BasketItem>? CartLines { get; set; }
    }
}
