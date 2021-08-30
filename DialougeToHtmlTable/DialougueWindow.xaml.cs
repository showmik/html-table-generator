using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace DialougeToHtmlTable
{
    /// <summary>
    /// Interaction logic for DialougueWindow.xaml
    /// </summary>
    public partial class DialougueWindow : Window
    {
        private List<TextBox> normaltextBoxList = new List<TextBox>();
        private int totalColumns;
        private int totalRows;

        private StringBuilder stringBuilder = new StringBuilder();

        public DialougueWindow(int colNumber, int rowNumber, List<TextBox> textBoxList)
        {
            InitializeComponent();
            normaltextBoxList = textBoxList;
            totalColumns = colNumber;
            totalRows = rowNumber;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GenerateTableHtmlText();
            ShowResultWindow();
        }

        private void GenerateTableHtmlText()
        {
            stringBuilder.Clear();
            stringBuilder.AppendLine("<table>");
            int i = 0;
            for (int currentRow = 0; currentRow < totalRows; currentRow++)
            {
                stringBuilder.AppendLine("<tr>");
                for (int currentCol = 0; currentCol < totalColumns; currentCol++)
                {
                    stringBuilder.Append("<td>");
                    stringBuilder.Append(normaltextBoxList[i].Text);
                    stringBuilder.AppendLine($"</td>");
                    i++;
                }
                stringBuilder.AppendLine($"</tr>");
                
            }
            stringBuilder.AppendLine("</table>");
        }

        private void ShowResultWindow()
        {
            FlowDocument myFlowDoc = new FlowDocument();
            Paragraph para = new Paragraph();
            para.Inlines.Add(new Run(stringBuilder.ToString()));
            myFlowDoc.Blocks.Add(para);

            ResultWindow resultWindow = new ResultWindow();
            resultWindow.ResultTextBox.Document = myFlowDoc;
            resultWindow.Show();
        }
    }
}