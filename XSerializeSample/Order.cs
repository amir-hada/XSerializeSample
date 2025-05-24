using System.Xml.Serialization;

namespace XSerializeSample;

[XmlDeserialize]
[XmlSerializable]
public partial class Order
{
    public Order()
    {
    }

    [XmlAttribute]
    public string? ProductTitle { get; set; }
    [XmlAttribute]
    public string? ProductPrice { get; set; }
}