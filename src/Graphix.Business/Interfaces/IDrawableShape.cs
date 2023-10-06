using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Graphix.Business.Interfaces;

public interface IDrawableShape
{
    UIElement SetShapeElement(Point startPoint, Brush stroke);
    void Draw(UIElement shape, Point currentPoint, Canvas canvas);
}
