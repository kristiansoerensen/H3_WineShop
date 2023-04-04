using Bogus;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class DataSeeding
    {
        public List<Product> Products { get; set; }
        public List<Basket> Baskets { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Country> Countries { get; set; }
        public List<ProductImage> ProductImages { get; set; }


        public DataSeeding()
        {
            int seed = 1;

            this.Countries = new Faker<Country>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Address.Country())
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(10);

            this.Contacts = new Faker<Contact>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.CountryId, f => f.PickRandom(this.Countries).Id)
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.City, f => f.Address.City())
                .RuleFor(p => p.StreetName, f => f.Address.StreetAddress())
                .RuleFor(p => p.ZipCode, f => f.Address.ZipCode())
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Mobile, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(10);
            
            this.Brands = new Faker<Brand>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Vehicle.Manufacturer())
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(10);
            
            this.Categories = new Faker<Category>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Commerce.Categories(1).First())
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(10);

            this.Products = new Faker<Product>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => f.Commerce.Price(1).First())
                .RuleFor(p => p.SKU, f => f.Commerce.Ean8())
                .RuleFor(p => p.CategoryId, f => f.PickRandom(this.Categories).Id)
                .RuleFor(p => p.BrandId, f => f.PickRandom(this.Brands).Id)
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(100);

            this.ProductImages = new Faker<ProductImage>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.ProductId, f => f.PickRandom(this.Products).Id)
                .RuleFor(p => p.Href, f => "https://solkaersvin.dk")
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(150);
            
            this.Baskets = new Faker<Basket>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.ContactId, f => f.PickRandom(this.Contacts).Id)
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(150);
            
            this.BasketItems = new Faker<BasketItem>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.ProductId, f => f.PickRandom(this.Products).Id)
                .RuleFor(p => p.BasketId, f => f.PickRandom(this.Baskets).Id)
                .RuleFor(p => p.QTY, f => (decimal)RandomNumberBetween(1, 30))
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(500);
        }

        private static readonly Random random = new Random();

        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }
    }
}
