using System.Xml.Linq;
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
        var element = new XElement(type.Name);

        foreach (var property in type.Properties)
        {
            var value = property.Value; 
            element.Add(new XElement(property.Name, value));
        }

        return element;
    }
}