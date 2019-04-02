using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace OrderManager
{
    [Serializable]
    public class OrderDetails: Dictionary<string, int>, IXmlSerializable
    {
        public int totalPrice
        {
            get => this.Values.Sum();
        }

        public OrderDetails() { }

        public override string ToString()
        {
            string str = "";
            foreach (string key in this.Keys)
            {
                str += (key + ":" + this[key] + ";");
            }
            str = "(" + str + ")";
            return str;
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderDetails)
            {
                OrderDetails orderDetails = (OrderDetails)obj;
                if (this.ToString() == orderDetails.ToString())
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

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(string));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(int));
            reader.ReadStartElement();
            while(reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("OrderDetail");
                reader.ReadStartElement("merchandise");
                string key = (string) keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("amount");
                int value = (int) valueSerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadEndElement();
                this.Add(key, value);
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(string));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(int));
            foreach(var pair in this)
            {
                writer.WriteStartElement("OrderDetail");
                writer.WriteStartElement("merchandise");
                keySerializer.Serialize(writer, pair.Key);
                writer.WriteEndElement();
                writer.WriteStartElement("amount");
                valueSerializer.Serialize(writer, pair.Value);
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
        }
    }
}
