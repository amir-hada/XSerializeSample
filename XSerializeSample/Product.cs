using System.Xml.Serialization;

namespace XSerializeSample;

[XmlSerializable]
public class Product
{
    [XmlElement]
    public string Title { get; set; }
    [XmlAttribute]
    public decimal Price { get; set; }
}