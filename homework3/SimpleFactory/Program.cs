using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string brandName = XMLUtil.getBrandName();
                TV tv = TVFactory.produceTV(brandName);
                tv.play();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
