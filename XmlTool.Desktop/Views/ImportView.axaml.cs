using System;
using System.IO;
using System.Xml.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using XmlTool.Core;
using XmlTool.Desktop.ViewModels;

namespace XmlTool.Desktop.Views;

public partial class ImportView : UserControl
{
    public ImportView()
    {
        InitializeComponent();
    }
    
    private XDocument _importDocument = new XDocument();

    public async void OnLoadClick(object? sender, RoutedEventArgs evt)
    {
        try
        {
            var topLevel = TopLevel.GetTopLevel(this);
            
            if (topLevel == null) return;
            
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open Text File",
                AllowMultiple = false
            });

            if (files.Count != 1) return;
            
            await using var stream = await files[0].OpenReadAsync();
            using var streamReader = new StreamReader(stream);

            var fileContent = await streamReader.ReadToEndAsync();
            
            var deviceObject = GetDevice(XDocument.Parse(fileContent));
            
            
            if (DataContext is ImportViewModel vm)
            {
                vm.DeviceName = deviceObject.Name;
                vm.DeviceDescription = deviceObject.Description;
                vm.PointCount = deviceObject.DeviceApplication.BacnetPoints.Count;
                vm.PointsList = deviceObject.DeviceApplication.BacnetPoints;
                
                vm.AreaNames.Add(string.Empty);
            }
            SiteInfoPanel.IsVisible = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    private void OnAddAreaNameClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is ImportViewModel vm)
        {
            vm.AreaNames.Add(" ");
        }
    }

    private BacnetDevice GetDevice(XDocument document)
    {
        var exportedObjectsElement = document.Root?.Element("ExportedObjects");

        var deviceElement = ParseLib.GetElement(
            "OI", 
            "TYPE", 
            "bacnet.DeviceProxy", 
            exportedObjectsElement);
            
        return new BacnetDevice(deviceElement);
    }
}