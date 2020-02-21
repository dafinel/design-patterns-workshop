using System;
using Specification.Specifications;

namespace Specification
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product
            {
                Category = "IT",
                Price = 16
            };


            if(product.Price >= 10 && product.Price <= 20 
                && (product.Category == "Electronics" || product.Category == "IT")
                && product.Price != 15)
            {
                Console.WriteLine("Product matches condictions");
            }
        }
    }
}
