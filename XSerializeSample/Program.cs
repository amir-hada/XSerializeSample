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
            var order = new Order { ProductTitle = "Milk", ProductPrice = "29000" };
            
            dynamic ordr = order;
            var xmlOrder = ordr.Serialize();
            order.ProductTitle = "Glass";
            ordr.Deserialize(xmlOrder);
            Console.WriteLine(order.ProductTitle);
            
            

        }
    }
}