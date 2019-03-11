using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    class TVFactory
    {
        public static TV produceTV(string brand)
        {
            if (brand == "Haier")
            {
                Console.WriteLine("The TV factory produces Haier TV.");
                return new HaierTV();
            }
            else if (brand == "Hisense")
            {
                Console.WriteLine("The TV factory produces Hisense TV.");
                return new HisenseTV();
            }
            else
            {
                throw new ArgumentException($"Can't produce this brand of TV: {brand}.");
            }
        }
    }
}
