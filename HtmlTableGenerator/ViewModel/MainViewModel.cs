using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HtmlTableGenerator.Model;
using HtmlTableGenerator.Services;
using HtmlTableGenerator.View;
using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Windows.Documents;

namespace HtmlTableGenerator.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private string filePath;
    [ObservableProperty] private string rowText;
    [ObservableProperty] private string columnText;
    [ObservableProperty] private bool csvEnabled;

    private OutputWindow? outputWindow;
    private TableData tableData;
    private string[]? csvContent;

    public MainViewModel()
    {
        rowText = "0";
        columnText = "0";
        filePath = string.Empty;
        tableData = new TableData();
    }

    [RelayCommand]
    private void OpenFile()
    {
        FileDialog fileDialog = new OpenFileDialog();
        fileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
        fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        if (fileDialog.ShowDialog() == true)
        {
            FilePath = fileDialog.FileName;
        }
    }

    [RelayCommand]
    public void GenerateButton()
    {
        if (CsvEnabled) { ProcessCsvContent(); }
        else { ProcessTableContent(); }
    }

    private async void ProcessCsvContent()
    {
        csvContent = await GeneratorTools.ReadCsv(FilePath);

        if (csvContent != null)
        {
            string result = GeneratorTools.GenerateTable(csvContent);

            if (outputWindow == null || !outputWindow.IsVisible)
            {
                outputWindow = new OutputWindow();
            }
            outputWindow.OutputRichTextBox.Document = new FlowDocument(new Paragraph(new Run(result)));
            outputWindow.Show();
            outputWindow.Topmost = true;
        }
    }

    private void ProcessTableContent()
    {
        TableInputWindow tableInputWindow = new();
        int row = int.Parse(RowText);
        int column = int.Parse(ColumnText);
        tableData.Row = row;
        tableData.Column = column;
        Grid grid = tableInputWindow.TableGrid;

        GeneratorTools.AdjustGrid(row, column, grid);
        GeneratorTools.CreateHeaders(grid, row, column);
        GeneratorTools.CreateTextBoxes(grid, tableData);
        SendTableData(tableData);
        tableInputWindow.Show();
    }

    private void SendTableData(TableData tableData) => WeakReferenceMessenger.Default.Send(tableData);
}