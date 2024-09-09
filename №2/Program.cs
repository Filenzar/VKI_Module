using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Toy("Ball",120,"0");
            Product product2 = new Meat("asdf", 123488, "12.07.24");
            Product product3 = new Drinks("Fanta", 12.34, "Soda");
            Product product3_1 = new Drinks("Vodka", 99.99, "Alcohol");
            Product product4 = new Snacks("Lays", 1.23, "Russia");
            Product[] list = { product1, product2, product3, product3_1 , product4 };
            foreach (var item in list) 
            {
                Console.WriteLine(item.GetInformation());
            }
            Console.ReadLine();
        }
    }
}
