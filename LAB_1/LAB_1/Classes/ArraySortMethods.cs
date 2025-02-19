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

        public static void ViewArray(int[] array)
        {
            for (int i = 0; i < 10; i++) Console.Write($"{array[i]} ");
        }
    }
}
