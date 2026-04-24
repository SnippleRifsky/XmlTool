using System.Collections.Generic;
using XmlTool.Core;

namespace XmlTool.Desktop.ViewModels;

public class DeviceViewModel
{
    public string DeviceName { get; set; }
    public string DeviceDescription { get; set; }
    public int  PointCount { get; set; }
    public List<BacnetPoint> PointsList { get; set; }
}