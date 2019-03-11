using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class HisenseTV: TV
    {
        public void play()
        {
            Console.WriteLine("Hisense TV playing...");
        }
    }
}
