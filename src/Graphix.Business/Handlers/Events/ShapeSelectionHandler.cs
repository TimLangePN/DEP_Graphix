using System.Windows.Controls;
using Graphix.Data.Models;

namespace Graphix.Business.Handlers.Events;

public class ShapeSelectionHandler
{
    private readonly DrawState _state;

    public ShapeSelectionHandler(DrawState state)
    {
        _state = state;
    }

    public void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox shapesBox && shapesBox.SelectedItem is ComboBoxItem selectedItem)
        {
            _state.SelectedShape = selectedItem.Content.ToString();
        }
    }
}
