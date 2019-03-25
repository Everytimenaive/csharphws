using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OrderManager
{
    class Program
    {
        /*
         * 命令格式：[add|query|update|remove|sort] [args]
         * add [客户名] [商品] [数量] [商品] [数量]...
         * query [id|client|merchandise] arg
         * update [id] [客户名] [商品] [数量] [商品] [数量]...
         * remove [id]
         * sort [id|price]
         */
        static void Main(string[] args)
        {
            OrderService os = new OrderService();
            string[] input, inputArgs;
            while (true)
            {
                Console.Write(">");
                input = Console.ReadLine().Split(' ');
                inputArgs = new string[input.Length-1];
                Array.Copy(input, 1, inputArgs, 0, inputArgs.Length);
                try
                {
                    MethodInfo method = os.GetType().GetMethod(input[0]);
                    method.Invoke(os, new Object[] { inputArgs });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    continue;
                }
            }
        }
    }
}
