using System.Xml.Linq;

namespace XmlTool.Core.PointTypes;

public class DigitalInput : BacnetPoint
{
    public string ActiveText { get; set; }
    public string AlarmMessage { get; set; }
    // TODO parse enums from XML to reference in points
    // AlarmValue
    public string BACnetName { get; set; }
    public string DeviceType { get; set; }
    public int EventEnable { get; set; }
    public string FaultMessage { get; set; }
    public string ForeignAddress { get; set; }
    public string InactiveText { get; set; }
    public int NotifyType { get; set; }
    public int Polarity { get; set; }
    public string ResetMessage { get; set; }
    public int TimeDelay { get; set; }
    //Value

    public DigitalInput(XElement pointElement)
    {
        ActiveText = pointElement.Element("ActiveText")?.Value;
        AlarmMessage = pointElement.Element("AlarmMessage")?.Value;
        BACnetName = pointElement.Element("BACnetName")?.Value;
        DeviceType = pointElement.Element("DeviceType")?.Value;
        EventEnable = int.Parse(pointElement.Element("EventEnable")?.Value);
        FaultMessage = pointElement.Element("FaultMessage")?.Value;
        ForeignAddress = pointElement.Element("ForeignAddress")?.Value;
        InactiveText = pointElement.Element("InactiveText")?.Value;
        NotifyType = int.Parse(pointElement.Element("NotifyType")?.Value);
        Polarity = int.Parse(pointElement.Element("Polarity")?.Value);
        ResetMessage = pointElement.Element("ResetMessage")?.Value;
        TimeDelay = int.Parse(pointElement.Element("TimeDelay")?.Value);
    }
}