using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutipConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please Enter two numbers(split by space):");
            String[] inputs = System.Console.ReadLine().Split(' ');
            try
            {
                int numA = Int32.Parse(inputs[0]);
                int numB = Int32.Parse(inputs[1]);
                System.Console.WriteLine("The product is: " + (numA * numB));
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
