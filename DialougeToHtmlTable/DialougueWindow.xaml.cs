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
    /// Interaction logic for DialougueWindow.xaml
    /// </summary>
    public partial class DialougueWindow : Window
    {
        List<TextBox> normaltextBoxList = new List<TextBox>();
        int totalColumns;
        int totalRows;

        public DialougueWindow(int colNumber, int rowNumber, List<TextBox> textBoxList)
        {
            InitializeComponent();
            normaltextBoxList = textBoxList;
            totalColumns = colNumber;
            totalRows = rowNumber;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
