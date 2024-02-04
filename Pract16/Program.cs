using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;

namespace Pract16
{
    class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Запись информации о товарах в JSON-файл
            Product[] products = new Product[5];

            Console.WriteLine("Введите информацию о товарах:");

            for (int i = 0; i < products.Length; i++)
            {
                products[i] = new Product();

                Console.Write("Введите код товара: ");
                products[i].ProductCode = int.Parse(Console.ReadLine());

                Console.Write("Введите название товара: ");
                products[i].ProductName = Console.ReadLine();

                Console.Write("Введите цену товара: ");
                products[i].ProductPrice = double.Parse(Console.ReadLine());

                Console.WriteLine();
            }

            string jsonString = JsonSerializer.Serialize(products);
            File.WriteAllText("Products.json", jsonString);

            Console.WriteLine("Информация о товарах записана в файл \"Products.json\"");

            // Получение информации о товаре из JSON-файла и нахождение самого дорогого товара
            string jsonFromFile = File.ReadAllText("Products.json");
            Product[] loadedProducts = JsonSerializer.Deserialize<Product[]>(jsonFromFile);

            double maxPrice = double.MinValue;
            string maxPriceProductName = "";

            foreach (var product in loadedProducts)
            {
                if (product.ProductPrice > maxPrice)
                {
                    maxPrice = product.ProductPrice;
                    maxPriceProductName = product.ProductName;
                }
            }

            Console.WriteLine($"Самый дорогой товар: {maxPriceProductName}, цена: {maxPrice}");
        }
    }
}