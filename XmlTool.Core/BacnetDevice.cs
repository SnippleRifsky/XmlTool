namespace XmlTool.Core;

public class BacnetDevice
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DeviceProperties  Properties { get; set; } = new DeviceProperties();
    public DeviceApplication DeviceApplication { get; set; } = new DeviceApplication();
}