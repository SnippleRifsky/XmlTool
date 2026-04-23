namespace XmlTool.Core;

public class DeviceApplication
{
    public ApplicationContentType ContentType { get; set; } = new ApplicationContentType();
    public int UseContentTypeFromRule { get; set; } = 0;
    public List<BacnetPoint> BacnetPoints { get; set; } = [];
    
    public class ApplicationContentType
    {
        public int DeltaFilter { get; set; } = 0;
        public int Locked { get; set; } = 1;
        public string Object { get; set; } = string.Empty;
        public int Retransmit { get; set; } = 0;
        public int TransferRate { get; set; } = 10;
    }
    
}