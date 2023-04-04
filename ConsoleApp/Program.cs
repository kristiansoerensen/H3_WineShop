using ConsoleApp;
using DataLayer.Data;
using DataLayer.Entities;

namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContextFactory appContextFactory = new AppContextFactory();

            using (AppDbContext db = appContextFactory.CreateDbContext(args))
            {
                DataContext unitOfWork = new DataContext(db);
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
