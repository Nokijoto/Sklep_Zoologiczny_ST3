using SklepZoologiczny.Warehouse.Storage.Entities;

namespace Test.Warehouse
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "TestProduct",
                    Description = "TestDescription",
                    Price = 100,
                }
            };
            Assert.Equal(1, products.Count);
        }

        [Fact]
        public void Test2()
        {
            List<Product> products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "TestProduct",
                    Description = "TestDescription",
                    Price = 100,
                }
            };
            Assert.Equal(1, products.Count);
        }
    }
}