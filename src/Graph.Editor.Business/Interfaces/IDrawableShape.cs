using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Graph.Editor.Business.Interfaces;

public interface IDrawableShape
{
    UIElement Create(Point startPoint, Brush stroke);
    void Draw(UIElement shape, Point currentPoint, Canvas canvas);
}
