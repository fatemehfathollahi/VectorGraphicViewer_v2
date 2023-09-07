using System.Windows.Shapes;
using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Services.Visitor
{
    public class CircleVisitor : ShapeVisitorBase
    {
        public CircleVisitor(Ellipse ellipse)
        {
            this.Ellipse = ellipse;
        }
        public Ellipse Ellipse { get; set; }
        public override void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}