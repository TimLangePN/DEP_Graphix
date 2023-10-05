using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Graph.Editor.Business.Interfaces;
using Graph.Editor.Business.Shapes;

namespace Graph.Editor.Business
{
    public class DrawEventHandler : IDrawEventHandler
    {
        public Point CurrentPoint { get; set; }
        
        public SolidColorBrush CurrentBrush { get; set; }
        
        public string SelectedShape { get; set; }

        private Point? startPoint = null;
        private IDrawableShape currentDrawableShape = null;
        private UIElement currentShapeInstance = null;

        public DrawEventHandler()
        {
            CurrentPoint = new Point();
            CurrentBrush = new SolidColorBrush(Colors.Black); // Default to Black
        }

        public void Handle(object sender, MouseEventArgs e)
        {
            if (sender is not Canvas senderCanvas)
                return;
            if (e.LeftButton == MouseButtonState.Pressed && currentShapeInstance == null)
            {
                // Mouse Down
                startPoint = e.GetPosition(senderCanvas);

                currentDrawableShape = new DrawableShape(SelectedShape);

                if (currentDrawableShape != null)
                {
                    currentShapeInstance = currentDrawableShape.Create(startPoint.Value, CurrentBrush);
                    senderCanvas.Children.Add(currentShapeInstance);
                }
            }
            else if (e.LeftButton == MouseButtonState.Pressed && currentShapeInstance != null)
            {
                // Mouse Move
                var currentPoint = e.GetPosition(senderCanvas);
                currentDrawableShape.Draw(currentShapeInstance, currentPoint, senderCanvas);
            }
            else if (e.LeftButton == MouseButtonState.Released && currentShapeInstance != null)
            {
                // Mouse Up
                startPoint = null;
                currentDrawableShape = null;
                currentShapeInstance = null;
            }
        }

        public void Initialize(object sender, MouseButtonEventArgs e)
        {
            if (sender is Canvas senderCanvas)
            {
                CurrentPoint = e.GetPosition(senderCanvas);
            }
        }
    }
}