using Moq;
using PriceSnoop.Services.Ebay;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Resources;
using System.Text;

namespace PriceSnoop.Tests.Services
{
    [TestFixture]
    public class ProductSearchTests
    {
        private string ApiKey = "test key";

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
            //var assm = this.GetType().GetTypeInfo().Assembly;
            //var resourceStream = assm.GetManifestResourceStream("PriceSnoop.Tests.Services.ProductSearchResults.json");
            //string exampleResponse;
            ////using (var reader = new StreamReader(resourceStream, Encoding.UTF8))
            ////{
            ////    exampleResponse = reader.ReadToEnd();
            ////}

            var apiMock = new Mock<IEbayApi>();
            apiMock
                .Setup(m => m.CallApi(It.IsAny<Dictionary<string, string>>()))
                .Returns(File.ReadAllText("Services/ProductSearchResults.json"));

            var target = new EbayProductSearch(apiMock.Object, ApiKey);

            Assert.AreEqual(20, target.Search("Any old keyword").Count());
        }

        private bool AssertCorrectParameters(Dictionary<string, string> expected, Dictionary<string, string> paramsToCheck)
        {
            return paramsToCheck.Count == expected.Count && paramsToCheck.All(p => expected.Contains(p));
        }
    }
}
