using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;

namespace XSerializeSample;

[AttributeUsage(AttributeTargets.Class)]
public class XmlSerializableAttribute : TypeAspect
{
    [Introduce]
    public XElement _xElement = XElement.Parse($"<{meta.Target.Type}></{meta.Target.Type}>");
    public override void BuildAspect(IAspectBuilder<INamedType> builder)
    {
        foreach (var property in builder.Target.Properties)
        {
            builder.Advice.OverrideAccessors(
                property,
                null,
                nameof(OverrideSetter));
        }
        
    }
    [Template]
    public void OverrideSetter()
    {
        //_xElement.SetElementValue(meta.Target.FieldOrProperty.Name, value);
        meta.InsertStatement($"_xElement.SetElementValue(\"{meta.Target.FieldOrProperty.Name}\", value);");
        meta.Proceed();
    }
    

}