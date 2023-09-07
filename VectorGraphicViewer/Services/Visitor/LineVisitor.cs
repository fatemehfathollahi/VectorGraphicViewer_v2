using System.Windows.Shapes;
using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Services.Visitor
{
    public class LineVisitor : ShapeVisitorBase
    {
        public LineVisitor(Line line)
        {
            Line = line;
        }
        public Line Line { get; set; }
        public override void Accept(IShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}