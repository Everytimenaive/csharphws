using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    class OrderService
    {
        private List<Order> orders;
        private int index;

        public OrderService()
        {
            orders = new List<Order>();
            index = 1;
        }

        public void add(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                throw new ArgumentException("Wrong argument(s)!");
            }
            try
            {
                Order newOrder = new Order(index, args[0]);
                foreach (Order order in orders)
                {
                    if (order.Equals(newOrder))
                    {
                        throw new ArgumentException("Order already exists!");
                    }
                }
                for (int i = 1; i < args.Length; i +=2)
                {
                    newOrder.details.Add(args[i], Int32.Parse(args[i + 1]));
                }
                orders.Add(newOrder);
                index++;
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
                Order order = orders.Find(item =>
                {
                    if (item.orderId == Int32.Parse(args[0]))
                    {
                        return true;
                    }
                    return false;
                });
                if (order == null)
                {
                    throw new ArgumentException("Order not found!");
                }
                else
                {
                    orders.Remove(order);
                }
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Wrong argument(s)!", e);
            }
        }


        public void query(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException("Wrong argument(s)!");
            }
            try
            {
                Func<Order, bool> match;
                switch (args[0])
                {
                    case "id":
                        match = item =>
                        {
                            if (item.orderId == Int32.Parse(args[1]))
                            {
                                return true;
                            }
                            return false;
                        };
                        break;
                    case "client":
                        match = item =>
                        {
                            if (item.clientName == args[1])
                            {
                                return true;
                            }
                            return false;
                        };
                        break;
                    case "merchandise":
                        match = item =>
                        {
                            if (item.details.ContainsKey(args[1]))
                            {

                                return true;
                            }
                            return false;
                        };
                        break;
                    default:
                        throw new ArgumentException("Wrong argument(s)!");
                }
                var results = orders.Where(match);
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
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
                int idx = Int32.Parse(args[0]);
                Order oldOrder = orders.Find(item =>
                {
                    if (item.orderId == idx)
                    {
                        return true;
                    }
                    return false;
                });
                if (oldOrder == null)
                {
                    throw new ArgumentException("Order not found!");
                }
                else
                {
                    Order newOrder = new Order(idx, args[1]);
                    for (int i = 2; i < args.Length; i += 2)
                    {
                        newOrder.details.Add(args[i], Int32.Parse(args[i + 1]));
                    }
                    orders[orders.IndexOf(oldOrder)] = newOrder;
                }
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Wrong argument(s)!", e);
            }
        }

        public void sort(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException("Wrong argument(s)!");
            }
            switch (args[0])
            {
                case "id":
                    orders.Sort();
                    break;
                case "price":
                    orders.Sort((o1, o2) => {
                        return o1.details.totalPrice - o2.details.totalPrice;
                    });
                    break;
                default:
                    throw new ArgumentException("Wrong argument(s)!");
            }
        }
    }
}
