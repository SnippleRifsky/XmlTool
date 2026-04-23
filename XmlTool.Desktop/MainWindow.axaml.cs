using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;

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
            // Get top level from the current control. Alternatively, you can use Window reference instead.
            var topLevel = GetTopLevel(this);

            // Start async operation to open the dialog.
            if (topLevel == null) return;
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open Text File",
                AllowMultiple = false
            });

            if (files.Count != 1) return;
            // Open reading stream from the first file.
            await using var stream = await files[0].OpenReadAsync();
            using var streamReader = new StreamReader(stream);
            // Reads all the content of file as a text.
            var fileContent = await streamReader.ReadToEndAsync(); 
            _importDocument = XDocument.Parse(fileContent);

            var extractedObjectsElement = _importDocument.Root?.Element("ExportedObjects");
            var applicationElement = extractedObjectsElement?.Elements("OI")
                .Where(n => n.Attribute("NAME")
                                ?.Value ==
                            "Application");

            if (applicationElement != null) Console.WriteLine(applicationElement.Attributes().ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}