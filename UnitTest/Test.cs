using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;
using Shouldly;
using XSerializeSample;

namespace UnitTest;

public class Test
{
    [Test]
    public void ProductSerialize()
    {
        var prod = new Product()
        {
            Title = "Milk",
            Price = "29000"
        };

        var stringXml = """
                        <Product Title="Milk" Price="29000" />
                        """;
        
        prod.Node.ToString().ShouldBe(stringXml);
    }

    [Test]
    public void OrderSerialize()
    {
        var order = new Order()
        {
            ProductTitle = "Milk",
            ProductPrice = "29000"
        };

        var stringXml = """
                        <Order ProductTitle="Milk" ProductPrice="29000" />
                        """;
        
        order.Node.ToString().ShouldBe(stringXml);
    }
    
    [Test]
    public void ProductDeSerialize()
    {
        var stringXml = """
                        <Product Title="Milk" Price="29000" />
                        """;

        var inputXElement = XElement.Parse(stringXml);
        
        var product = new Product(inputXElement);
        
        product.Title.ShouldBe("Milk");
        product.Price.ShouldBe("29000");
        
    }
    [Test]
    public void OrderDeSerialize()
    {
        var stringXml = """
                        <Order ProductTitle="Milk" ProductPrice="29000" />
                        """;
        
        var inputXElement = XElement.Parse(stringXml);

        var order = new Order(inputXElement);
        
        order.ProductTitle.ShouldBe("Milk");
        order.ProductPrice.ShouldBe("29000");




    }
}