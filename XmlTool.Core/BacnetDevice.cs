using System.Xml.Linq;

namespace XmlTool.Core;

public class BacnetDevice
{
    public XElement? DeviceElement { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public DeviceProperties Properties { get; private set; }
    public DeviceApplication DeviceApplication { get; set; }

    public BacnetDevice(XElement deviceElement)
    {
        DeviceElement = deviceElement;
        Name = deviceElement.Attribute("NAME")?.Value;
        Description = deviceElement.Attribute("DESCR")?.Value;
        Properties = GetDeviceProperties(deviceElement);
        DeviceApplication = GetDeviceApplication(deviceElement);
    }
    
    private DeviceProperties GetDeviceProperties(XElement element)
    {
        return new DeviceProperties
        {
            ApduSegmentTimeout = ParseLib.ParseInt(element, "ApduSegmentTimeout"),
            ApduTimeout = ParseLib.ParseInt(element, "ApduTimeout"),
            AlignIntervals = ParseLib.ParseInt(element, "AlignIntervals"),
            BackupFailureTimeout = ParseLib.ParseInt(element, "BackupFailureTimeout"),
            BackupPreparationTime = ParseLib.ParseInt(element, "BackupPreparationTime"),
            IntervalOffset = ParseLib.ParseInt(element, "IntervalOffset"),
            Location = ParseLib.ParseString(element, "Location"),
            MaxInfoFrames = ParseLib.ParseInt(element, "MaxInfoFrames"),
            MaxMaster = ParseLib.ParseInt(element, "MaxMaster"),
            NumberOfApduRetries = ParseLib.ParseInt(element, "NumberOfApduRetries"),
            OnlinePollingType = ParseLib.ParseInt(element, "OnlinePollingType"),
            RestoreCompletionTime = ParseLib.ParseInt(element, "RestoreCompletionTime"),
            TimeSynchronizationInterval = ParseLib.ParseInt(element, "TimeSynchronizationInterval"),
            UtcOffset = ParseLib.ParseInt(element, "UtcOffset")
        };
    }

    private DeviceApplication GetDeviceApplication(XElement element)
    {
        var appElement = ParseLib.GetElement("OI", "NAME", "Application", element);
        return new DeviceApplication(appElement);
    }
}