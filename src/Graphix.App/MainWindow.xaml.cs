using System.Windows;
using Graphix.Business.Handlers;
using Graphix.Data.Models;

namespace Graphix.App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Handlers _handlers;
    private readonly DrawState _state;
    public MainWindow(Handlers handlers, DrawState state)
    {
        InitializeComponent();

        _handlers = handlers;
        _state = state;

        drawArea.MouseDown += _handlers.MouseHandler.OnMouseClick;
        drawArea.MouseMove += _handlers.MouseHandler.OnMouseMove;

        // Attach SelectionChanged event to ComboBox
        ShapesBox.SelectionChanged += _handlers.ShapeSelectionHandler.OnSelectionChanged;

        BrushColorBox.Click += _handlers.ColorEventHandler.OnColorChanged;
    }
}
