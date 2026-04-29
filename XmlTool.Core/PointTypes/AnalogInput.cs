using System.Xml.Linq;

namespace XmlTool.Core.PointTypes;

public class AnalogInput : BacnetPoint
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
    public string ResetMessage { get; set; }
    public float Resolution { get; set; }
    public int TimeDelay { get; set; }
    public int UpdateInterval { get; set; }
    public string Value { get; set; }

    public AnalogInput(XElement pointElement)
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
        ResetMessage = ParseLib.GetProperty(pointElement, "ResetMessage", "Value").Value;
        Resolution = float.Parse(ParseLib.GetProperty(pointElement, "Resolution", "Value").Value);
        TimeDelay = int.Parse(ParseLib.GetProperty(pointElement, "TimeDelay", "Value").Value);
        UpdateInterval = int.Parse(ParseLib.GetProperty(pointElement, "UpdateInterval", "Value").Value);
        Value = ParseLib.GetProperty(pointElement, "Value", "Value").Value;
    }
}

public record COVIncrement
{
    public string Unit { get; set; }
    public float Value { get; set; }
}

public record MaxPresValue
{
    public string Unit { get; set; }
    public float Value { get; set; }
}
public record MinPresValue
{
    public string Unit { get; set; }
    public float Value { get; set; }
}