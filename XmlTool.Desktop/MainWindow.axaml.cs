using Avalonia.Controls;
using XmlTool.Desktop.ViewModels;

namespace XmlTool.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    
        this.Loaded += (_, _) =>
        {
            if (DataContext is MainViewModel vm)
            {
                vm.Initialize();
            }
        };
    }
}