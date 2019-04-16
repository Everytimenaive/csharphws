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
    public class OrderTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Order obj = new Order(1, "c1");
            string result = "1 c1 (a:100;)";
            obj.details.Add("a", 100);
            StringAssert.Equals(obj.ToString(), result);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Order obj1 = new Order(1, "c1");
            Order obj2 = new Order(1, "c1");
            Assert.AreEqual(obj1, obj2);
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Order obj = new Order(1, "c");
            int result = 1;
            Assert.AreEqual(obj.GetHashCode(), result);
        }

        [TestMethod()]
        public void CompareToTest()
        {
            Order obj1 = new Order(1, "c1");
            Order obj2 = new Order(2, "c1");
            int result = 1;
            Assert.AreEqual(obj2.CompareTo(obj1), result);
        }
    }
}