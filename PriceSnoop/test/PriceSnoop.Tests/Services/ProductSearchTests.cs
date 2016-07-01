using Moq;
using PriceSnoop.Services.Ebay;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using System.IO;

namespace PriceSnoop.Tests.Services
{

    [TestFixture]
    public class ProductSearchTests
    {
        private string ApiKey = "test key";

        private static string assemblyDirectory = Path.GetDirectoryName(typeof(ProductSearchTests).GetTypeInfo().Assembly.Location);

        [Test]
        public void CorrectQueryParameters_ShouldBeSentToApi()
        {
            var apiMock = new Mock<IEbayApi>();
            var target = new EbayProductSearch(apiMock.Object, ApiKey);

            string keywords = "TestKeyword";
            target.Search(keywords);

            var queryParams = new Dictionary<string, string>
            {
                {"QueryKeywords" , keywords },
                {"appid", ApiKey },
                {"callname", "FindProducts" },
                {"responseencoding", "JSON" },
                {"AvailableItemsOnly", "true" },
                {"HideDuplicateItems", "true" },
                {"MaxEntries", "20" },
                {"PageNumber", "1" },
                {"ProductSort", "Popularity" },
                {"version", "957" }
            };

            apiMock
                .Verify(m => m.CallApi(It.Is<Dictionary<string, string>>(d => AssertCorrectParameters(queryParams, d))));
        }

        [Test]
        public void CorrectNumberOfItemsShouldBeReturned()
        {
            var apiMock = new Mock<IEbayApi>();
            apiMock
                .Setup(m => m.CallApi(It.IsAny<Dictionary<string, string>>()))
                .Returns(Products());

            var target = new EbayProductSearch(apiMock.Object, ApiKey);

            Assert.AreEqual(20, target.Search("Any old keyword").Count());
        }


        [Test]
        public void ShouldReturnProductTitlesFromApiResponse()
        {
            var apiMock = new Mock<IEbayApi>();
            apiMock
                .Setup(m => m.CallApi(It.IsAny<Dictionary<string, string>>()))
                .Returns(Products());

            var target = new EbayProductSearch(apiMock.Object, ApiKey);

            var productTitles = target.Search("keyword").Select(p => p.Title);
            CollectionAssert.IsSubsetOf(new[] { "Harry Potter: Complete 8-Film Collection (DVD, 2011, 8-Disc Set)", "Harry Potter: Harry Potter Years 1-7 by J. K. Rowling (2007, Hardcover)" }, productTitles);
        }

        private static string Products()
        {
            return File.ReadAllText($"{assemblyDirectory}/Services/ProductSearchResults.json");
        }

        private bool AssertCorrectParameters(Dictionary<string, string> expected, Dictionary<string, string> paramsToCheck)
        {
            return paramsToCheck.Count == expected.Count && paramsToCheck.All(p => expected.Contains(p));
        }
    }
}
