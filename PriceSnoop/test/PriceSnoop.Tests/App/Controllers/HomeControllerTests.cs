using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriceSnoop;
using PriceSnoop.Controllers;
using Microsoft.AspNetCore.Mvc;
using PriceSnoop.Shared.Models;
using System.Net;
using NUnit.Framework;

namespace PriceSnoop.Tests.App.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexViewModel_ShouldBeProductList()
        {
            var target = new HomeController(null);
            var res = target.Index() as ViewResult;
            Assert.AreEqual(typeof(List<Product>), res.Model.GetType());
        }
    }
}
