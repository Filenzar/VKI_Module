using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SortingAlgorithm<T> where T : IComparable<T>
    {
        private T[] _array;
        public int _index;
        public SortingAlgorithm()
        {

        }
        public SortingAlgorithm(T[] array, int index)
        {
            _array = array;
            _index = index;
        }
        private static void Swap(ref T value1, ref T value2)
        {
            var temp = value1;
            value1 = value2;
            value2 = temp;
        }
        private static int GetNextStep(int step)
        {
            step = step * 1000 / 1247;
            return step > 1 ? step : 1;
        }
        public static T[] CombSort(T[] array)
        {
            if (array == null || array.Length <= 1)
                return array;

            var currentStep = array.Length - 1;
            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (array[i].CompareTo(array[i + currentStep]) > 0)
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }
                currentStep = GetNextStep(currentStep);
            }

            for (var i = 1; i < array.Length; i++)
            {
                var swapFlag = false;
                for (var j = 0; j < array.Length - i; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }

        public static T selectid(T[] mass, int id)
        {
            foreach (var item in mass)
            {
                for (int j = 1; j < mass.Length; j++)
                {
                    if (item.Equals(id))
                    {
                        return item;
                    }
                }
            }
            return default;
        }

        public static T[] ShillSort(T[] array)
        {
            for (int distance = array.Length / 2; distance > 0; distance /= 2)
            {
                for (int i = distance; i < array.Length; i++)
                {
                    var elemToInsert = array[i];
                    var position = i;
                    while (position >= distance && array[position - distance].CompareTo(elemToInsert) > 0)
                    {
                        array[position] = array[position - distance];
                        position -= distance;
                    }
                    array[position] = elemToInsert;
                }
            }
            return array;
        }

        public static T[] bSort(T[] mas)
        {
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for (int k = 0; k < mas.Length - 1; k++)
                {

                    for (int j = 0; j < mas.Length - i - 1; j++)
                    {
                        if (mas[j].CompareTo(mas[j + 1]) > 0)
                        {
                            Swap(ref mas[j], ref mas[j + 1]);
                        }
                    }
                }
            }
            return mas;
        }

        public static string Print(T[] mass)
        {
            var result = new StringBuilder();
            foreach (var i in mass)
            {
                result.Append(Convert.ToString(i) + " ");
            }
            return Convert.ToString(result);
        }
    }
}
