using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Graphix.Data.Models;

namespace Graphix.Business.Handlers.Events;

public class ColorEventHandler
{
    private readonly DrawState _state;

    public ColorEventHandler(DrawState state)
    {
        _state = state;
    }

    public void OnColorChanged(object sender, RoutedEventArgs e)
    {
        // SetShapeElement and open a new color dialog from Windows Forms.
        using ColorDialog colorDialog = new();
        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            _state.CurrentBrush = new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));
        }
    }
}
