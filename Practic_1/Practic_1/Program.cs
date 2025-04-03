using ConsoleApp1;
using System;


namespace Practic_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int V = 7;
            Graph graph = new Graph(V);

            int[,] weightMatrix = new int[,]
            {
                { 0, 4, 6, 0, 0, 0, 0 },
                { 4, 0, 0, 1, 0, 0, 0 },
                { 6, 0, 0, 7, 0, 0, 0 },
                { 0, 1, 7, 0, 2, 8, 12 },
                { 0, 0, 0, 2, 0, 5, 0 },
                { 0, 0, 0, 8, 5, 0, 3 },
                { 0, 0, 0, 12, 0, 3, 0 }
            };
            graph.CreateGraphFromMatrix(weightMatrix);

            Console.WriteLine("Алгоритм Дейкстры:");
            graph.Dijkstra(0);

            Console.WriteLine("\nАлгоритм Беллмана-Форда:");
            graph.BellmanFord(0);

            Console.WriteLine("\nАлгоритм Прима:");
            graph.Prim();

            Console.WriteLine("\nАлгоритм Крускала:");
            graph.Kruskal();

            Console.ReadLine();
        }
    }
}
