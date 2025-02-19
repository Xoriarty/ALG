using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1.Classes
{
    internal class ArraySortMethods
    {
        // Сортировка пузырьком
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        // Сортировка подсчетом
        public static void CountingSort(int[] array)
        {
            if (array.Length == 0)
                return;

            int min = array.Min();
            int max = array.Max();

            int[] count = new int[max - min + 1];

            for (int i = 0; i < array.Length; i++)
            {
                count[array[i] - min]++;
            }

            int index = 0;
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    array[index] = i + min;
                    index++;
                    count[i]--;
                }
            }
        }


        public static void ViewArray(int[] array)
        {
            for (int i = 0; i < 10; i++) Console.Write($"{array[i]} ");
        }
    }
}
