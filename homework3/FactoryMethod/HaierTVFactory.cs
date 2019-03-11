using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class HaierTVFactory: TVFactory
    {
        public TV produceTV()
        {
            Console.WriteLine("Haier TV Factory produces Haier TV");
            return new HaierTV();
        }
    }
}
