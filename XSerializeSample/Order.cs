using System.Xml.Serialization;

namespace XSerializeSample;

[XmlDeserialize]
[XmlSerializable]
public partial class Order
{
    public Order()
    {
    }

    [XmlElement]
    public string? ProductTitle { get; set; }
    [XmlElement]
    public string? ProductPrice { get; set; }
}