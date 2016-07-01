
using NUnit.Framework;
using PriceSnoop.Services.Ebay;
using System;
using System.Linq;

namespace PriceSnoop.IntegrationTests.Services.Ebay
{
    [TestFixture]
    public class EbayApiIntegrationTests
    {
        private EbayProductSearch target;

        [SetUp]
        public void Setup()
        {
            string ebayApiKey = Environment.GetEnvironmentVariable("EbaySettings:AppId");
            Console.WriteLine($"ApiKey= {ebayApiKey}");
            target = new EbayProductSearch(new EbayApi(), ebayApiKey);
        }

        [Test]
        public void ShouldReturnProductsForValidKeyword()
        {
            Assert.IsTrue(target.Search("Harry Potter").Count() > 0);
        }
    }
}
