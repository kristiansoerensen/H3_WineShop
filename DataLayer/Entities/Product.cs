﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [MaxLength(50, ErrorMessage = "Name can max be lenght of 50")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Precision(10, 4)]
        public decimal? Price { get; set; }
        public string? SKU { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [DefaultValue(true)]
        public bool active { get; set; } = true;
        public int? BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public Brand? Brand { get; set; }
        public ICollection<ProductImage>? Images { get; set; }

    }
}
