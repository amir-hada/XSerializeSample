using System.Dynamic;
using System.Xml.Linq;
using System.Xml.Serialization;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

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
    public object? DeserializeTemplate(XElement input)
    {
        var type = meta.Target.Type;
        var newEntity = Activator.CreateInstance(meta.This.GetType());

        foreach (var property in type.Properties)
        {
            if (property.Attributes.OfAttributeType(typeof(XmlElementAttribute)).Any())
            {
                var element = input.Element(property.Name);
                //var value = Convert.ChangeType(element?.Value, property.GetType());
                property.Value = element?.Value;

            }
            else if (property.Attributes.OfAttributeType(typeof(XmlAttributeAttribute)).Any())
            {
                var attribute = input.Attribute(property.Name);
                //var value = Convert.ChangeType(attribute?.Value, property.GetType());
                property.Value = attribute?.Value;
            }
        }

        return newEntity;

    }
    
}