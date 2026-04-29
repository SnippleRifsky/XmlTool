using System.Xml.Linq;

namespace XmlTool.Core.PointTypes;

public class AnalogInput : BacnetPoint
{
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
        AlarmMessage = pointElement.Attribute("AlarmMessage")?.Value;
        BACnetName = pointElement.Attribute("BACnetName")?.Value;
        COVIncrement = new COVIncrement
        {
            Unit = pointElement.Attribute("COVIncrementUnit")?.Value,
            Value = float.Parse(pointElement.Attribute("COVIncrementValue")?.Value)
        };
        Deadband = float.Parse(pointElement.Attribute("Deadband")?.Value);
        DeviceType = pointElement.Attribute("DeviceType")?.Value;
        EventEnable = int.Parse(pointElement.Attribute("EventEnable")?.Value);
        FaultMessage = pointElement.Attribute("FaultMessage")?.Value;
        ForeignAddress = pointElement.Attribute("ForeignAddress")?.Value;
        HighLimit = float.Parse(pointElement.Attribute("HighLimit")?.Value);
        LimitEnable = int.Parse(pointElement.Attribute("LimitEnable")?.Value);
        LowLimit = float.Parse(pointElement.Attribute("LowLimit")?.Value);
        MaxPresValue = new MaxPresValue()
        {
            Unit = pointElement.Attribute("MaxPresUnit")?.Value,
            Value = float.Parse(pointElement.Attribute("MaxPresValue")?.Value)
        };
        MinPresValue = new MinPresValue()  
        {
            Unit = pointElement.Attribute("MinPresUnit")?.Value,
            Value = float.Parse(pointElement.Attribute("MinPresValue")?.Value)
        };
        NotifyTpe = int.Parse(pointElement.Attribute("NotifyTpe")?.Value);
        ResetMessage = pointElement.Attribute("ResetMessage")?.Value;
        Resolution = float.Parse(pointElement.Attribute("Resolution")?.Value);
        TimeDelay = int.Parse(pointElement.Attribute("TimeDelay")?.Value);
        UpdateInterval = int.Parse(pointElement.Attribute("UpdateInterval")?.Value);
        Value = pointElement.Attribute("Value")?.Value;
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