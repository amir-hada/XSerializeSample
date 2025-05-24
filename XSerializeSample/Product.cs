using System.Xml;
using System.Xml.Serialization;

namespace XSerializeSample;

[XmlDeserialize]
[XmlSerializable]
public partial class Product
{
    public Product()
    {
    }

    [XmlAttribute]
    public string Title { get; set; }
    [XmlAttribute]
    public string Price { get; set; }
    
}