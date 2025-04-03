using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Graph
    {
        private int V; 
        private List<Tuple<int, int, int>> edges; 

        public Graph(int v)
        {
            V = v;
            edges = new List<Tuple<int, int, int>>();
        }

        public void CreateGraphFromMatrix(int[,] weightMatrix)
        {
            for (int i = 0; i < V; i++)
            {
                for (int j = i + 1; j < V; j++)
                {
                    if (weightMatrix[i, j] != 0)
                    {
                        edges.Add(Tuple.Create(i, j, weightMatrix[i, j]));
                    }
                }
            }
        }

        public void Dijkstra(int startVertex)
        {
            int[] distances = new int[V];
            bool[] shortestPathTreeSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                distances[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distances[startVertex] = 0;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinDistance(distances, shortestPathTreeSet);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (!shortestPathTreeSet[v] && edges.Exists(e => (e.Item1 == u && e.Item2 == v)
                                                                    || (e.Item1 == v && e.Item2 == u)))
                    {
                        int edgeWeight = edges.Find(e => (e.Item1 == u && e.Item2 == v) 
                                                        || (e.Item1 == v && e.Item2 == u)).Item3;
                        if (distances[u] != int.MaxValue && distances[u] + edgeWeight < distances[v])
                        {
                            distances[v] = distances[u] + edgeWeight;
                        }
                    }
                }
            }

            Console.WriteLine("Расстояния от начальной вершины:");
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine($"Вершина {i + 1}: {distances[i]}");
            }
        }

        private int MinDistance(int[] distances, bool[] shortestPathTreeSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (!shortestPathTreeSet[v] && distances[v] <= min)
                {
                    min = distances[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        public void BellmanFord(int startVertex)
        {
            int[] distances = new int[V];
            for (int i = 0; i < V; i++)
                distances[i] = int.MaxValue;

            distances[startVertex] = 0;

            for (int i = 1; i <= V - 1; i++)
            {
                foreach (var edge in edges)
                {
                    int u = edge.Item1;
                    int v = edge.Item2;
                    int weight = edge.Item3;

                    if (distances[u] != int.MaxValue && distances[u] + weight < distances[v])
                    {
                        distances[v] = distances[u] + weight;
                    }
                }
            }

            Console.WriteLine("Расстояния от начальной вершины (Алгоритм Беллмана-Форда):");
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine($"Вершина {i + 1}: {distances[i]}");
            }
        }


        public void Prim()
        {
            bool[] inMST = new bool[V];
            int[] key = new int[V];
            int[] parent = new int[V];

            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                inMST[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinKey(key, inMST);
                inMST[u] = true;

                foreach (var edge in edges)
                {
                    int v = edge.Item2;
                    int weight = edge.Item3;

                    if ((edge.Item1 == u || edge.Item2 == u) && !inMST[v])
                    {
                        if (key[v] > weight)
                        {
                            key[v] = weight;
                            parent[v] = u;
                        }
                    }
                }
            }

            PrintPrimMST(parent);
        }

        private int MinKey(int[] key, bool[] inMST)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (!inMST[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        private void PrintPrimMST(int[] parent)
        {
            Console.WriteLine("Рёбра минимального остовного дерева (Прима):");
            for (int i = 1; i < V; i++)
            {
                Console.WriteLine($"Вершина {parent[i] + 1} - Вершина {i + 1}");
            }
        }

        public void Kruskal()
        {
            edges.Sort((a, b) => a.Item3.CompareTo(b.Item3)); 
            int[] parent = new int[V];
            for (int i = 0; i < V; i++) parent[i] = i;

            List<Tuple<int, int, int>> result = new List<Tuple<int, int, int>>();

            foreach (var edge in edges)
            {
                int u = edge.Item1;
                int v = edge.Item2;
                int weight = edge.Item3;

                if (Find(parent, u) != Find(parent, v)) 
                {
                    result.Add(edge);
                    Union(parent, u, v);
                }
            }

            PrintKruskalMST(result);
        }

        private int Find(int[] parent, int i)
        {
            if (parent[i] == i)
                return i;
            return Find(parent, parent[i]);
        }

        private void Union(int[] parent, int x, int y)
        {
            int xroot = Find(parent, x);
            int yroot = Find(parent, y);
            parent[xroot] = yroot;
        }

        private void PrintKruskalMST(List<Tuple<int, int, int>> result)
        {
            Console.WriteLine("Рёбра минимального остовного дерева (Крускал):");
            foreach (var edge in result)
            {
                Console.WriteLine($"Вершина {edge.Item1 + 1} - Вершина {edge.Item2 + 1} (Вес: {edge.Item3})");
            }
        }
    }
}

