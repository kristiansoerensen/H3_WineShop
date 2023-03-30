using ConsoleApp;
using DataLayer;
using DataLayer.Core.Utils;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContextFactory appContextFactory = new AppContextFactory();

            using (AppDbContext db = appContextFactory.CreateDbContext(args))
            {
                IUnitOfWork unitOfWork = new UnitOfWork(db);
                Product product = new Product
                {
                    Name = "Test1",
                    Price = 12.4M
                };
                unitOfWork.Products.Add(product).Wait();
                unitOfWork.CommitAsync().Wait();
                IEnumerable<Product?>? products = unitOfWork.Products.GetAll().ToList();

                Console.WriteLine($"Counted Products: {products.Count()}");
            }
        }
    }
}
