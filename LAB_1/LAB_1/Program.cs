using LAB_1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            string line = Console.ReadLine();
            if (!int.TryParse(line, out int N)) Console.WriteLine("Некорректный ввод числа");
            else
            {
                if (N < 1) Console.WriteLine("Некорректный размер массива (N < 1)");
                else
                {
                    Console.Write("Введите диапазон заполнения массива через пробел: ");
                    string[] range = Console.ReadLine().Split();
                    if (range.Length == 2)
                    {
                        if (!int.TryParse(range[0], out int start) || !int.TryParse(range[1], out int end)) Console.WriteLine("Некорректный ввод чисел");
                        else
                        {
                            if (start > end)
                            {
                                int tmp = start;
                                start = end;
                                end = tmp;
                            }
                            int[] A = ArrayActions.CreaeteArray(N, start, end);
                            Console.WriteLine("Сформированный массив: ");
                            ArrayActions.ViewArray(A);
                            int[] B = ArrayActions.Sort(A);
                            Console.WriteLine("\nОтсоритрованный массив: ");
                            ArrayActions.ViewArray(B);
                            Console.Write("\nВведите элемент для поиска: ");
                            if (!int.TryParse(Console.ReadLine(), out int el)) Console.WriteLine("Некорректное число");
                            else
                            {
                                int index = ArrayActions.BinarySearch(B, el);
                                Console.WriteLine($"Результат с использованием бинарного поиска: {index}");
                                index = ArrayActions.InterpolationSearch(B, el);
                                Console.WriteLine($"Результат с использованием интерполяционного поиска: {index}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                }
            }



            Console.ReadKey();
        }
    }
}
