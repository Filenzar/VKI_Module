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
            // Пример использования метода CombSort
            int[] testArray = { 4, 2, 1, 3, 5 };
            SortingAlgorithm<int>.CombSort(testArray);
            Console.WriteLine("Результат CombSort: " + SortingAlgorithm<int>.Print(testArray));

            // Пример использования метода ShillSort
            testArray = new int[] { 4, 2, 1, 3, 5 };
            SortingAlgorithm<int>.ShillSort(testArray);
            Console.WriteLine("Результат ShillSort: " + SortingAlgorithm<int>.Print(testArray));

            // Пример использования метода bSort
            testArray = new int[] { 4, 2, 1, 3, 5 };
            SortingAlgorithm<int>.bSort(testArray);
            Console.WriteLine("Результат bSort: " + SortingAlgorithm<int>.Print(testArray));

            // Пример использования метода selectid
            testArray = new int[] { 4, 2, 1, 3, 5 };
            int selectedId = SortingAlgorithm<int>.selectid(testArray, 3);
            Console.WriteLine("Результат selectid: " + selectedId);

            string[] stringArray = { "danana", "apple", "cherry" };
            SortingAlgorithm<string>.CombSort(stringArray);
            Console.WriteLine("Sorted strings: " + SortingAlgorithm<string>.Print(stringArray));

            Console.ReadLine();
        }
    }
}
