using System.Xml.Linq;

namespace XSerializeSample;

public  partial class Employee
{
    public XElement Node = XElement.Parse("<Employee></Employee>");
    public int ID
    {
        get => Convert.ToInt32(Node.Element(nameof(ID)).Value);
        set => Node.SetElementValue(nameof(ID), value);
    }

    public string? FirstName
    {
        get => Node.Element(nameof(FirstName))?.Value;
        set => Node.SetElementValue(nameof(FirstName), value);
    }

    public string? LastName
    {
        get => Node.Element(nameof(LastName))?.Value;
        set => Node.SetElementValue(nameof(LastName), value);
    }

    public Employee()
    {
    }

    public Employee(XElement input)
    {
        ID = Int32.Parse(input.Element("ID").Value);
        FirstName = input.Element("FirstName").Value;
        LastName = input.Element("LastName").Value;
    }
}