using Graph.Editor.Business.Interfaces;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Graph.Editor.Business.Shapes;

public class DrawableRectangle : IDrawableShape
{
    private Point? _startPoint;

    public UIElement Create(Point startPoint, Brush stroke)
    {
        Rectangle ellipse = new()
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
        if (shape is Rectangle rectangle)
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

            rectangle.Width = width;
            rectangle.Height = height;
        }
    }
}