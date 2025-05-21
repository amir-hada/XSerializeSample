using System.Xml.Linq;
using System.Xml.Serialization;

namespace XSerializeSample;

[XmlDeserialize]
[XmlSerializable]
public class Employee
{
    [XmlAttribute]
    public string ID { get; set; }
    [XmlElement]

    public string FirstName { get; set; }
    [XmlElement]

    public string LastName { get; set; }
}