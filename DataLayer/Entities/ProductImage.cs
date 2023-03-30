﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ProductImage : Entity
    {
        [Required(ErrorMessage = "Href is required!")]
        public string Href { get; set; } = null!;
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
