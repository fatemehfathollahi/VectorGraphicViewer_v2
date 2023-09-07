using System.Windows.Shapes;
using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Services.Visitor
{
    public class TriangleVisitor : ShapeVisitorBase
    {
        public TriangleVisitor(Polygon triangle)
        {
            Triangle = triangle;
        }
        public Polygon Triangle { get; set; }
        public override void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}