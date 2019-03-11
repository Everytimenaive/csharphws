using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleFactory
{
    class XMLUtil
    {
        public static string CONFIG_FILE_NAME = @"..\..\config.xml";    // Path when build in visual studio


        public static String getBrandName()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(CONFIG_FILE_NAME);
                XmlNode node = document.GetElementsByTagName("brandName")[0];
                return node.InnerText;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
