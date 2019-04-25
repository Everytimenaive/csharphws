using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace OrderManager
{
    [Serializable]
    [DataContract]
    public class Order: IComparable, IXmlSerializable
    {
        [DataMember]
        public int orderId { get; set; }
        [DataMember]
        public string clientName { get; set; }
        [DataMember]
        public string detailsInfo
        {
            get => details.ToString();
        }
        [IgnoreDataMember]
        public OrderDetails details { get; set; }

        public Order() { }

        public Order(int orderId, string clientName)
        {
            this.orderId = orderId;
            this.clientName = clientName;
            details = new OrderDetails();
        }

        public override string ToString()
        {
            string str = orderId + " " + clientName + " " + details;
            return str;
        }

        public override bool Equals(object obj)
        {
            if (obj is Order)
            {
                Order order = (Order)obj;
                if (this.orderId == order.orderId || (this.clientName == order.clientName && this.clientName.Equals(order.details)))
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return orderId;
        }

        public int CompareTo(Object obj)
        {
            if (!(obj is Order))
            {
                throw new ArgumentException("Wrong argument type!");
            }
            return this.orderId - ((Order) obj).orderId;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XmlSerializer intSerializer = new XmlSerializer(typeof(int));
            XmlSerializer strSerializer = new XmlSerializer(typeof(string));
            reader.ReadStartElement();
            reader.ReadStartElement("orderId");
            orderId = (int) intSerializer.Deserialize(reader);
            reader.ReadEndElement();
            reader.ReadStartElement("clientName");
            clientName = (string) strSerializer.Deserialize(reader);
            reader.ReadEndElement();
            OrderDetails newDetails = new OrderDetails();
            ((IXmlSerializable ) newDetails).ReadXml(reader);
            details = newDetails;
            reader.ReadEndElement();
            reader.MoveToContent();
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer intSerializer = new XmlSerializer(typeof(int));
            XmlSerializer strSerializer = new XmlSerializer(typeof(string));
            writer.WriteStartElement("orderId");
            intSerializer.Serialize(writer, orderId);
            writer.WriteEndElement();
            writer.WriteStartElement("clientName");
            strSerializer.Serialize(writer, clientName);
            writer.WriteEndElement();
            writer.WriteStartElement("details");
            ((IXmlSerializable) details).WriteXml(writer);
            writer.WriteEndElement();
        }
    }
}
