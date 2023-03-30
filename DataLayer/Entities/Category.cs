using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool active { get; set; }
    }
}
