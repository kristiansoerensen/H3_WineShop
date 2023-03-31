﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
