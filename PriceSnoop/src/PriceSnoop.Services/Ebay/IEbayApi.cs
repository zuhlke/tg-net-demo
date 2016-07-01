using System.Collections.Generic;

namespace PriceSnoop.Services.Ebay
{
    public interface IEbayApi
    {
        string CallApi(Dictionary<string, string> parameters);
    }
}
