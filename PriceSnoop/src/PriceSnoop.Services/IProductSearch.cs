using EbayClientHack.DTO.KeywordSearch;
using System.Collections.Generic;

namespace PriceSnoop.Services
{
    interface IProductSearch
    {
        IEnumerable<Product> Search(string keyword);
    }
}
