using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

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

        private void DialogueWinGenBtn_Click(object sender, RoutedEventArgs e)
        {
            int numberOfColumns = (int)ColumnUpDown.Value;
            int numberOfRows = (int)RowUpDown.Value;

            DialougueWindow dialougueWindow = new DialougueWindow();

            for (int currentCol = 0; currentCol < numberOfColumns; currentCol++)
            {
                dialougueWindow.TextInputGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
            {
                dialougueWindow.TextInputGrid.RowDefinitions.Add(new RowDefinition());
            }

            List<TextBox> normaltextBoxList = new List<TextBox>();
            List<TextBox> romajiTextBoxList = new List<TextBox>();

            int i = 0;
            for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
            {
                for (int currentCol = 0; currentCol < numberOfColumns; currentCol++)
                {
                    normaltextBoxList.Add(new TextBox());
                    romajiTextBoxList.Add(new TextBox());

                    Grid.SetRow(normaltextBoxList[i], currentRow);
                    Grid.SetColumn(normaltextBoxList[i], currentCol);
                    
                    i++;
                }
            }

            Debug.WriteLine($"RESULT = {i} <--------");

            foreach (TextBox textBox in normaltextBoxList)
            {
                dialougueWindow.TextInputGrid.Children.Add(textBox);
            }

            //for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
            //{
            //    for (int currentCol = 0; currentCol < numberOfColumns; currentCol++)
            //    {
            //        dialougueWindow.TextInputGrid.Children.Add(normaltextBoxList[]);
            //    }
            //}

            //dialougueWindow.TextInputGrid.Children.Add(textBox1);
            //dialougueWindow.TextInputGrid.Children.Add(textBox2);

            //Grid.SetColumn(textBox1, 0);
            //Grid.SetColumn(textBox2, 1);

            dialougueWindow.Show();
        }
    }
}