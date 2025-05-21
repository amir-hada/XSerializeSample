using System.Xml.Serialization;

namespace XSerializeSample;

[XmlDeserialize]
[XmlSerializable]
public class Order
{
    [XmlElement]
    public string? ProductTitle { get; set; }
    [XmlElement]
    public string? ProductPrice { get; set; }
}