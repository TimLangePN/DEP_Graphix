using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Graphix.Business.Factories;
using Graphix.Business.Interfaces;
using Graphix.Data.Models;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace Graphix.Business.Handlers.Events;

public class MouseEventHandler : IMouseEventHandler
{
    private Point? _startPoint;
    private IDrawableShape _drawableShape;
    private UIElement _shapeInstance;
    private readonly DrawState _state;

    public MouseEventHandler(DrawState state)
    {
        _state = state;
    }

    public void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (sender is not Canvas senderCanvas)
            return;
        if (e.LeftButton == MouseButtonState.Pressed && _shapeInstance == null)
        {
            // Mouse Down
            _startPoint = e.GetPosition(senderCanvas);

            _drawableShape = ShapeFactory.Create(_state.SelectedShape);

            if (_drawableShape != null)
            {
                _shapeInstance = _drawableShape.SetShapeElement(_startPoint.Value, _state.CurrentBrush);
                senderCanvas.Children.Add(_shapeInstance);
            }
        }
        else if (e.LeftButton == MouseButtonState.Pressed && _shapeInstance != null)
        {
            // Mouse Move
            var currentPoint = e.GetPosition(senderCanvas);
            _drawableShape.Draw(_shapeInstance, currentPoint, senderCanvas);
        }
        else if (e.LeftButton == MouseButtonState.Released && _shapeInstance != null)
        {
            // Mouse Up
            _startPoint = null;
            _drawableShape = null;
            _shapeInstance = null;
        }
    }

    public void OnMouseClick(object sender, MouseButtonEventArgs e)
    {
        if (sender is Canvas senderCanvas)
        {
            _state.CurrentPoint = e.GetPosition(senderCanvas);
        }
    }
}