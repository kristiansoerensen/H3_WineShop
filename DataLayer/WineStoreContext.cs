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

namespace DataLayer
{
    public class WineStoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WineStore;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        DbSet<Category> Categories { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<ProductImage> Images { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        
    }
}
