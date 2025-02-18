using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1.Classes
{
    internal class ArrayActions
    {
        // Заполнение массива
        public static int[] CreaeteArray(int size, int start, int end)
        {
            int[] array = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++) array[i] = random.Next(start, end + 1);
            return array;
        }

        // Вывод массива
        public static void ViewArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++) Console.Write($"{array[i]} ");
        }

        // Базовая сортировка
        public static int[] Sort(int[] array)
        {
            Array.Sort(array);
            return array;
        }

        // Бинарный поиск
        public static int BinarySearch(int[] array, int element)
        {
            int index = -1;
            int left = 0;
            int right = array.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (array[mid] == element) return mid;
                else if (array[mid] < element) left = mid + 1;
                else right = mid - 1;
            }
            return index;
        }
        
        // Интерполяционный поиск
        public static int InterpolationSearch(int[] array, int element)
        {
            int lo = 0;
            int mid = -1;
            int hi = array.Length - 1;
            int index = -1;
            while (lo <= hi)
            {
                mid = (int)(lo + (((double)(hi - lo) / (array[hi] - array[lo])) * (element - array[lo])));
                if (array[mid] == element)
                {
                    index = mid;
                    break;
                }
                else
                {
                    if (array[mid] < element) lo = mid + 1;
                    else hi = mid - 1;
                }
            }
            return index;
        }
    }
}
