using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; } = null!;
        public string? StreetName { get; set; }
        public string? city { get; set; }
        public string? ZipCode { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }

    }
}
