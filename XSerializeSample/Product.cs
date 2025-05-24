using System.Xml;
using System.Xml.Serialization;

namespace XSerializeSample;

[XmlDeserialize]
[XmlSerializable]
public partial class Product
{
    [XmlElement]
    public string Title { get; set; }
    [XmlElement]
    public string Price { get; set; }
    
}