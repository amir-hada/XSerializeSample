using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace XSerializeSample;

[AttributeUsage(AttributeTargets.Class)]
public class XmlSerializableAttribute : TypeAspect
{
    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        builder.Advice.IntroduceMethod(
            builder.Target,
            nameof(SerializeTemplate),
            buildMethod: options => 
            {
                options.Name = "Serialize";
            });
    }
        
    [Template]
    public XElement SerializeTemplate()
    {
        var type = meta.Target.Type;
        var xElement = new XElement(type.Name);

        foreach (var property in type.Properties)
        {
            if (property.Attributes.OfAttributeType(typeof(XmlElementAttribute)).Any())
            {
                var value = property.Value;
                xElement.Add(new XElement(property.Name, value));
            }
            else if (property.Attributes.OfAttributeType(typeof(XmlAttributeAttribute)).Any())
            {
                var value = property.Value;
                xElement.SetAttributeValue(property.Name, value);
            }
        }

        return xElement;
    }

}