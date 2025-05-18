using System.Xml.Linq;
using XSerializeSample;

var emp = new Employee
{
    ID = 15,
    FirstName = "Ali",
    LastName = "Bolhasani"
};

Console.WriteLine(emp.EmployeeElement);

var xElement = XElement.Parse("""
                              <Employee>
                              <ID>10</ID>
                              <FirstName>Amir</FirstName>
                              <LastName>Hadavand</LastName>
                              </Employee>
                              """);

var deserializeEmp = new Employee(xElement);

Console.WriteLine(deserializeEmp.ID);
Console.WriteLine(deserializeEmp.FirstName);
Console.WriteLine(deserializeEmp.LastName);
