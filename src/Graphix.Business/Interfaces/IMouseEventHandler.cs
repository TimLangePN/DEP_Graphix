using System.Windows.Input;

namespace Graphix.Business.Interfaces;

public interface IMouseEventHandler
{
    void OnMouseMove(object sender, MouseEventArgs e);

    void OnMouseClick(object sender, MouseButtonEventArgs e);
}
