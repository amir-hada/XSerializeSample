using System.Xml.Linq;
using XSerializeSample;

var emp = new Employee
{
    ID = 15,
    FirstName = "Ali",
    LastName = "Bolhasani"
};

Console.WriteLine(emp._xElement);

