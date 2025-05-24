using System.Xml.Linq;
using NUnit.Framework;
using Shouldly;
using XSerializeSample;

namespace UnitTest;

public class EmployeeTest
{
    [Test]
    public void EmployeeComplexSerialize()
    {
        var emp = new Employee()
        {
            FirstName = "Ali",
            LastName = "Bolhasani",
            Territory = new()
            {
                Name = "Andishe",
                Description = "Shahriar"
            }
        };
        emp.FirstName = "Saeid";
        emp.Territory.Name = "SattarKhan";
        
        emp.Node.Attribute("FirstName").Value.ShouldBe("Saeid");
        emp.Node.Element("Territory").Attribute("Name").Value.ShouldBe("SattarKhan");
    }

    [Test]
    public void EmployeeComplexDeserialize()
    {
        var xml = """
                  <Employee FirstName="Ali" ID="5">
                  <Territory Name="Andishe"></Territory>
                  </Employee>
                  """;

        var emp = new Employee(XElement.Parse(xml));

        emp.Node.Attribute("FirstName").Value.ShouldBe("Ali");
        emp.Node.Element("Territory").Attribute("Name").Value.ShouldBe("Andishe");
    }
}