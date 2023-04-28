
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorWebassembly.DTOs
{
    public class BasketItemDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int QTY { get; set; } // Quantity of products
        public decimal? Total { get; set; }

        public ProductDTO? Product { get; set; }

    }
}
