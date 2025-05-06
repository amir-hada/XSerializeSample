using System.Xml.Serialization;

namespace XSerializeSample;

[XmlSerializable]
[XmlDeserialize]
public class Product
{
    [XmlElement]
    public string Title { get; set; }
    [XmlAttribute]
    public string Price { get; set; }
}