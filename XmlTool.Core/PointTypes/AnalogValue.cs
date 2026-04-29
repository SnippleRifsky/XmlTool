using System.Xml.Linq;

namespace XmlTool.Core.PointTypes;

public class AnalogValue : BacnetPoint
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string AlarmMessage { get; set; }
    public string BACnetName { get; set; }
    public COVIncrement COVIncrement { get; set; }
    public float Deadband { get; set; }
    public string DeviceType { get; set; }
    public int EventEnable { get; set; }
    public string FaultMessage { get; set; }
    public string ForeignAddress { get; set; }
    public float HighLimit { get; set; }
    public int LimitEnable { get; set; }
    public float LowLimit { get; set; }
    public MaxPresValue MaxPresValue { get; set; }
    public MinPresValue MinPresValue { get; set; }
    public int NotifyTpe { get; set; }
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
    public RelinquishDefault RelinquishDefault { get; set; }
    public string ResetMessage { get; set; }
    public int TimeDelay { get; set; }
    public string Value { get; set; }

    public AnalogValue(XElement pointElement)
    {
        Name = ParseLib.ParseString(pointElement, "NAME");
        Description = ParseLib.ParseString(pointElement, "DESCR");
        Type = ParseLib.ParseString(pointElement, "TYPE");
        AlarmMessage = ParseLib.GetProperty(pointElement, "AlarmMessage", "Value").Value;
        BACnetName = ParseLib.GetProperty(pointElement, "BACnetName", "Value").Value;
        COVIncrement = new COVIncrement
        {
            Unit = ParseLib.GetProperty(pointElement, "COVIncrement", "Unit").Value,
            Value = float.Parse(ParseLib.GetProperty(pointElement, "COVIncrement", "Value").Value)
        };
        Deadband = float.Parse(ParseLib.GetProperty(pointElement,"Deadband", "Value").Value);
        DeviceType = ParseLib.GetProperty(pointElement, "DeviceType", "Value").Value;
        EventEnable = int.Parse(ParseLib.GetProperty(pointElement, "EventEnable", "Value").Value);
        FaultMessage = ParseLib.GetProperty(pointElement, "FaultMessage", "Value").Value;
        ForeignAddress = ParseLib.GetProperty(pointElement, "ForeignAddress", "Value").Value;
        HighLimit = float.Parse(ParseLib.GetProperty(pointElement, "HighLimit", "Value").Value);
        LimitEnable = int.Parse(ParseLib.GetProperty(pointElement, "LimitEnable", "Value").Value);
        LowLimit = float.Parse(ParseLib.GetProperty(pointElement, "LowLimit", "Value").Value);
        MaxPresValue = new MaxPresValue()
        {
            Unit = ParseLib.GetProperty(pointElement, "MaxPresValue", "Unit").Value,
            Value = float.Parse(ParseLib.GetProperty(pointElement, "MaxPresValue", "Value").Value)
        };
        MinPresValue = new MinPresValue()  
        {
            Unit = ParseLib.GetProperty(pointElement, "MinPresValue", "Unit").Value,
            Value = float.Parse(ParseLib.GetProperty(pointElement, "MinPresValue", "Value").Value)
        };
        NotifyTpe = int.Parse(ParseLib.GetProperty(pointElement, "NotifyType", "Value").Value);
        Priority1 = ParseLib.GetProperty(pointElement, "Priority1", "Value").Value;
        Priority2 = ParseLib.GetProperty(pointElement, "Priority2", "Value").Value;
        Priority3 = ParseLib.GetProperty(pointElement, "Priority3", "Value").Value;
        Priority4 = ParseLib.GetProperty(pointElement, "Priority4", "Value").Value;
        Priority5 = ParseLib.GetProperty(pointElement, "Priority5", "Value").Value;
        Priority6 = ParseLib.GetProperty(pointElement, "Priority6", "Value").Value;
        Priority7 = ParseLib.GetProperty(pointElement, "Priority7", "Value").Value;
        Priority8 = ParseLib.GetProperty(pointElement, "Priority8", "Value").Value;
        Priority9 = ParseLib.GetProperty(pointElement, "Priority9", "Value").Value;
        Priority10 = ParseLib.GetProperty(pointElement, "Priority10", "Value").Value;
        Priority11 = ParseLib.GetProperty(pointElement, "Priority11", "Value").Value;
        Priority12 = ParseLib.GetProperty(pointElement, "Priority12", "Value").Value;
        Priority13 = ParseLib.GetProperty(pointElement, "Priority13", "Value").Value;
        Priority14 = ParseLib.GetProperty(pointElement, "Priority14", "Value").Value;
        Priority15 = ParseLib.GetProperty(pointElement, "Priority15", "Value").Value;
        Priority16 = ParseLib.GetProperty(pointElement, "Priority16", "Value").Value;
        RelinquishDefault = new RelinquishDefault()
        {
            Unit = ParseLib.GetProperty(pointElement, "RelinquishDefault", "Unit").Value,
            Value = float.Parse(ParseLib.GetProperty(pointElement, "RelinquishDefault", "Value").Value)
        };
        ResetMessage = ParseLib.GetProperty(pointElement, "ResetMessage", "Value").Value;
        TimeDelay = int.Parse(ParseLib.GetProperty(pointElement, "TimeDelay", "Value").Value);
        Value = ParseLib.GetProperty(pointElement, "Value", "Value").Value;
    }
}

public record RelinquishDefault
{
    public string Unit { get; set; }
    public float Value { get; set; }
}