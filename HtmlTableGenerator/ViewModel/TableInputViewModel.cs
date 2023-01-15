using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HtmlTableGenerator.Model;
using HtmlTableGenerator.Services;
using HtmlTableGenerator.View;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;

namespace HtmlTableGenerator.ViewModel;

public partial class TableInputViewModel : ObservableObject
{
    private TableData _tableData;
    private OutputWindow? outputWindow;


    public TableInputViewModel()
    {
        _tableData = new TableData();
        WeakReferenceMessenger.Default.Register<TableData>(this, TableDataChanged);
    }

    [RelayCommand]
    public void GenerateTable()
    {
        string result = GeneratorTools.GenerateTable(_tableData);
        InitializeOutputWindow(result);
    }

    private void InitializeOutputWindow(string outputText)
    {
        if (outputWindow == null || !outputWindow.IsVisible)
        {
            outputWindow = new OutputWindow();
        }

        outputWindow.OutputRichTextBox.Document = new FlowDocument(new Paragraph(new Run(outputText)));
        outputWindow.Show();
        outputWindow.Topmost = true;
    }

    private void TableDataChanged(object recipient, TableData tableData)
    {
        _tableData = tableData;
    }
}