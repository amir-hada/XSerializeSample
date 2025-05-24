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
        
        prod._node.ToString().ShouldBe(expectedXml.ToString());
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
        
        order._node.ToString().ShouldBe(expectedXml.ToString());
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
        
        var product = new Product(inputXElement);
        
        product.Title.ShouldBe("Milk");
        product.Price.ShouldBe("29000");
        
        


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

        var order = new Order(inputXElement);
        
        order.ProductTitle.ShouldBe("Milk");
        order.ProductPrice.ShouldBe("29000");




    }
}