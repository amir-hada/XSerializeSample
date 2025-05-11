using System.Dynamic;
using System.Xml.Linq;
using System.Xml.Serialization;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Microsoft.VisualBasic.CompilerServices;

namespace XSerializeSample;

[AttributeUsage(AttributeTargets.Class)]
public class XmlDeserializeAttribute : TypeAspect
{
    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        builder.Advice.IntroduceMethod(
            builder.Target,
            nameof(DeserializeTemplate),
            buildMethod: options => 
            {
                options.Name = "Deserialize";
            });
    }
    
    [Template]
    public void DeserializeTemplate(XElement input)
    {
        var type = meta.Target.Type;
        
        foreach (var property in type.Properties)
        {
            if (property.Attributes.OfAttributeType(typeof(XmlElementAttribute)).Any())
            {
                var element = input.Element(property.Name);
                property.Value = element?.Value;

            }
            else if (property.Attributes.OfAttributeType(typeof(XmlAttributeAttribute)).Any())
            {
                var attribute = input.Attribute(property.Name);
                property.Value = attribute?.Value;
            }
        }

        meta.Proceed();

    }
    
}