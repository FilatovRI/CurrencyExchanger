using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CurrencyExchanger.XMLModels
{
    [XmlRoot(ElementName = "Item")]
    public class Item
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "EngName")]
        public string EngName { get; set; }
        [XmlElement(ElementName = "Nominal")]
        public int Nominal { get; set; }
        [XmlElement(ElementName = "ParentCode")]
        public string ParentCode { get; set; }
        [XmlElement(ElementName = "ISO_Num_Code")]
        public string ISO_Num_Code { get; set; }
        [XmlElement(ElementName = "ISO_Char_Code")]
        public string ISO_Char_Code { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
    }

    [XmlRoot(ElementName = "Valuta")]
    public class Valuta
    {
        [XmlElement(ElementName = "Item")]
        public List<Item> Item { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}
