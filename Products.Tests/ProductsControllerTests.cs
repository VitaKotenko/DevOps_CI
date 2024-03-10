using Products.Controllers;
using Products.DataAccess;
using Products.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using Castle.Components.DictionaryAdapter.Xml;

namespace Products.Tests
{
    public class ProductsControllerTests
    {
        DbContextOptions<ProductsContext> _options;
        ProductsContext productsContext;
        ProductsController productsController;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ProductsContext>().
                           UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            productsContext = new ProductsContext(_options);
            SeedTestData(productsContext);
            productsController = new ProductsController(productsContext);
        }

        [Test]
        public async Task GetValidProduct()
        {
            // Act
            var actionResult = await productsController.GetProduct(2);

            // Assert
            Assert.AreEqual(actionResult.Value.Name, "Toy2");
        }

        [Test]
        public async Task DeleteValidProduct()
        {
            // Act
            var viewResult = await productsController.DeleteProduct(1);

            // Assert
            Assert.IsTrue(productsContext.Products.Find(1) == null);
            
        }



        public static void SeedTestData(ProductsContext productsContext)
        {
            productsContext.Products.AddRange(
                new Product
                {
                    Id = 1,
                    Name = "Toy1", 
                    Price = 15 
                },
                new Product
                {
                    Id = 2,
                    Name = "Toy2",
                    Price = 15
                }
               
            );
            productsContext.SaveChanges();
        }
    }
}