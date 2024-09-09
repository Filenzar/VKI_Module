using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomConverter converter = new CustomConverter();
            byte b;
            converter.Converting("123", out b);
            Console.WriteLine($"b = {b}");
            Console.WriteLine(b.GetType());
            Console.ReadLine();
        }
    }
}
