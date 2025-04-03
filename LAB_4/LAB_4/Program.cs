using System;


namespace LAB_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Очереди
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(-5);
            queue.Enqueue(20);
            queue.Enqueue(-15);
            queue.Enqueue(30);

            Console.WriteLine("Исходная очередь:");
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Удален элемент: " + queue.Dequeue());

            Console.WriteLine("Очередь после удаления:");
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Очередь пуста: " + queue.IsEmpty);

            Queue<int> positiveQueue, negativeQueue;
            queue.Split(out positiveQueue, out negativeQueue);

            Console.WriteLine("Положительная очередь:");
            foreach (var item in positiveQueue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Отрицательная очередь:");
            foreach (var item in negativeQueue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            queue.Clear();
            Console.WriteLine("Очередь очищена.");
            Console.WriteLine("Очередь пуста: " + queue.IsEmpty);

            // Стеки
            Stack<Person> stack = new Stack<Person>();


            stack.Push(new Person("Иван Иванов", new DateTime(1990, 1, 1), "Москва", "1234 567890", "г. Москва, ул. Пушкина, д. 1"));
            stack.Push(new Person("Петр Петров", new DateTime(1985, 5, 15), "Санкт-Петербург", "9876 543210", "г. Санкт-Петербург, ул. Ленина, д. 2"));
            stack.Push(new Person("Светлана Сидорова", new DateTime(1992, 8, 20), "Екатеринбург", "1357 246810", "г. Екатеринбург, ул. Чехова, д. 3"));

            Console.WriteLine("Исходный стек:");
            PrintStack(stack);

            Stack<Person> reversedStack = ReverseStack(stack);

            Console.WriteLine("\nОбратный стек:");
            PrintStack(reversedStack);

            // Деки
            Deque<int> deque = new Deque<int>();

            deque.AddBack(10);
            deque.AddBack(-5);
            deque.AddBack(20);
            deque.AddFront(-15);
            deque.AddFront(30);

            Console.WriteLine("Исходный дек:");
            PrintDeque(deque);


            Console.WriteLine("\nУдален элемент из начала дека: " + deque.RemoveFront());
            Console.WriteLine("Удален элемент из конца дека: " + deque.RemoveBack());

            Console.WriteLine("\nДек после удаления элементов:");
            PrintDeque(deque);


            Console.WriteLine("\nДек пуст: " + deque.IsEmpty);


            deque.Split(out Deque<int> positiveDeque, out Deque<int> negativeDeque);

            Console.WriteLine("\nПоложительный дек:");
            PrintDeque(positiveDeque);

            Console.WriteLine("\nОтрицательный дек:");
            PrintDeque(negativeDeque);

            deque.Clear();
            Console.WriteLine("\nДек очищен.");
            Console.WriteLine("Дек пуст: " + deque.IsEmpty);
            Console.Read();
        }

        private static void PrintStack(Stack<Person> stack)
        {
            foreach (var person in stack)
            {
                Console.WriteLine(person);
            }
        }


        private static Stack<Person> ReverseStack(Stack<Person> stack)
        {
            Stack<Person> reversedStack = new Stack<Person>();
            while (!stack.IsEmpty)
            {
                reversedStack.Push(stack.Pop());
            }
            return reversedStack;
        }
        private static void PrintDeque(Deque<int> deque)
        {
            if (deque.IsEmpty)
            {
                Console.WriteLine("Дек пуст.");
                return;
            }

            Console.Write("Элементы дека: ");
            foreach (var item in deque)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

    }
}
