using System.Collections.Generic;

namespace PriceSnoop.Services
{
    interface IProductSearch
    {
        IEnumerable<string> Search(string keyword);
    }
}
