using System.Xml.Linq;
using System.Xml.Serialization;

namespace XSerializeSample;

public partial class Territory
{
    public XElement Node = XElement.Parse("<Territory></Territory>");

    [XmlAttribute]
    public string Name
    {
        get => Node.Attribute(nameof(Name))?.Value;
        set => Node.SetAttributeValue(nameof(Name), value);
    }

    [XmlAttribute]
    public string? Description
    {
        get => Node.Attribute(nameof(Description))?.Value;
        set => Node.SetAttributeValue(nameof(Description), value);
    }

    public Territory(XElement input)
    {
        Node = input;
    }
    
    public Territory()
    {
    }
}