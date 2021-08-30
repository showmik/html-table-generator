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
        private bool isRomajiEnabled;
        private int numberOfColumns;
        private int numberOfRows;
        private List<TextBox> normalTextBoxList = new List<TextBox>();
        private List<TextBox> romajiTextBoxList = new List<TextBox>();
        private StringBuilder stringBuilder = new StringBuilder();

        public DialougueWindow(int colNumber, int rowNumber, bool romajiChecked, List<TextBox> textBoxList, List<TextBox> romajiBoxList)
        {
            InitializeComponent();
            normalTextBoxList = textBoxList;
            romajiTextBoxList = romajiBoxList;
            numberOfColumns = colNumber;
            numberOfRows = rowNumber;
            isRomajiEnabled = romajiChecked;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isRomajiEnabled)
            {
                GenerateNormalTable();
            }
            else
            {
                GenerateTableWithRomaji();
            }
            ShowResultWindow();
        }

        private void GenerateNormalTable()
        {
            int i = 0;

            stringBuilder.Clear();
            stringBuilder.AppendLine("<table>");
            for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
            {
                stringBuilder.AppendLine("<tr>");
                for (int currentCol = 0; currentCol < numberOfColumns; currentCol++)
                {
                    stringBuilder.Append("<td>");
                    stringBuilder.Append(normalTextBoxList[i].Text);
                    stringBuilder.AppendLine($"</td>");
                    i++;
                }
                stringBuilder.AppendLine($"</tr>");
            }
            stringBuilder.Append("</table>");
        }

        private void GenerateTableWithRomaji()
        {
            int i = 0;

            stringBuilder.Clear();
            stringBuilder.AppendLine("<table>");
            for (int currentRow = 0; currentRow < numberOfRows; currentRow += 2)
            {
                stringBuilder.AppendLine("<tr>");
                for (int currentCol = 0; currentCol < numberOfColumns; currentCol++)
                {
                    stringBuilder.Append("<td>");
                    stringBuilder.Append(normalTextBoxList[i].Text);
                    stringBuilder.Append($"<br/>");
                    stringBuilder.Append(romajiTextBoxList[i].Text);
                    stringBuilder.AppendLine($"</td>");
                    i++;
                }
                stringBuilder.AppendLine($"</tr>");
            }
            stringBuilder.Append("</table>");
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
            //WindowState = WindowState.Minimized;
            Close();
        }
    }
}