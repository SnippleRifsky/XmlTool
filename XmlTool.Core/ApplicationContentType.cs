namespace XmlTool.Core;

public class ApplicationContentType
{
    public int DeltaFilter { get; set; } = 0;
    public int Locked { get; set; } = 1;
    public string Object { get; set; } = string.Empty;
    public int Retransmit { get; set; } = 0;
    public int TransferRate { get; set; } = 10;
}