using System;
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
        private int numberOfColumns;
        private int numberOfRows;

        private List<TextBox> normaltextBoxList = new List<TextBox>();
        private List<TextBox> romajiTextBoxList = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DialogueWinGenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ColumnUpDown.Value != null && RowUpDown.Value != null)
            {
                PopulateTextBoxLists();
                InitializeDialougeWindow();
            }
        }

        private void InitializeDialougeWindow()
        {
            DialougueWindow dialougueWindow = new DialougueWindow(numberOfColumns, numberOfRows, RomajiCheckBox.IsChecked.Value, normaltextBoxList, romajiTextBoxList);

            for (int currentCol = 0; currentCol < numberOfColumns; currentCol++)
            {
                dialougueWindow.TextInputGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
            {
                dialougueWindow.TextInputGrid.RowDefinitions.Add(new RowDefinition());
            }

            if (RomajiCheckBox.IsChecked.Value)
            {
                for (int i = 0; i < normaltextBoxList.Count; i++)
                {
                    dialougueWindow.TextInputGrid.Children.Add(normaltextBoxList[i]);
                    dialougueWindow.TextInputGrid.Children.Add(romajiTextBoxList[i]);
                }
            }
            else
            {
                foreach (TextBox textBox in normaltextBoxList)
                {
                    dialougueWindow.TextInputGrid.Children.Add(textBox);
                }
            }

            dialougueWindow.Show();
        }

        private void PopulateTextBoxLists()
        {
            normaltextBoxList.Clear();
            romajiTextBoxList.Clear();

            numberOfColumns = (int)ColumnUpDown.Value;
            numberOfRows = (int)RowUpDown.Value;

            if (!RomajiCheckBox.IsChecked.Value) // If Normal TextBox
            {
                int i = 0;
                for (int currentRow = 0; currentRow < numberOfRows; currentRow++)
                {
                    for (int currentCol = 0; currentCol < numberOfColumns; currentCol++)
                    {
                        normaltextBoxList.Add(new TextBox());
                        Grid.SetRow(normaltextBoxList[i], currentRow);
                        Grid.SetColumn(normaltextBoxList[i], currentCol);

                        normaltextBoxList[i].FontFamily = new FontFamily("Consolas");
                        normaltextBoxList[i].FontSize = 16;
                        normaltextBoxList[i].TextWrapping = TextWrapping.Wrap;
                        normaltextBoxList[i].Margin = new Thickness(10);
                        normaltextBoxList[i].Padding = new Thickness(5, 5, 5, 5);
                        normaltextBoxList[i].BorderThickness = new Thickness(2);
                        normaltextBoxList[i].BorderBrush = new SolidColorBrush(Color.FromRgb(8, 178, 227));
                        normaltextBoxList[i].Background = new SolidColorBrush(Color.FromRgb(222, 247, 254));
                        normaltextBoxList[i].Foreground = new SolidColorBrush(Color.FromRgb(53, 53, 53));

                        i++;
                    }
                }
            }
            else // TextBox with Romaji Support
            {
                numberOfRows *= 2;

                int i = 0;
                for (int currentRow = 0; currentRow < numberOfRows; currentRow += 2)
                {
                    for (int currentCol = 0; currentCol < numberOfColumns; currentCol++)
                    {
                        // Creates a new normal TextBox
                        normaltextBoxList.Add(new TextBox());
                        Grid.SetRow(normaltextBoxList[i], currentRow);
                        Grid.SetColumn(normaltextBoxList[i], currentCol);

                        normaltextBoxList[i].FontFamily = new FontFamily("Consolas");
                        normaltextBoxList[i].FontSize = 16;
                        normaltextBoxList[i].TextWrapping = TextWrapping.Wrap;
                        normaltextBoxList[i].Margin = new Thickness(10, 10, 10, 0);
                        normaltextBoxList[i].Padding = new Thickness(5, 5, 5, 5);
                        normaltextBoxList[i].Background = new SolidColorBrush(Color.FromRgb(222, 247, 254));
                        normaltextBoxList[i].Foreground = new SolidColorBrush(Color.FromRgb(53, 53, 53));
                        normaltextBoxList[i].BorderBrush = new SolidColorBrush(Color.FromRgb(8, 178, 227));
                        normaltextBoxList[i].BorderThickness = new Thickness(2, 2, 2, 0.5);

                        // Creates a new romaji TextBox
                        romajiTextBoxList.Add(new TextBox());
                        Grid.SetRow(romajiTextBoxList[i], currentRow + 1);
                        Grid.SetColumn(romajiTextBoxList[i], currentCol);

                        normaltextBoxList[i].FontFamily = new FontFamily("Consolas");
                        romajiTextBoxList[i].FontSize = 16;
                        romajiTextBoxList[i].TextWrapping = TextWrapping.Wrap;
                        romajiTextBoxList[i].Margin = new Thickness(10, 0, 10, 10);
                        romajiTextBoxList[i].Padding = new Thickness(5, 5, 5, 5);
                        romajiTextBoxList[i].Background = new SolidColorBrush(Color.FromRgb(155, 231, 251));
                        romajiTextBoxList[i].Foreground = new SolidColorBrush(Color.FromRgb(53, 53, 53));
                        romajiTextBoxList[i].BorderBrush = new SolidColorBrush(Color.FromRgb(8, 178, 227));
                        romajiTextBoxList[i].BorderThickness = new Thickness(2, 0.5, 2, 2);

                        i++;
                    }
                }

                Log(i);
            }
        }

        private void Log(int input)
        {
            Debug.WriteLine($"Debug Log = {input}");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}