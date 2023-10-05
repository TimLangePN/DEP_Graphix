using Graph.Editor.Business.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graph.Editor.Business.Shapes;

public class DrawableShape : IDrawableShape
{
    private Point? _startPoint;
    private string _selectedShape;

    public DrawableShape(string selectedShape) 
    {
        _selectedShape = selectedShape;
    }

    public UIElement Create(Point startPoint, Brush stroke)
    {
        Ellipse ellipse = new()
        {
            Stroke = stroke,
            StrokeThickness = 2
        };

        Canvas.SetTop(ellipse, startPoint.Y);
        Canvas.SetLeft(ellipse, startPoint.X);

        _startPoint = startPoint;

        return ellipse;
    }

    public void Draw(UIElement shape, Point currentPoint, Canvas canvas)
    {
        if (shape is Ellipse ellipse)
        {
            var width = currentPoint.X - _startPoint.Value.X;
            var height = currentPoint.Y - _startPoint.Value.Y;

            if (width < 0)
            {
                Canvas.SetLeft(shape, currentPoint.X);
                width = -width;
            }
            if (height < 0)
            {
                Canvas.SetTop(shape, currentPoint.Y);
                height = -height;
            }

            ellipse.Width = width;
            ellipse.Height = height;
        }
    }
}