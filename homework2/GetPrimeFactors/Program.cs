using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPrimeFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please enter a number");
            try
            {
                int num = Int32.Parse(System.Console.ReadLine());
                int[] primeFactors = getPrimeFactors(num);
                foreach(int i in primeFactors)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int[] getPrimeFactors(int n)
        {
            List<int> primeFactors = new List<int>();
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    n = n / i;
                    primeFactors.Add(i);
                    i--;
                }
            }
            primeFactors.Add(n);
            return primeFactors.ToArray();
        }
    }
}
