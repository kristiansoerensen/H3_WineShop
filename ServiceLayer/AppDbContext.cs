using Bogus;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        //        .EnableSensitiveDataLogging(true)
        //        .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WineStore;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //int product_ids = 1;
            //var Products = new Faker<Product>()
            //    .RuleFor(p => p.Id, f => product_ids++)
            //    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            //    .RuleFor(p => p.Price, f => f.Commerce.Price(1).First())
            //    .RuleFor(p => p.SKU, f => f.Commerce.Ean8())
            //    .RuleFor(p => p.CreateDate, f => DateTime.Now)
            //    .RuleFor(p => p.ModifiedDate, f => DateTime.Now);

            //modelBuilder
            //.Entity<Product>()
            //.HasData(Products.GenerateBetween(10, 20));
        }
        DbSet<Category> Categories { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<ProductImage> Images { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<Brand> Brands { get; set; }
    }
}
