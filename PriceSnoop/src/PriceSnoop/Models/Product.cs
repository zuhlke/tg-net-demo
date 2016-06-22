using System;

namespace PriceSnoop.Models
{
    public class Product
    {
        public Product(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}