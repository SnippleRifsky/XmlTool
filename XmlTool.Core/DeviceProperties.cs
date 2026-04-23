namespace XmlTool.Core;

public class DeviceProperties
{
    public int ApduSegmentTimeout { get; set; } = 10000;
    public int ApduTimeout { get; set; } = 10000;
    public int AlignIntervals { get; set; } = 0;
    public int BackupFailureTimeout { get; set; } = 120;
    public int BackupPreparationTime { get; set; } = 60;
    public int IntervalOffset { get; set; } = 0;
    public string Location { get; set; } = string.Empty;
    public int MaxInfoFrames { get; set; } = 20;
    public int MaxMaster { get; set; } = 127;
    public int NumberOfApduRetries { get; set; } = 4;
    public int OnlinePollingType { get; set; } = 0;
    public int RestoreCompletionTime { get; set; } = 600;
    public int TimeSynchronizationInterval { get; set; } = 0;
    public int UtcOffset { get; set; } = 360;
}