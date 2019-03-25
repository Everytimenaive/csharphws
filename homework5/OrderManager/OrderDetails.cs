using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    class OrderDetails: Dictionary<string, int>
    {
        public int totalPrice
        {
            get => this.Values.Sum();
        }

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

        public override bool Equals(object obj)
        {
            if (obj is OrderDetails)
            {
                OrderDetails orderDetails = (OrderDetails)obj;
                if (this.ToString() == orderDetails.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
