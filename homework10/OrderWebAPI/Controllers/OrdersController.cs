using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController
    {
        private readonly OrderDB context;

        public OrdersController(OrderDB context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> getAllOrders()
        {
            return context.orders.Include("details").ToList<Order>();
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Order>> getOrder(int id)
        {
            return context.orders.Include("details").Where(o => o.orderId == id).ToList<Order>();
        }

        [HttpPost("add")]
        public bool addOrder(Order order)
        {
            try
            {
                context.Entry(order).State = EntityState.Added;
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                return false;
            }
        }

        [HttpGet("remove/{id}")]
        public bool removeOrder(int id)
        {
            try
            {
                var order = context.orders.Include("details").SingleOrDefault(o => o.orderId == id);
                context.orderDetails.RemoveRange(order.details);
                context.orders.Remove(order);
                context.SaveChanges();
                return true;
            }
            catch (DbUpdateException e)
            {
                return false;
            }
        }

        [HttpPost("update")]
        public bool updateOrder(Order order)
        {
            try
            {
                Order oldOrder = context.orders.Include("details").SingleOrDefault(o => o.orderId == order.orderId);
                if (oldOrder == null)
                {
                    throw new ArgumentException("Order not found!");
                }
                else
                {
                    oldOrder.details.AddRange(order.details);
                    for (int i = 0; i < oldOrder.details.Count; i++)
                    {
                        if (order.details.Contains(oldOrder.details[i]))
                        {
                            context.Entry(oldOrder.details[i]).State = EntityState.Added;
                        }
                        else
                        {
                            context.Entry(oldOrder.details[i]).State = EntityState.Deleted;
                        }
                    }
                    context.SaveChanges();
                    oldOrder.clientName = order.clientName;
                    context.Entry(oldOrder).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (DbUpdateException e)
            {
                return false;
            }
        }
    }
}
