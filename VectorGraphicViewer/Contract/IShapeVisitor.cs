using VectorGraphicViewer.Services.Visitor;

namespace VectorGraphicViewer.Contract
{
    public interface IShapeVisitor
    {
        void Visit(CircleVisitor circle);
        void Visit(LineVisitor line);
        void Visit(TriangleVisitor triangle);
    }
}