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
    }
}
