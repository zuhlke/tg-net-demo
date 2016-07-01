using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace PriceSnoop.Services.Ebay
{
    public class EbayApi : IEbayApi
    {
        private const string BaseUrl = "http://open.api.sandbox.ebay.com/shopping";

        public string CallApi(Dictionary<string, string> parameters)
        {
            using (var client = new HttpClient())
            {
                return client.GetStringAsync($"{BaseUrl}?{BuildQueryParams(parameters)}").Result;
            }
        }

        private static string BuildQueryParams(Dictionary<string, string> parameters)
        {
            var encodedParams = parameters.Select(p => $"{WebUtility.UrlEncode(p.Key)}={WebUtility.UrlEncode(p.Value)}");
            return string.Join("&", encodedParams);
        }
    }
}
