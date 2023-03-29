using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Product : Entity
    {
        [Required(ErrorMessage = "Title is required!")]
        [MaxLength(50, ErrorMessage = "Title can max be lenght of 50")]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Precision(10, 4)]
        public decimal Price { get; set; }

        #region Image(s)
        public int? FeaturedImageId { get; set; }
        public Image? FeaturedImageIdmageId { get; set; }

        public ICollection<Image>? Images { get; set; }
        #endregion

    }
}
