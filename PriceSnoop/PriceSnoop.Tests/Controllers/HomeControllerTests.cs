using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using PriceSnoop;
using PriceSnoop.Controllers;
using Microsoft.AspNetCore.Mvc;
using PriceSnoop.Models;
using System.Net;

namespace PriceSnoop.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexViewModel_ShouldBeProductList()
        {
            var target = new HomeController();
            var res = target.Index() as ViewResult;
            Assert.Equal(typeof(List<Product>), res.Model.GetType());
        }
    }
}
