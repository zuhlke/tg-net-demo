using EbayClientHack.DTO.KeywordSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceSnoop.Services.Ebay
{
    public class EbayProductSearch : IProductSearch
    {
        private string apiKey;
        private IEbayApi _api;

        public EbayProductSearch(IEbayApi api)
        {
            _api = api;
        }

        public EbayProductSearch(IEbayApi api, string apiKey) : this(api)
        {
            this.apiKey = apiKey;
        }

        public IEnumerable<Product> Search(string keyword)
        {
            var jsonResponse = _api.CallApi(new Dictionary<string, string>
            {
                {"QueryKeywords", keyword },
                {"appid", this.apiKey },
                {"callname", "FindProducts" },
                {"responseencoding", "JSON" },
                {"AvailableItemsOnly", "true" },
                {"HideDuplicateItems", "true" },
                {"MaxEntries", "20" },
                {"PageNumber", "1" },
                {"ProductSort", "Popularity" },
                {"version", "957" }
            });

            if (string.IsNullOrEmpty(jsonResponse)) return new Product[0];

            var result = JsonConvert.DeserializeObject<KeywordSearchResult>(jsonResponse);

            return result.Products;
        }
    }
}
