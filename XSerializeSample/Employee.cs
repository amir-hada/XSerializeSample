using System.Xml.Linq;

namespace XSerializeSample;

public class Employee
{
    public XElement EmployeeElement = XElement.Parse("<Employee></Employee>");

    private int _id;

    private string _lastName;

    private string _firstName;
    public int ID 
    {
        get => _id;
        set
        {
            EmployeeElement.SetElementValue(nameof(ID), value);
            _id = value;
        }
    }

    public string FirstName
    {
        get => _firstName;
        set
        {
            EmployeeElement.SetElementValue(nameof(FirstName), value);
            _firstName = value;
        }
    }

    public string LastName
    {
        get { return _lastName; }
        set
        {
            EmployeeElement.SetElementValue(nameof(LastName), value);
            _lastName = value;
        }
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