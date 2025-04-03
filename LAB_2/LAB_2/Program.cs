using System;

namespace LAB_2
{
    internal class Program
    {
        static decimal Rec(int n, decimal res = 0)
        {
            if (n == 0) return res;
            decimal a = n * Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(n + 5 + res)));
            return Rec(n - 1, a);
        }


        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ответ: {Rec(n)}");
            Console.ReadKey();
        }
    }
}
