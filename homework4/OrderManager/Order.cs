using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    class Order
    {
        public int orderId { get; set; }
        public string clientName { get; set; }
        public OrderDetails details { get; }

        public Order(int orderId, string clientName)
        {
            this.orderId = orderId;
            this.clientName = clientName;
            details = new OrderDetails();
        }

        public override string ToString()
        {
            string str = orderId + " " + clientName + " " + details;
            return str;
        }
    }
}
