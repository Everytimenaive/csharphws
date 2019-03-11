using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class HisenseTVFactory: TVFactory
    {
        public TV produceTV()
        {
            Console.WriteLine("Hisense TV Factory produces Hisense TV");
            return new HisenseTV();
        }
    }
}
