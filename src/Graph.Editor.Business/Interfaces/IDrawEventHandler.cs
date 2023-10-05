using System.Windows.Media;
using System.Windows.Input;
using System.Windows;

namespace Graph.Editor.Business.Interfaces
{
    public interface IDrawEventHandler
    {
        SolidColorBrush CurrentBrush { get; set; }

        Point CurrentPoint { get; set; }

        void Handle(object sender, MouseEventArgs e);

        void Initialize(object sender, MouseButtonEventArgs e);
    }
}
