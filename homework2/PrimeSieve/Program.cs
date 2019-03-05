using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSieve
{
    class Program
    {
        private const int RANGE = 101;
        static void Main(string[] args)
        {
            bool[] primeTable = new bool[RANGE];
            for (int i = 0; i < primeTable.Length; i++)
            {
                primeTable[i] = true;
            }
            for (int i = 2; i < primeTable.Length; i++)
            {
                if (primeTable[i])
                {
                    for (int j = 2  * i; j < primeTable.Length; j += i)
                    {
                        primeTable[j] = false;
                    }
                }
            }
            Console.WriteLine("Primes between 2 and 100:");
            for (int i = 2; i < primeTable.Length; i++)
            {
                if (primeTable[i])
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }
    }
}
