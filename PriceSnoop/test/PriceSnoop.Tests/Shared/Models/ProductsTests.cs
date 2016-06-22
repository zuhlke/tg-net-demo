using PriceSnoop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PriceSnoop.Tests.Shared.Models
{
    public class ProductsTests
    {
        [Fact]
        public void GetProducts_ShouldReturnTenItems()
        {
            Assert.Equal(10, Products.GetProducts().Count);
        }
    }
}
