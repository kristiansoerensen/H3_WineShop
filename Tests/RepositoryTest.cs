using DataLayer.Core.Utils;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

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
                IUnitOfWork unitOfWork = new UnitOfWork(dbContext);
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
                IUnitOfWork unitOfWork = new UnitOfWork(dbContext);
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
                IUnitOfWork unitOfWork = new UnitOfWork(dbContext);
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