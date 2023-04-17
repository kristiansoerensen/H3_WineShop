using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace xUnitTest
{
    public class RepositoryTest
    {
        [Fact]
        public void write()
        {
            AppTestContextFactory appTestContextFactory = new AppTestContextFactory();

            using (AppDbContext dbContext = appTestContextFactory.CreateDbContext())
            {
                var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();
                var factory = serviceProvider.GetService<ILoggerFactory>();
                DataContext unitOfWork = new DataContext(dbContext, factory);
                unitOfWork.Products.Add(new Product { Name = "Test1" });
                unitOfWork.CommitAsync().Wait();
                Assert.Single(unitOfWork.Products.GetAll().ToList());
            }
        }
        
        [Fact]
        public void write_read()
        {
            AppTestContextFactory appTestContextFactory = new AppTestContextFactory();

            using (AppDbContext dbContext = appTestContextFactory.CreateDbContext())
            {
                var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();
                var factory = serviceProvider.GetService<ILoggerFactory>();
                DataContext unitOfWork = new DataContext(dbContext, factory);
                unitOfWork.Products.Add(new Product { Name = "Write & Read" });
                unitOfWork.CommitAsync().Wait();
                Assert.Equal("Write & Read", unitOfWork.Products.GetAll().FirstOrDefault().Name);
            }
        }

        [Fact]
        public void write_delete()
        {
            AppTestContextFactory appTestContextFactory = new AppTestContextFactory();

            using (AppDbContext dbContext = appTestContextFactory.CreateDbContext())
            {
                var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();
                var factory = serviceProvider.GetService<ILoggerFactory>();
                DataContext unitOfWork = new DataContext(dbContext, factory);
                Product product = (new Product { Name = "Write & Delete" });
                unitOfWork.Products.Add(product);
                unitOfWork.CommitAsync().Wait();
                unitOfWork.Products.Delete(product);
                unitOfWork.CommitAsync().Wait();
                Assert.Empty(unitOfWork.Products.GetAll().ToList());
            }
        }
    }
}