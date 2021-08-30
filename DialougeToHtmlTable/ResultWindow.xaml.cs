using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DialougeToHtmlTable
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {
        
        public ResultWindow()
        {
            InitializeComponent();
        }

        private void ResultCopyButton_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(ResultTextBox.Document.ContentStart, ResultTextBox.Document.ContentEnd);
            Clipboard.SetText(textRange.Text);
        }

        private void ResultClearButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Document.Blocks.Clear();
        }
    }
}
