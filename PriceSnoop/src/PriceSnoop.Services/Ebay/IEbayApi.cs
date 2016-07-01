using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceSnoop.Services.Ebay
{
    public interface IEbayApi
    {
        string CallApi(Dictionary<string, string> parameters);
    }
}
