using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using Graphix.Business.Interfaces;
using Graphix.Business.Shapes;

namespace Graphix.Business.Factories;

public static class ShapeFactory
{
    private delegate IDrawableShape ShapeCreator();

    private static readonly Dictionary<string, ShapeCreator> shapeFactories = new()
    {
        { "Ellipse", () => new DrawableShape<Ellipse>() },
        { "Rectangle", () => new DrawableShape<Rectangle>() },
    };

    public static IDrawableShape Create(string shapeType)
    {
        if (shapeFactories.TryGetValue(shapeType, out var factory))
        {
            return factory();
        }

        throw new ArgumentException($"Shape type {shapeType} not supported.");
    }
}