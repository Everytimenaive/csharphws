using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace OrderManagerForm
{
    public class Order: IComparable
    {
        [Key]
        public int orderId { get; set; }
        public string clientName { get; set; }
        public List<OrderDetail> details { get; set; }

        public Order()
        {
            details = new List<OrderDetail>();
        }

        public Order(string clientName): this()
        {
            this.clientName = clientName;
        }

        public Order(int orderId, string clientName): this()
        {
            this.orderId = orderId;
            this.clientName = clientName;
        }

        public override string ToString()
        {
            string str = orderId + " " + clientName + " " + details;
            return str;
        }

        public override bool Equals(object obj)
        {
            if (obj is Order)
            {
                Order order = (Order)obj;
                if (this.orderId == order.orderId || (this.clientName == order.clientName && this.clientName.Equals(order.details)))
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return orderId;
        }

        public int CompareTo(Object obj)
        {
            if (!(obj is Order))
            {
                throw new ArgumentException("Wrong argument type!");
            }
            return this.orderId - ((Order) obj).orderId;
        }
    }
}
