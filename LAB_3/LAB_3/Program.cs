using System;
using System.Linq;

namespace LAB_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1 - однонаправленный, 2 - двунаправленный. Ваш выбор: ");
            int chc = Convert.ToInt32(Console.ReadLine());
            if (chc == 1)
            {
                
                LList<int> list = new LList<int>();
                Random random = new Random();
                int size;

                Console.WriteLine("Введите количество элементов в массиве:");
                size = int.Parse(Console.ReadLine());
                int[] mas = new int[size];
                for (int i = 0; i < size; i++)
                {
                    int number = random.Next(-100, 100);
                    mas[i] = number;
                }
                foreach (int number in mas) list.Add(number);

                Console.WriteLine(list.ToString());

                bool running = true;
                while (running)
                {
                    Console.WriteLine("\nВыберите действие:");
                    Console.WriteLine("1 - Добавить элемент в конец");
                    Console.WriteLine("2 - Добавить элемент в начало");
                    Console.WriteLine("3 - Добавить элемент по индексу");
                    Console.WriteLine("4 - Удалить элемент по значению");
                    Console.WriteLine("5 - Удалить элемент по индексу");
                    Console.WriteLine("6 - Найти индекс элемента");
                    Console.WriteLine("7 - Очистить список");
                    Console.WriteLine("8 - Показать список");
                    Console.WriteLine("0 - Выход");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Введите элемент для добавления в конец:");
                            int dataToAdd = int.Parse(Console.ReadLine());
                            list.Add(dataToAdd);
                            Console.WriteLine("Элемент добавлен.");
                            break;

                        case 2:
                            Console.WriteLine("Введите элемент для добавления в начало:");
                            int dataToAddFirst = int.Parse(Console.ReadLine());
                            list.AddFirst(dataToAddFirst);
                            Console.WriteLine("Элемент добавлен в начало.");
                            break;

                        case 3:
                            Console.WriteLine("Введите элемент для добавления и индекс:");
                            int dataToAddIndex = int.Parse(Console.ReadLine());
                            int indexToAdd = int.Parse(Console.ReadLine());
                            try
                            {
                                list.AddIndex(dataToAddIndex, indexToAdd);
                                Console.WriteLine("Элемент добавлен по индексу.");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Индекс вне диапазона.");
                            }
                            break;

                        case 4:
                            if (list.Count > 0)
                            {
                            Console.WriteLine("Введите элемент для удаления:");
                            int elementToRemove = int.Parse(Console.ReadLine());
                            if (list.Remove(elementToRemove))
                                Console.WriteLine("Элемент удален.");
                            else
                                Console.WriteLine("Элемент не найден.");
                            }
                            else Console.WriteLine("Список пусто");
                            break;

                        case 5:
                            if (list.Count > 0)
                            {
                                Console.WriteLine("Введите индекс элемента для удаления:");
                                int indexToRemove = int.Parse(Console.ReadLine());
                                if (list.RemoveAt(indexToRemove))
                                    Console.WriteLine("Элемент удален.");
                                else
                                    Console.WriteLine("Не удалось удалить элемент. Индекс вне диапазона.");
                            }
                            else Console.WriteLine("Список пустой");
                            break;

                        case 6:
                            if (list.Count > 0)
                            {
                                Console.WriteLine("Введите элемент для поиска:");
                                int dataToFind = int.Parse(Console.ReadLine());
                                int foundIndex = list.IndexOf(dataToFind);
                                if (foundIndex != -1)
                                    Console.WriteLine($"Элемент найден на индексе: {foundIndex}");
                                else
                                    Console.WriteLine("Элемент не найден.");
                            }
                            else Console.WriteLine("Список пустой");
                            break;

                        case 7:
                            list.Clear();
                            Console.WriteLine("Список очищен.");
                            break;

                        case 8:
                            if (list.Count > 0)
                            {
                                Console.WriteLine(list.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Список пустой");
                            }
                            break;

                        case 0:
                            running = false;
                            Console.WriteLine("Выход из программы.");
                            break;
                           

                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
            }
            else if (chc == 2)
            {
                LinkedList<char> list = new LinkedList<char>();
                Console.WriteLine("Введите символы (введите '.' для завершения): ");


                while (true)
                {
                    char input = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    if (input == '.')
                        break;

                    if (input == '#')
                    {
                       list.RemoveLast(); ;
                    }
                    else
                    {
                        list.AddLast(input);
                        Console.WriteLine($"Добавлен символ: {input}");
                    }
                }

                Console.WriteLine(list.ToString());


                bool running = true;
                while (running)
                {
                    Console.WriteLine("\nВыберите действие:");
                    Console.WriteLine("1 - Добавить элемент в конец");
                    Console.WriteLine("2 - Добавить элемент в начало");
                    Console.WriteLine("3 - Удалить элемент по значению");
                    Console.WriteLine("4 - Отчистить список");
                    Console.WriteLine("5 - Вывести список");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Введите элемент для добавления в конец:");
                            char dataToAdd = Console.ReadLine()[0];
                            list.AddLast(dataToAdd);
                            Console.WriteLine("Элемент добавлен.");
                            break;

                        case 2:
                            Console.WriteLine("Введите элемент для добавления в начало:");
                            char dataToAddFirst = Console.ReadLine()[0];
                            list.AddFirst(dataToAddFirst);
                            Console.WriteLine("Элемент добавлен в начало.");
                            break;

                        case 3:
                            if (list.Count > 0)
                            {
                                Console.WriteLine("Введите элемент для удаления:");
                                char elementToRemove = Console.ReadLine()[0];
                                if (list.Remove(elementToRemove))
                                    Console.WriteLine("Элемент удален.");
                                else
                                    Console.WriteLine("Элемент не найден.");
                            }
                            else Console.WriteLine("Список пуст");
                            break;
                        case 4:
                            list.Clear();
                            Console.WriteLine("Список очищен.");
                            break;

                        case 5:
                            if (list.Count > 0)
                            {
                                Console.WriteLine(list.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Список пустой");
                            }
                            break;

                        case 0:
                            running = false;
                            Console.WriteLine("Выход из программы.");
                            break;

                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }




            }
        }
    }
}
