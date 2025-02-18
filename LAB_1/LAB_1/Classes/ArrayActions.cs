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
            int mid;
            int left = 0;
            int right = array.Length - 1;
            do
            {
                mid = (left + right) / 2;
                if (element > array[mid]) left = mid + 1;
                else right = mid - 1;
            } while (array[mid] != element && (left <= right));
            
            // Для поиска первого
            while (mid >= -1 && array[mid] == element)
            {
                mid --;
            }
            mid += 1;
            if (array[mid] == element) return mid;
            return -1;
        }
        
        // Интерполяционный поиск
        public static long InterpolationSearch(int[] array, int element)
        {
            long mid = -1;
            long left = 0, right = array.Length - 1;
            while (array[left] <= element && array[right] >= element)
            {
                mid = left + (element - array[left]) * (right - left) / (array[right] - array[left]);
                if (array[mid] < element) left = mid + 1;
                else if (array[mid] > element) right = mid - 1;
                else break;
            }
            if (array[left] == element) mid = left;
            
            // Для поиска первого
            while (mid >= -1 && array[mid] == element)
            {
                mid--;
            }
            mid += 1;
            if (array[mid] == element) return mid;
            return -1;
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
