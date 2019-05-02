using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Data.Entity;

namespace OrderManagerForm
{
    /*
    * add: [客户名] [商品] [数量] [商品] [数量]...
    * query: [id|client|merchandise] arg
    * update: [id] [客户名] [商品] [数量] [商品] [数量]...
    * remove: [id]
    */
    public class OrderService
    {
        public OrderService()
        {
            
        }

        public void add(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                throw new ArgumentException("Wrong argument(s)!");
            }
            try
            {
                List<Order> orders = getAllOrders();
                Order newOrder = new Order(args[0]);
                for (int i = 1; i < args.Length; i +=2)
                {
                    newOrder.details.Add(new OrderDetail(newOrder.orderId , args[i], Int32.Parse(args[i + 1])));
                }
                using (var db = new OrderDB())
                {
                    db.Entry(newOrder).State = EntityState.Added;
                    db.SaveChanges();
                }
                Console.WriteLine("Add succeed!");
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Wrong argument(s)!", e);
            }
        }

        public void remove(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException("Wrong argument(s)!");
            }
            try
            {
                using (var db = new OrderDB())
                {
                    int id = Int32.Parse(args[0]);
                    var order = db.orders.Include("details").SingleOrDefault(o => o.orderId == id);
                    db.orderDetails.RemoveRange(order.details);
                    db.orders.Remove(order);
                    db.SaveChanges();
                }
                Console.WriteLine("Remove succeed!");
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Wrong argument(s)!", e);
            }
        }

        public List<Order> query(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException("Wrong argument(s)!");
            }
            try
            {
                List<Order> orders;
                switch (args[0])
                {
                    case "id":
                        int id = Int32.Parse(args[1]);
                        using (var db = new OrderDB())
                        {
                            orders = db.orders.Include("details").Where(o => o.orderId == id).ToList<Order>();
                        }
                        break;
                    case "client":
                        using (var db = new OrderDB())
                        {
                            orders = db.orders.Include("details").Where(o => o.clientName.Equals(args[1])).ToList<Order>();
                        }
                        break;
                    case "merchandise":
                        using (var db = new OrderDB())
                        {
                            orders = db.orders.Include("details")
                                .Where(o => o.details.Where(detail => detail.merchandise.Equals(args[1])).Count() > 0)
                                .ToList<Order>();
                        }
                        break;
                    default:
                        throw new ArgumentException("Wrong argument(s)!");
                }
                return orders;
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Wrong argument(s)!", e);
            }
        }

        public void update(string[] args)
        {
            if (args.Length < 4 || args.Length % 2 == 1)
            {
                throw new ArgumentException("Wrong argument(s)!");
            }
            try
            {
                int id = Int32.Parse(args[0]);
                using (var db = new OrderDB())
                {
                    Order oldOrder = db.orders.Include("details").SingleOrDefault(o => o.orderId == id);
                    if (oldOrder == null)
                    {
                        throw new ArgumentException("Order not found!");
                    }
                    else
                    {
                        List<OrderDetail> newDetails = new List<OrderDetail>(); ;
                        for (int i = 2; i < args.Length; i += 2)
                        {
                            newDetails.Add(new OrderDetail(id, args[i], Int32.Parse(args[i + 1])));
                        }
                        oldOrder.details.AddRange(newDetails);
                        for (int i = 0; i < oldOrder.details.Count; i++)
                        {
                            if (newDetails.Contains(oldOrder.details[i]))
                            {
                                db.Entry(oldOrder.details[i]).State = EntityState.Added;
                            }
                            else
                            {
                                db.Entry(oldOrder.details[i]).State = EntityState.Deleted;
                            }
                        }
                        db.SaveChanges();
                        oldOrder.clientName = args[1];
                        db.Entry(oldOrder).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                Console.WriteLine("Update succeed!");
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Wrong argument(s)!", e);
            }
        }

        public List<Order> getAllOrders()
        {
            using (var db = new OrderDB())
            {
                return db.orders.Include("details").ToList<Order>();
            }
        }

        public List<OrderDetail> getOrderDetails(int id)
        {
            using (var db = new OrderDB())
            {
                return db.orderDetails.Where(o => o.orderId == id).ToList<OrderDetail>();
            }
        }
    }
}
