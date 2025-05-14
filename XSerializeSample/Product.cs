using System.Xml;
using System.Xml.Serialization;

namespace XSerializeSample;

[XmlDeserialize]
[XmlSerializable]
public class Product
{
    [XmlElement]
    public string Title { get; set; }
    [XmlAttribute]
    public string Price { get; set; }
    
}