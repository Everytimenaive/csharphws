using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;

namespace FactoryMethod
{
    class XMLUtil
    {
        public static string CONFIG_FILE_NAME = @"..\..\config.xml";    // Path when build in visual studio


        public static Object getBean()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(CONFIG_FILE_NAME);
                XmlNode node = document.GetElementsByTagName("className")[0];
                string className = "FactoryMethod." + node.InnerText;
                Assembly assembly = Assembly.GetExecutingAssembly();
                return assembly.CreateInstance(className);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
