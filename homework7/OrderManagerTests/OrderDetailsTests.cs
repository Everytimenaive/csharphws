using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Tests
{
    [TestClass()]
    public class OrderDetailsTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            OrderDetails obj = new OrderDetails();
            obj.Add("a", 1);
            string result = "(a:1;)";
            StringAssert.Equals(obj.ToString(), result);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            OrderDetails obj1 = new OrderDetails();
            OrderDetails obj2 = new OrderDetails();
            obj1.Add("a", 1);
            obj2.Add("a", 1);
            Assert.AreEqual(obj1, obj2);
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            OrderDetails obj = new OrderDetails();
            int result = obj.ToString().GetHashCode();
            Assert.AreEqual(obj.GetHashCode(), result);
        }
    }
}