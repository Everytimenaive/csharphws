using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderWebAPI.Models
{
    public class OrderDB : DbContext
    {
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }

        public OrderDB(DbContextOptions<OrderDB> options): base(options)
        {

        }
    }
}
