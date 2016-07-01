using Moq;
using PriceSnoop.Services.Ebay;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace PriceSnoop.Tests.Services
{
    public class ProductSearchTests
    {
        private string ApiKey = "test key";

        [Fact]
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

        private bool AssertCorrectParameters(Dictionary<string, string> expected, Dictionary<string, string> paramsToCheck)
        {
            return paramsToCheck.Count == expected.Count && paramsToCheck.All(p => expected.Contains(p));
        }
    }
}
