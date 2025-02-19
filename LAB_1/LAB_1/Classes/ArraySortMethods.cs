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

        // Быстрая сортировка
        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                QuickSort(arr, left, pivot - 1);
                QuickSort(arr, pivot + 1, right);
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[right] = temp1;
            return i + 1;
        }

        public static void ViewArray(int[] array)
        {
            for (int i = 0; i < 10; i++) Console.Write($"{array[i]} ");
        }
    }
}
