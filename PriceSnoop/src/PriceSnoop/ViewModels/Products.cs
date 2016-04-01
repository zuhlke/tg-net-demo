using System.Collections.Generic;

namespace PriceSnoop.ViewModels
{
    public class Products
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product("Product 1"),
                new Product("Product 2"),
                new Product("Product 3"),
                new Product("Product 4"),
                new Product("Product 5s")
            };
        }
    }
}