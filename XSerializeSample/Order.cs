using System.Xml.Serialization;

namespace XSerializeSample;

[XmlDeserialize]
[XmlSerializable]
public class Order
{
    [XmlElement]
    public string? ProductTitle { get; set; }
    [XmlAttribute]
    public string? ProductPrice { get; set; }
}