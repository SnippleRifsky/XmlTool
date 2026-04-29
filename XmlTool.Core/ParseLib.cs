using System.Xml.Linq;

namespace XmlTool.Core;

public static class ParseLib
{
    public static int ParseInt(XElement? element, string attributeName)
    {
        var elementValue = element?.Attribute(attributeName)?.Value;
        return int.TryParse(elementValue, out var value) ? value : 0;
    }

    public static string ParseString(XElement? element, string attributeName)
    {
        var value = element?.Attribute(attributeName)?.Value;
        return value ?? "ERR";
    }

    public static XElement? GetElement(string elementName, string attribute, string indentifier, XElement? parentElement = null, XDocument? doc = null)
    {
        return doc == null
            ? parentElement?.Elements(elementName)
                .Single(n => n.Attribute(attribute)
                                 ?.Value ==
                             indentifier)
            : doc.Elements(elementName)
                .Single(n => n.Attribute(attribute)
                                 ?.Value ==
                             indentifier);
    }
    
    public static IEnumerable<XElement>? GetElements(string elementName, string attribute, string identifier, XElement? parentElement = null, XDocument? doc = null)
    {
        if (doc == null)
        {
            return parentElement?.Elements(elementName).Where(n => n.Attribute(attribute).Value.Contains(identifier));
        }
        return doc.Elements(elementName).Where(n => n.Attribute(attribute).Value.Contains(identifier));
    }

    public static XAttribute? GetProperty(XElement? parentElement, string property, string attribute)
    {
        var propertyElement = GetElement("PI", "Name", property, parentElement);
        return  propertyElement?.Attribute(attribute);
    }
}