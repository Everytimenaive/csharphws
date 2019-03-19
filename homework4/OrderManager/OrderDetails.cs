using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    class OrderDetails: Dictionary<string, int>
    {
        public override string ToString()
        {
            string str = "";
            foreach (string key in this.Keys)
            {
                str += (key + ":" + this[key] + ";");
            }
            str = "(" + str + ")";
            return str;
        }
    }
}
