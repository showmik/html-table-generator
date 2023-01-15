using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace HtmlTableGenerator.ViewModel;

public partial class OutputViewModel : ObservableObject
{
    [ObservableProperty] private string outputText;

    public OutputViewModel()
    {
        outputText = string.Empty;
    }

    [RelayCommand]
    public void CopyResult()
    {
        Clipboard.SetText(OutputText);
    }

    [RelayCommand]
    public void ClearText()
    {
        OutputText = string.Empty;
    }

    [RelayCommand]
    public void SaveFile()
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        if (saveFileDialog.ShowDialog() == true)
        {
            string filePath = saveFileDialog.FileName;
            File.WriteAllText(filePath, OutputText);
        }
    }
}