using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TV tv;
                TVFactory factory = (TVFactory) XMLUtil.getBean();
                tv = factory.produceTV();
                tv.play();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
