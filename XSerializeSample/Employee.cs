using System.Net.Http.Headers;
using System.Xml.Linq;

namespace XSerializeSample;

public  partial class Employee
{
    public XElement Node = XElement.Parse("<Employee></Employee>");

    private Territory _territory = new();
    
    public int ID
    {
        get => Convert.ToInt32(Node.Element(nameof(ID)).Value);
        set => Node.SetAttributeValue(nameof(ID), value);
    }

    public string? FirstName
    {
        get => Node.Attribute(nameof(FirstName))?.Value;
        set => Node.SetAttributeValue(nameof(FirstName), value);
    }

    public string? LastName
    {
        get => Node.Attribute(nameof(LastName))?.Value;
        set => Node.SetAttributeValue(nameof(LastName), value);
    }

    public Territory? Territory
    {
        get => new(Node.Element("Territory"));
        set
        {
            Node.Element(nameof(Territory))?.Remove();

            if (value != null)
            {
                _territory = value;
                Node.Add(value.Node);
            }
        }
    }

    public Employee()
    {
    }

    public Employee(XElement input)
    {
        Node = input;
    }
}