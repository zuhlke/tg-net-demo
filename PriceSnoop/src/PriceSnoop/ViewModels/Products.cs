using System.Collections.Generic;
using System.Linq;

namespace PriceSnoop.ViewModels
{
    public class Products
    {
        public static IEnumerable<Product> GetProducts() => Enumerable.Range(1, 10).Select(a => new Product($"Product {a}"));
    }
}