using System.Xml.Linq;

namespace XmlTool.Core.PointTypes;

public class AnalogValue : BacnetPoint
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
        AlarmMessage = pointElement.Element("AlarmMessage").Value;
        BACnetName = pointElement.Element("BACnetName").Value;
        COVIncrement = new COVIncrement
        {
            Unit = pointElement.Element("COVIncrementUnit").Value,
            Value = float.Parse(pointElement.Element("COVIncrementValue").Value)
        };
        Deadband = float.Parse(pointElement.Element("Deadband").Value);
        DeviceType = pointElement.Element("DeviceType").Value;
        EventEnable = int.Parse(pointElement.Element("EventEnable").Value);
        FaultMessage = pointElement.Element("FaultMessage").Value;
        ForeignAddress = pointElement.Element("ForeignAddress").Value;
        HighLimit = float.Parse(pointElement.Element("HighLimit").Value);
        LimitEnable = int.Parse(pointElement.Element("LimitEnable").Value);
        LowLimit = float.Parse(pointElement.Element("LowLimit").Value);
        MaxPresValue = new MaxPresValue()
        {
            Unit = pointElement.Element("MaxPresUnit").Value,
            Value = float.Parse(pointElement.Element("MaxPresValue").Value)
        };
        MinPresValue = new MinPresValue()
        {
            Unit = pointElement.Element("MinPresUnit").Value,
            Value = float.Parse(pointElement.Element("MinPresValue").Value)
        };
        NotifyTpe = int.Parse(pointElement.Element("NotifyTpe").Value);
        Priority1 = pointElement.Element("Priority1").Value;
        Priority2 = pointElement.Element("Priority2").Value;
        Priority3 = pointElement.Element("Priority3").Value;
        Priority4 = pointElement.Element("Priority4").Value;
        Priority5 = pointElement.Element("Priority5").Value;
        Priority6 = pointElement.Element("Priority6").Value;
        Priority7 = pointElement.Element("Priority7").Value;
        Priority8 = pointElement.Element("Priority8").Value;
        Priority9 = pointElement.Element("Priority9").Value;
        Priority10 = pointElement.Element("Priority10").Value;
        Priority11 = pointElement.Element("Priority11").Value;
        Priority12 = pointElement.Element("Priority12").Value;
        Priority13 = pointElement.Element("Priority13").Value;
        Priority14 = pointElement.Element("Priority14").Value;
        Priority15 = pointElement.Element("Priority15").Value;
        Priority16 = pointElement.Element("Priority16").Value;
        RelinquishDefault = new RelinquishDefault()
        {
            Unit = pointElement.Element("RelinquishDefaultUnit").Value,
            Value = float.Parse(pointElement.Element("RelinquishDefaultValue").Value)
        };
        ResetMessage = pointElement.Element("ResetMessage").Value;
        TimeDelay = int.Parse(pointElement.Element("TimeDelay").Value);
        Value = pointElement.Element("Value").Value;
    }
}

public record RelinquishDefault
{
    public string Unit { get; set; }
    public float Value { get; set; }
}