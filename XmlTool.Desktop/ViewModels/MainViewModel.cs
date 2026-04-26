using System.ComponentModel;

namespace XmlTool.Desktop.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private object? _currentViewModel;

    public object? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            if (_currentViewModel == value)
                return;

            _currentViewModel = value;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }

    public MainViewModel()
    {
        CurrentViewModel = new ImportViewModel();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}