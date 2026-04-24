using System.Xml.Linq;

namespace XmlTool.Core;

public class DeviceApplication
{
    public XElement ApplicationElement { get; set; } = new XElement("UnknownApplication");
    public ApplicationContentType ContentType { get; set; } = new ApplicationContentType();
    public int UseContentTypeFromRule { get; set; } = 0;
    public List<BacnetPoint> BacnetPoints { get; set; } = [];

    public DeviceApplication(XElement applicationElement)
    {
        ApplicationElement = applicationElement;
        ContentType = GetApplicationContentType(applicationElement);
        UseContentTypeFromRule = GetUseContentFromRule(applicationElement);
        BacnetPoints = GetBacnetPoints(applicationElement);
    }

    private ApplicationContentType GetApplicationContentType(XElement element)
    {
        var appContentTypeElement = ParseLib.GetElement("PI", "Name", "ContentType", element);
        var contentTypeRef = appContentTypeElement?.Element("Reference");

        return new ApplicationContentType
        {
            DeltaFilter = ParseLib.ParseInt(contentTypeRef, "DeltaFilter"),
            Locked = ParseLib.ParseInt(contentTypeRef, "Locked"),
            Object = ParseLib.ParseString(appContentTypeElement, "Object"),
            Retransmit = ParseLib.ParseInt(contentTypeRef, "Retransmit"),
            TransferRate = ParseLib.ParseInt(contentTypeRef, "TransferRate")
        };
    }

    private int GetUseContentFromRule(XElement element)
    {
        var typeFromRuleElement = ParseLib.GetElement("PI", "Name", "UseContentTypeFromRule", element);
        return ParseLib.ParseInt(typeFromRuleElement, "Value");
    }

    private List<BacnetPoint> GetBacnetPoints(XElement element)
    {
        var pointsElements = ParseLib.GetElements(
            "OI","TYPE",
            "bacnet.pointproxy", 
            element);

        var pointsList = new List<BacnetPoint>();
        if (pointsElements != null)
            pointsList.AddRange(pointsElements.Select(point => new BacnetPoint
            {
                Name = ParseLib.ParseString(point,
                    "NAME"),
                Description = ParseLib.ParseString(point,
                    "DESCR"),
                Type = ParseLib.ParseString(point,
                    "TYPE")
            }));
        return pointsList;
    }
}