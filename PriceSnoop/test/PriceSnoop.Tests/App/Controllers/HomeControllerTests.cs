using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using PriceSnoop;
using PriceSnoop.Controllers;
using Microsoft.AspNetCore.Mvc;
using PriceSnoop.Shared.Models;
using System.Net;

namespace PriceSnoop.Tests.App.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexViewModel_ShouldBeProductList()
        {
            var target = new HomeController(null);
            var res = target.Index() as ViewResult;
            Assert.Equal(typeof(List<Product>), res.Model.GetType());
        }
    }
}
