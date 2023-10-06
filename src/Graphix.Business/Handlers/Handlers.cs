using Graphix.Business.Handlers.Events;

namespace Graphix.Business.Handlers;

public class Handlers
{
    public MouseEventHandler MouseHandler { get; }

    public ShapeSelectionHandler ShapeSelectionHandler { get; }

    public ColorEventHandler ColorEventHandler { get; }

    public Handlers(MouseEventHandler mouseHandler,
        ShapeSelectionHandler shapeSelectionHandler,
        ColorEventHandler colorEventHandler)
    {
        MouseHandler = mouseHandler;
        ShapeSelectionHandler = shapeSelectionHandler;
        ColorEventHandler = colorEventHandler;
    }
}
