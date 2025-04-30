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
            var product = new Product { Title = "Milk", Price = 29000 };
            dynamic pr = product;
            var runCOde = pr.Serialize();
            Console.WriteLine(pr.Serialize());

        }
    }
}