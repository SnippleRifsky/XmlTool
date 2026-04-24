using System;
using System.IO;
using System.Xml.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using XmlTool.Core;

namespace XmlTool.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private XDocument _importDocument = new XDocument();

    public async void OnLoadClick(object? sender, RoutedEventArgs evt)
    {
        try
        {
            var topLevel = GetTopLevel(this);
            
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
            _importDocument = XDocument.Parse(fileContent);
            
            
            var exportedObjectsElement = _importDocument.Root?.Element("ExportedObjects");

            var deviceElement = ParseLib.GetElement(
                "OI", 
                "TYPE", 
                "bacnet.DeviceProxy", 
                exportedObjectsElement);
            var deviceObject = new BacnetDevice(deviceElement);
            var applicationObject = deviceObject.DeviceApplication;

            foreach (var point in applicationObject.BacnetPoints)
            {
                Console.WriteLine(point.Name);
            }
            Console.Write(applicationObject.BacnetPoints.Count);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}