using Products.Controllers;
using Products.DataAccess;
using Products.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Products.Tests
{
    public class ProductsControllerTests
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

    }
}