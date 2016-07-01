using PriceSnoop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PriceSnoop.Tests.Shared.Models
{
    [TestFixture]
    public class ProductsTests
    {
        [Test]
        public void GetProducts_ShouldReturnTenItems()
        {
            Assert.AreEqual(10, Products.GetProducts().Count);
        }
    }
}
