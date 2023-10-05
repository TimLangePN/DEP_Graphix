using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Forms;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using Graph.Editor.Business;
using System.Windows.Controls;

namespace Graph.Editor.App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DrawEventHandler drawHandler;

    public MainWindow()
    {
        InitializeComponent();

        drawHandler = new DrawEventHandler();

        drawArea.MouseMove += drawHandler.Handle;
        drawArea.MouseDown += drawHandler.Initialize;

        // Attach SelectionChanged event to ComboBox
        ShapesBox.SelectionChanged += ShapesBox_SelectionChanged;
    }

    private void ChanceBrushColorEvent(object sender, RoutedEventArgs e)
    {
        // Create and open a new color dialog from Windows Forms.
        using ColorDialog colorDialog = new();
        if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            drawHandler.CurrentBrush = new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B));
        }
    }

    private void ShapesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ShapesBox.SelectedItem is ComboBoxItem selectedItem)
        {
            drawHandler.SelectedShape = selectedItem.Content.ToString();
        }
    }
}
