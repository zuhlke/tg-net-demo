using EbayClientHack.DTO.KeywordSearch;
using System.Collections.Generic;

namespace PriceSnoop.Services
{
    public interface IProductSearch
    {
        IEnumerable<Product> Search(string keyword);
    }
}
