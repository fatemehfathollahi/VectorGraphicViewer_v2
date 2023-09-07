using System;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Model;

namespace VectorGraphicViewer.Services.Factory
{
    public class ShapeFactory : ShapeFactoryBase
    {
        public override IShapeFactory CreateShape(Graphic graphic)
        {
            switch (graphic.Type)
            {
                case "line":
                    return new Line(graphic.A, graphic.B, graphic.Color);
                case "circle":
                    return new Circle(graphic.Center, graphic.Radius, graphic.Filled, graphic.Color);
                case "triangle":
                    return new Triangle(graphic.A, graphic.B, graphic.C, graphic.Filled, graphic.Color);

                default:
                    throw new ArgumentException("Invalid shape type.");
            }
        }
    }
}