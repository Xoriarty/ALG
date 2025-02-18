using LAB_1.Classes;
using System;
using System.Diagnostics;


namespace LAB_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
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
                            // Console.WriteLine("Сформированный массив: ");
                            // ArrayActions.ViewArray(A);
                            int[] B = ArrayActions.Sort(A);
                            // Console.WriteLine("\nОтсоритрованный массив: ");
                            // ArrayActions.ViewArray(B);
                            Console.Write("Введите элемент для поиска: ");
                            if (!int.TryParse(Console.ReadLine(), out int el)) Console.WriteLine("Некорректное число");
                            else
                            {
                                long index;

                                stopwatch.Restart();
                                index = ArrayActions.LinearSearch(B, el);
                                stopwatch.Stop();
                                Console.WriteLine($"Время выполнения линейного поиска: {stopwatch.ElapsedTicks}");

                                stopwatch.Restart();
                                index = ArrayActions.BinarySearch(B, el);
                                stopwatch.Stop();
                                Console.WriteLine($"Время выполнения бинарного поиска: {stopwatch.ElapsedTicks}");

                                stopwatch.Restart();
                                index = ArrayActions.InterpolationSearch(B, el);
                                stopwatch.Stop();
                                Console.WriteLine($"Время выполнения интерполяционного поиска: {stopwatch.ElapsedTicks}");

                                if (index == -1) Console.WriteLine("Элемент не найден");
                                else Console.WriteLine($"Индекс элемента {el} = {index}");

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
