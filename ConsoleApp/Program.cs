using ConsoleApp;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.Extensions.Logging;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContextFactory appContextFactory = new AppContextFactory();

            using (AppDbContext db = appContextFactory.CreateDbContext(args))
            {
                var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
                DataContext unitOfWork = new DataContext(db, loggerFactory);
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
