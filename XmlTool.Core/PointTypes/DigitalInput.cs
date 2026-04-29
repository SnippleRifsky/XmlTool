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
        ActiveText = ParseLib.GetProperty(pointElement, "ActiveText", "Value").Value;
        AlarmMessage = ParseLib.GetProperty(pointElement, "AlarmMessage", "Value").Value;
        BACnetName = ParseLib.GetProperty(pointElement, "BACnetName", "Value").Value;
        DeviceType = ParseLib.GetProperty(pointElement, "DeviceType", "Value").Value;
        EventEnable = int.Parse(ParseLib.GetProperty(pointElement, "EventEnable", "Value").Value);
        FaultMessage = ParseLib.GetProperty(pointElement, "FaultMessage", "Value").Value;
        ForeignAddress = ParseLib.GetProperty(pointElement, "ForeignAddress", "Value").Value;
        InactiveText = ParseLib.GetProperty(pointElement, "InactiveText", "Value").Value;
        NotifyType = int.Parse(ParseLib.GetProperty(pointElement, "NotifyType", "Value").Value);
        Polarity = int.Parse(ParseLib.GetProperty(pointElement, "Polarity", "Value").Value);
        ResetMessage = ParseLib.GetProperty(pointElement, "ResetMessage", "Value").Value;
        TimeDelay = int.Parse(ParseLib.GetProperty(pointElement, "TimeDelay", "Value").Value);
    }
}