using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OrderManagerForm
{
    public class OrderDetail
    {
        [Key]
        public int detailId { get; set; }
        public int orderId { get; set; }
        public string merchandise { get; set; }
        public int amount { get; set; }

        public OrderDetail() { }

        public OrderDetail(int orderId, string merchandise, int amount)
        {
            this.orderId = orderId;
            this.merchandise = merchandise;
            this.amount = amount;
        }

        public override string ToString()
        {
            string str = "(" + merchandise + ": " + amount + ")";
            return str;
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderDetail)
            {
                OrderDetail orderDetail = (OrderDetail) obj;
                if (this.orderId == orderDetail.orderId && this.merchandise == orderDetail.merchandise)
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
