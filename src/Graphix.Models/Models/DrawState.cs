using System.Windows;
using System.Windows.Media;

namespace Graphix.Data.Models;

public class DrawState
{
    public Point CurrentPoint { get; set; }
    public SolidColorBrush CurrentBrush { get; set; }
    public string SelectedShape { get; set; }

    public DrawState()
    {
        CurrentPoint = new Point();
        CurrentBrush = new SolidColorBrush(Colors.Black); // Default to Black
    }
}
