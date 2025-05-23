using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;

namespace XSerializeSample;

[AttributeUsage(AttributeTargets.Class)]
public class XmlSerializableAttribute : TypeAspect
{
    [Introduce]
    public XElement Node = XElement.Parse($"<{meta.Target.Type}/>");
    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        foreach (var property in builder.Target.Properties)
        {
            builder.With( property ).Override( nameof(this.OverrideSetter) );
        }
        
    }
    [Template]
    public dynamic OverrideSetter
    {
        set
        {
            Node.SetAttributeValue(meta.Target.FieldOrProperty.Name, value);
            meta.Proceed();
        }
    }
    
    

}