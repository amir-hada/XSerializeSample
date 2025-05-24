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
        get => _territory;
        set
        {
            if (value == null)
            {
                _territory.Node.SetElementValue(nameof(Territory), null);
                return;
            }
            _territory = value;
            
            Node.Add(_territory.Node);
        }
    } 
    public Employee()
    {
    }

    public Employee(XElement input)
    {
        ID = Int32.Parse(input.Attribute("ID")?.Value);
        FirstName = input.Attribute("FirstName")?.Value;
        LastName = input.Attribute("LastName")?.Value;
        Territory = new Territory(input.Element("Territory"));
    }
}