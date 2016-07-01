using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriceSnoop;
using PriceSnoop.Controllers;
using Microsoft.AspNetCore.Mvc;
using vm = PriceSnoop.Shared.Models;
using System.Net;
using NUnit.Framework;
using Moq;
using PriceSnoop.Services;
using mod = EbayClientHack.DTO.KeywordSearch;

namespace PriceSnoop.Tests.App.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexViewModel_ShouldReturnProductsBasedOnApiResults()
        {
            var titles = new[] { "Title A", "Title B" };
            var apiProds = titles.Select(t => new mod.Product() { Title = t }).ToArray();

            var prodSearch = new Mock<IProductSearch>();
            prodSearch
                .Setup(ps => ps.Search(It.IsAny<string>()))
                .Returns(apiProds);

            var target = new HomeController(prodSearch.Object);

            var res = target.Index() as ViewResult;
            var actualProds = res.Model as List<vm.Product>;

            CollectionAssert.AreEquivalent(titles, actualProds.Select(p => p.Name).ToArray());
        }
    }
}
