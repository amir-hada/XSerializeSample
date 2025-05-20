using System.Xml.Linq;
using System.Xml.Serialization;

namespace XSerializeSample;

[XmlSerializable]
public class Employee
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}