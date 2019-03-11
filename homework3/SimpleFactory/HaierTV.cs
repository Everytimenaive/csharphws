using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    class HaierTV: TV
    {
        public void play()
        {
            Console.WriteLine("Haier TV playing...");
        }
    }
}
