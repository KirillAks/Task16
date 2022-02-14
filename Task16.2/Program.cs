using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Task16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr=new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);
            Product costlyProduct = products[0];
            foreach (Product p in products)
            {
                if (p.PriceProduct>costlyProduct.PriceProduct)
                {
                    costlyProduct = p;
                }
            }
            Console.WriteLine($"Самый дорогой товар:{costlyProduct.NameProduct}, цена:{costlyProduct.PriceProduct}");
            Console.ReadKey();
        }
    }
}
