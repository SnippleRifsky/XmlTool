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
    
    private int _selectedTabIndex;

    public int SelectedTabIndex
    {
        get => _selectedTabIndex;
        set
        {
            if (_selectedTabIndex == value)
                return;

            _selectedTabIndex = value;
            OnPropertyChanged(nameof(SelectedTabIndex));

            UpdateCurrentView();
        }
    }

    public MainViewModel()
    {
        SelectedTabIndex = 0; // Default to the first tab
        CurrentViewModel = new ImportViewModel(); // Default view model
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    private void UpdateCurrentView()
    {
        CurrentViewModel = SelectedTabIndex switch
        {
            0 => new ImportViewModel(),
            1 => new NamingViewModel(),
            2 => new ContentViewModel(),
            3 => new ExportViewModel(),
            _ => null
        };
    }
    
    public void Initialize()
    {
        SelectedTabIndex = 0;
        CurrentViewModel = new ImportViewModel();
    }
}