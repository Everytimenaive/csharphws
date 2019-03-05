using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayStatistics
{
    class Program
    {
        public static readonly int[] AN_ARRAY = { 15, 64, 2, 255, 257, 46, 3, 7, 1 };

        static void Main(string[] args)
        {
            Console.Write("Aray: ");
            foreach (int i in AN_ARRAY)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Max: {AN_ARRAY.Max()}");
            Console.WriteLine($"Min: {AN_ARRAY.Min()}");
            Console.WriteLine($"Average: {AN_ARRAY.Average()}");
            Console.WriteLine($"Sum: {AN_ARRAY.Sum()}");
        }
    }
}
