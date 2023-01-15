using HtmlTableGenerator.ViewModel;
using System;
using System.Windows;

namespace HtmlTableGenerator.View;

public partial class OutputWindow : Window
{
    public OutputWindow()
    {
        InitializeComponent();
        DataContext = new OutputViewModel();
    }

    protected override void OnDeactivated(EventArgs e)
    {
        base.OnDeactivated(e);
        Topmost = false;
    }
}