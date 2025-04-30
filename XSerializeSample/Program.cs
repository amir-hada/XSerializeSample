using System;
using System.Xml.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace XSerializeSample
{
    public class Product
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }

    public class Globals<T>
    {
        public T obj;
    }

    public class RoslynSerializer
    {
        public static async Task<XElement> SerializeAsync<T>(T obj)
        {
            string fullScript = $@"
                using System;
                using System.Xml.Linq;

                public static class Serializer
                {{
                    public static XElement Serialize<T>(T obj)
                    {{
                        var type = typeof(T);
                        var element = new XElement(type.Name);
                        
                        foreach (var prop in type.GetProperties())
                        {{
                            element.Add(new XElement(prop.Name, prop.GetValue(obj)));
                        }}
                        
                        return element;
                    }}
                }}

                return Serializer.Serialize(obj);
            ";

            var scriptOptions = ScriptOptions.Default
                .AddReferences(typeof(object).Assembly, typeof(XElement).Assembly)
                .AddImports("System", "System.Xml.Linq");

            var result = await CSharpScript.EvaluateAsync<XElement>(
                fullScript,
                scriptOptions,
                globals: new Globals<T> { obj = obj }
            );

            return result;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var product = new Product
            {
                Title = "Milk",
                Price = 29000
            };

            Console.WriteLine("This is the XElement output of product:");
            var xml = await RoslynSerializer.SerializeAsync(product);
            Console.WriteLine(xml);
        }
    }
}
