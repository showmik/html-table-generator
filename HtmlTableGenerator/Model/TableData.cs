using System.Collections.Generic;
using System.Windows.Controls;

namespace HtmlTableGenerator.Model;

public class TableData
{
    public int Row { get; set; }
    public int Column { get; set; }
    public List<TextBox> TextBoxlist { get; set; }

    public TableData()
    {
        TextBoxlist = new List<TextBox>();
    }
}