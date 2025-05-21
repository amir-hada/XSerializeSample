using System.Xml.Linq;
using NUnit.Framework;
using Shouldly;
using XSerializeSample;

namespace UnitTest;

public class Test
{
    [Test]
    public void Product_Should_Serialize_Correctly()
    {
        var prod = new Product()
        {
            Title = "Milk",
            Price = "29000"
        };

        var stringXml = """
                        <Product>
                        <Title>Milk</Title>
                        <Price>29000</Price>
                        </Product>
                        """;

        var expectedXml = XElement.Parse(stringXml);
        
        prod._xElement.ToString().ShouldBe(expectedXml.ToString());
    }

    [Test]
    public void Order_Should_Serialize_Correctly()
    {
        var order = new Order()
        {
            ProductTitle = "Milk",
            ProductPrice = "29000"
        };

        var stringXml = """
                        <Order>
                        <ProductTitle>Milk</ProductTitle>
                        <ProductPrice>29000</ProductPrice>
                        </Order>
                        """;

        var expectedXml = XElement.Parse(stringXml);
        
        order._xElement.ToString().ShouldBe(expectedXml.ToString());
    }

    [Test]
    public void Employee_Should_Serialize_Correctly()
    {
        var emp = new Employee()
        {
            ID = "15",
            FirstName = "Reza",
            LastName = "Shakak"
        };

        var stringXml = """
                        <Employee>
                        <ID>15</ID>
                        <FirstName>Reza</FirstName>
                        <LastName>Shakak</LastName>
                        </Employee>
                        """;

        var expectedXml = XElement.Parse(stringXml);
        
        emp._xElement.ToString().ShouldBe(expectedXml.ToString());
    }

    [Test]
    public void Product_Should_DeSerialize_Correctly()
    {
        var stringXml = """
                        <Product>
                        <Title>Milk</Title>
                        <Price>29000</Price>
                        </Product>
                        """;

        var inputXElement = XElement.Parse(stringXml);
        
        var expectedProduct = new Product()
        {
            Title = "Milk",
            Price = "29000"
        };

        var product = new Product(inputXElement);
        
        product.Title.ShouldBe(expectedProduct.Title);
        product.Price.ShouldBe(expectedProduct.Price);
        
        


    }
    [Test]
    public void Order_Should_DeSerialize_Correctly()
    {
        var stringXml = """
                        <Order>
                        <ProductTitle>Milk</ProductTitle>
                        <ProductPrice>29000</ProductPrice>
                        </Order>
                        """;
        
        var inputXElement = XElement.Parse(stringXml);
        
        var expectedOrder = new Order()
        {
            ProductTitle = "Milk",
            ProductPrice = "29000"
        };

        var order = new Order(inputXElement);
        
        order.ProductTitle.ShouldBe(expectedOrder.ProductTitle);
        order.ProductPrice.ShouldBe(expectedOrder.ProductPrice);




    }
    [Test]
    public void Employee_Should_DeSerialize_Correctly()
    {
        var stringXml = """
                        <Employee ID="15">
                            <FirstName>Reza</FirstName>
                            <LastName>Shakak</LastName>
                        </Employee>
                        """;
        
        var inputXElement = XElement.Parse(stringXml);
        
        var expextedEmp = new Employee()
        {
            ID = "15",
            FirstName = "Reza",
            LastName = "Shakak"
        };

        var emp = new Employee(inputXElement);
        
        emp.ID.ShouldBe(expextedEmp.ID);
        emp.FirstName.ShouldBe(expextedEmp.FirstName);
        emp.LastName.ShouldBe(expextedEmp.LastName);
    }
}