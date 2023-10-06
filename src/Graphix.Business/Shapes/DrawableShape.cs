using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Graphix.Business.Interfaces;

namespace Graphix.Business.Shapes;

public class DrawableShape<T> : IDrawableShape where T : Shape, new()
{
    private Point? _startPoint;

    public UIElement SetShapeElement(Point startPoint, Brush stroke)
    {
        T shape = new()
        {
            Stroke = stroke,
            StrokeThickness = 2
        };

        Canvas.SetTop(shape, startPoint.Y);
        Canvas.SetLeft(shape, startPoint.X);

        _startPoint = startPoint;

        return shape;
    }

    public void Draw(UIElement shape, Point currentPoint, Canvas canvas)
    {
        if (shape is T drawableShape)
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

            drawableShape.Width = width;
            drawableShape.Height = height;
        }
    }
}
