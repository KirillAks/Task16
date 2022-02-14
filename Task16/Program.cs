﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task16
{
    class Program
    {
        //Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.
        //Разработать класс для моделирования объекта «Товар».
        //Предусмотреть члены класса «Код товара» (целое число), «Название товара» (строка), «Цена товара» (вещественное число).
        //Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
        //Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».
        //Необходимо разработать программу для получения информации о товаре из json-файла.
        //Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.

        static void Main(string[] args)
        {
            const int n = 5;
            Product[] products = new Product[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите код товара: ");
                int codeProduct = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите название товара: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Введите цену товара: ");
                double priceProduct = Convert.ToDouble(Console.ReadLine());
                products[i] = new Product() { CodeProduct = codeProduct, NameProduct = nameProduct, PriceProduct = priceProduct };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(products, options);
            using (StreamWriter sw=new StreamWriter("../../../Products.json"))
            {
                sw.WriteLine(jsonString);
            }                        
        }
    }
}
