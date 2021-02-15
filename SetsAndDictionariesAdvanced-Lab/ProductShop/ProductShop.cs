using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class ProductShop
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopsProducts = new Dictionary<string, Dictionary<string, double>>();
            string command = Console.ReadLine();

            while (command != "Revision")
            {
                string[] input = command.Split(", ");
                string shop = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (shopsProducts.ContainsKey(shop) == false)
                {
                    shopsProducts.Add(shop, new Dictionary<string, double>());
                    shopsProducts[shop].Add(product, price);
                }
                else
                {
                    shopsProducts[shop].Add(product, price);
                }
                command = Console.ReadLine();
            }

            foreach (var shop in shopsProducts.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
