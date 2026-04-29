using System.Xml.Linq;

namespace XmlTool.Core.PointTypes;

public class MultistateValue : BacnetPoint
{
    public string AlarmMessage { get; set; }
    public string BACnetName { get; set; }
    public int EventEnable { get; set; }
    public string FaultMessage  { get; set; }
    public string ForeignAddress  { get; set; }
    public int NotifyType { get; set; }
    public int NumberOfStates { get; set; }
    public string Priority1 { get; set; }
    public string Priority2 { get; set; }
    public string Priority3 { get; set; }
    public string Priority4 { get; set; }
    public string Priority5 { get; set; }
    public string Priority6 { get; set; }
    public string Priority7 { get; set; }
    public string Priority8 { get; set; }
    public string Priority9 { get; set; }
    public string Priority10 { get; set; }
    public string Priority11 { get; set; }
    public string Priority12 { get; set; }
    public string Priority13 { get; set; }
    public string Priority14 { get; set; }
    public string Priority15 { get; set; }
    public string Priority16 { get; set; }
    public string RelinquishDefault { get; set; }
    public string ResetMessage { get; set; }
    public string StateText { get; set; }
    public int TimeDelay { get; set; }
    public string Value { get; set; }

    public MultistateValue(XElement?  pointElement)
    {
        AlarmMessage = ParseLib.GetProperty(pointElement, "AlarmMessage", "Value").Value;
        BACnetName = ParseLib.GetProperty(pointElement, "BACnetName", "Value").Value;
        EventEnable = int.Parse(ParseLib.GetProperty(pointElement, "EventEnable", "Value").Value);
        FaultMessage = ParseLib.GetProperty(pointElement, "FaultMessage", "Value").Value;
        ForeignAddress = ParseLib.GetProperty(pointElement, "ForeignAddress", "Value").Value;
        NotifyType = int.Parse(ParseLib.GetProperty(pointElement, "NotifyType", "Value").Value);
        NumberOfStates = int.Parse(ParseLib.GetProperty(pointElement, "NumberOfStates", "Value").Value);
        Priority1 = ParseLib.GetProperty(pointElement, "Priority1", "Type").Value;
        Priority2 = ParseLib.GetProperty(pointElement, "Priority2", "Type").Value;
        Priority3 = ParseLib.GetProperty(pointElement, "Priority3", "Type").Value;
        Priority4 = ParseLib.GetProperty(pointElement, "Priority4", "Type").Value;
        Priority5 = ParseLib.GetProperty(pointElement, "Priority5", "Type").Value;
        Priority6 = ParseLib.GetProperty(pointElement, "Priority6", "Type").Value;
        Priority7 = ParseLib.GetProperty(pointElement, "Priority7", "Type").Value;
        Priority8 = ParseLib.GetProperty(pointElement, "Priority8", "Type").Value;
        Priority9 = ParseLib.GetProperty(pointElement, "Priority9", "Type").Value;
        Priority10 = ParseLib.GetProperty(pointElement, "Priority10", "Type").Value;
        Priority11 = ParseLib.GetProperty(pointElement, "Priority11", "Type").Value;
        Priority12 = ParseLib.GetProperty(pointElement, "Priority12", "Type").Value;
        Priority13 = ParseLib.GetProperty(pointElement, "Priority13", "Type").Value;
        Priority14 = ParseLib.GetProperty(pointElement, "Priority14", "Type").Value;
        Priority15 = ParseLib.GetProperty(pointElement, "Priority15", "Type").Value;
        Priority16 = ParseLib.GetProperty(pointElement, "Priority16", "Type").Value;
        RelinquishDefault = ParseLib.GetProperty(pointElement, "RelinquishDefault", "Value").Value;
        StateText = ParseLib.GetProperty(pointElement, "StateText", "Value").Value;
        TimeDelay = int.Parse(ParseLib.GetProperty(pointElement, "TimeDelay", "Value").Value);
        Value = ParseLib.GetProperty(pointElement, "Value", "Type").Value;
    }
}