using DataLayer.Core.Utils;
using DataLayer.Data;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
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
    }
}