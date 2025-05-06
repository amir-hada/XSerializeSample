using System;
using System.Xml.Linq;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;

namespace XSerializeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product { Title = "Milk", Price = "29000" };
            var order = new Order { ProductTitle = "Milk", ProductPrice = "29000" };
            
            dynamic pr = product;
            dynamic ordr = order;
            
            var xml = pr.Serialize();
            var xmlOrder = ordr.Serialize();
            
            var newProduct = pr.Deserialize(xml);
            var newOrder = ordr.Deserialize(xmlOrder);
                

            Console.WriteLine(xml);
            Console.WriteLine(xmlOrder);

            Console.WriteLine(newProduct);
            Console.WriteLine(newOrder);
            
            Console.WriteLine(product.Title);
            Console.WriteLine(product.Price);
            
            Console.WriteLine(order.ProductPrice);
            Console.WriteLine(order.ProductTitle);

        }
    }
}