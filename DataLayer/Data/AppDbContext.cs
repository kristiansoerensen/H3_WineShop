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
            modelBuilder.Entity<Category>().HasData(dataSeeder.Categories);
            modelBuilder.Entity<Country>().HasData(dataSeeder.Countries);
            modelBuilder.Entity<Basket>().HasData(dataSeeder.Baskets);
            modelBuilder.Entity<BasketItem>().HasData(dataSeeder.BasketItems);
            modelBuilder.Entity<Brand>().HasData(dataSeeder.Brands);
            modelBuilder.Entity<ProductCategory>().HasData(dataSeeder.ProductCategories);

            modelBuilder.Entity<ProductCategory>()
                .HasKey(bc => new { bc.ProductId, bc.CategoryId });
            modelBuilder.Entity<ProductCategory>()
                .HasOne(bc => bc.Product)
                .WithMany(b => b.ProductCategories)
                .HasForeignKey(bc => bc.ProductId);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(bc => bc.CategoryId);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ProductImage> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
