using System;

namespace PriceSnoop.ViewModels
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