using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DialougeToHtmlTable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int numberOfColumns;
        private int numberOfRows;

        private List<TextBox> normaltextBoxList = new List<TextBox>();
        private List<TextBox> romajiTextBoxList = new List<TextBox>();

        private void DialogueWinGenBtn_Click(object sender, RoutedEventArgs e)
        {
            PopulateTextBoxLists();
            InitializeDialougeWindow();
        }

        private void InitializeDialougeWindow()
        {
            DialougueWindow dialougueWindow = new DialougueWindow(numberOfColumns, numberOfRows, normaltextBoxList);

            for (int currentCol = 0; currentCol < numberOfColumns; currentCol++)
            {
                dialougueWindow.TextInputGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
            {
                dialougueWindow.TextInputGrid.RowDefinitions.Add(new RowDefinition());
            }

            foreach (TextBox textBox in normaltextBoxList)
            {
                dialougueWindow.TextInputGrid.Children.Add(textBox);
                textBox.Text = textBox.Name;
            }
            dialougueWindow.Show();
        }

        private void PopulateTextBoxLists()
        {
            normaltextBoxList.Clear();
            numberOfColumns = (int)ColumnUpDown.Value;
            numberOfRows = (int)RowUpDown.Value;

            int i = 0;
            for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
            {
                for (int currentCol = 0; currentCol < numberOfColumns; currentCol++)
                {
                    normaltextBoxList.Add(new TextBox());
                    romajiTextBoxList.Add(new TextBox());

                    Grid.SetRow(normaltextBoxList[i], currentRow);
                    Grid.SetColumn(normaltextBoxList[i], currentCol);

                    normaltextBoxList[i].Name = $"TextBoxR{currentRow + 1}C{currentCol + 1}";
                    normaltextBoxList[i].Margin = new Thickness(8);
                    normaltextBoxList[i].TextWrapping = TextWrapping.Wrap;
                    normaltextBoxList[i].Background = Brushes.LightCyan;

                    i++;
                }
            }
        }

        private void Log(int input)
        {
            Debug.WriteLine($"Debug Log = {input} <--------");
        }
    }
}