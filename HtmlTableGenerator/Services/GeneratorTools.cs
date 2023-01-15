using HtmlTableGenerator.Model;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HtmlTableGenerator.Services;

internal class GeneratorTools
{
    public static string GenerateTable(TableData tableData)
    {
        StringBuilder sb = new StringBuilder();

        int i = 0;

        sb.Clear();
        sb.AppendLine("<table>");
        for (int currentRow = 0; currentRow < tableData.Row; currentRow++)
        {
            sb.AppendLine("<tr>");
            for (int currentCol = 0; currentCol < tableData.Column; currentCol++)
            {
                sb.Append("<td>");
                sb.Append(tableData.TextBoxlist[i].Text);
                sb.AppendLine($"</td>");
                i++;
            }
            sb.AppendLine($"</tr>");
        }
        sb.Append("</table>");
        return sb.ToString();
    }

    public static string GenerateTable(string[] csvContent)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<html>\n<body>\n<table>\n");

        foreach (string line in csvContent)
        {
            string[] cells = line.Split(',');

            sb.Append("<tr>\n");
            foreach (string cell in cells)
            {
                sb.Append("<td>").Append(cell).Append("</td>\n");
            }
            sb.Append("</tr>\n");
        }

        sb.Append("</table>\n</body>\n</html>");

        return sb.ToString();
    }

    public static void AdjustGrid(int rows, int columns, Grid grid)
    {
        for (int i = 0; i <= rows; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition());
        }

        for (int i = 0; i <= columns; i++)
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        grid.RowDefinitions[0].Height = new GridLength(30);
        grid.ColumnDefinitions[0].Width = new GridLength(50);

        grid.ShowGridLines = true;
    }

    public static void CreateHeaders(Grid grid, int rows, int columns)
    {
        char letter = (char)('A' - 1);
        for (int i = 0; i <= rows; i++)
        {
            for (int j = 0; j <= columns; j++)
            {
                var textBlock = new TextBlock();
                if (i == 0 && j != 0)
                {
                    textBlock.Text = letter.ToString();
                }
                else if (j == 0 && i != 0)
                {
                    textBlock.Text = i.ToString();
                }
                textBlock.SetResourceReference(FrameworkElement.StyleProperty, "TableHeaderStyle");
                Grid.SetRow(textBlock, i);
                Grid.SetColumn(textBlock, j);
                _ = grid.Children.Add(textBlock);
                letter++;
            }
        }
    }

    public static void CreateTextBoxes(Grid grid, TableData tableData)
    {
        for (int i = 1; i <= tableData.Row; i++)
        {
            for (int j = 1; j <= tableData.Column; j++)
            {
                var textBox = new TextBox();
                textBox.SetResourceReference(FrameworkElement.StyleProperty, i % 2 == 0 ? "TableCellStyle1" : "TableCellStyle2");
                Grid.SetRow(textBox, i);
                Grid.SetColumn(textBox, j);
                tableData.TextBoxlist.Add(textBox);
                _ = grid.Children.Add(textBox);
            }
        }
    }

    public static async Task<string[]?> ReadCsv(string filePath)
    {
        string[] strings;
        try
        {
            strings = await File.ReadAllLinesAsync(filePath);
        }
        catch (FileNotFoundException ex)
        {
            MessageBox.Show("Error: The file could not be found. " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }
        catch (ArgumentException)
        {
            MessageBox.Show("Error: Path cannot be empty. ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: An error occurred. " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return null;
        }
        return strings;
    }
}