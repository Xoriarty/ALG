using System;


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
            int low = 0, high = array.Length - 1, mid;

            while (array[high] != array[low] && element >= array[low] && element <= array[high])
            {
                mid = low + ((element - array[low]) * (high - low) / (array[high] - array[low]));

                if (element == array[mid])
                {
                    return mid;
                }

                else if (element < array[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            if (element == array[low])
            {
                return low;
            }

            else
            {
                return -1;
            }
        }

        // Линейный поиск
        public static int LinearSearch(int[] array, int element)
        {
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element) return i;
            }
            return index;
        }
    }
}
