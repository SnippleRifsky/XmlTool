using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace XmlTool.Core;

public class DeviceApplication
{
    public XElement ApplicationElement { get; set; } = new XElement("UnknownApplication");
    public ApplicationContentType ContentType { get; set; } = new ApplicationContentType();
    public int UseContentTypeFromRule { get; set; } = 0;
    public ObservableCollection<BacnetPoint> BacnetPoints { get; set; } = [];

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

    private ObservableCollection<BacnetPoint> GetBacnetPoints(XElement element)
    {
        var pointsElements = ParseLib.GetElements(
            "OI","TYPE",
            "bacnet.pointproxy", 
            element);

        var pointsList = new ObservableCollection<BacnetPoint>();
        if (pointsElements != null)
            foreach (var pointElement in pointsElements)
            {
                pointsList.Add(new BacnetPoint
                {
                    Name = ParseLib.ParseString(pointElement, "NAME"),
                    Description = ParseLib.ParseString(pointElement, "DESCR"),
                    Type = ParseLib.ParseString(pointElement, "TYPE")
                });
            }

        return pointsList;
    }
}