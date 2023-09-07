namespace VectorGraphicViewer.Contract
{
    public abstract class ShapeVisitorBase
    {
        public abstract void Accept(IShapeVisitor visitor);
    }
}