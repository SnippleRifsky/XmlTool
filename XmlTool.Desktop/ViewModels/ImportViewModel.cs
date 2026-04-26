using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using XmlTool.Core;

namespace XmlTool.Desktop.ViewModels;

public class ImportViewModel : INotifyPropertyChanged
{
    public string DeviceName { get; set; }
    public string DeviceDescription { get; set; }
    public int  PointCount { get; set; }
    
    public ObservableCollection<string> AreaNames { get; } = new();
    
    private ObservableCollection<BacnetPoint> _points = new();
    public ObservableCollection<BacnetPoint> PointsList

    {
        get => _points;
        set
        {
            _points = value;
            OnPropertyChanged(nameof(PointsList));
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}