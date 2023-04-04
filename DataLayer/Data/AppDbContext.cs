using Bogus;
using DataLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class AppDbContext : IdentityDbContext
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
            base.OnModelCreating(modelBuilder);
            DataSeeding dataSeeder = new DataSeeding();

            modelBuilder.Entity<Product>().HasData(dataSeeder.Products);
            modelBuilder.Entity<ProductImage>().HasData(dataSeeder.ProductImages);
            modelBuilder.Entity<Contact>().HasData(dataSeeder.Contacts);
            modelBuilder.Entity<Category>().HasData(dataSeeder.Categories);
            modelBuilder.Entity<Country>().HasData(dataSeeder.Countries);
            modelBuilder.Entity<Basket>().HasData(dataSeeder.Baskets);
            modelBuilder.Entity<BasketItem>().HasData(dataSeeder.BasketItems);
            modelBuilder.Entity<Brand>().HasData(dataSeeder.Brands);
        }
        DbSet<Category> Categories { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<ProductImage> Images { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<User> Users { get; set; }
    }
}
