using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Model;

namespace VectorGraphicViewer.Services
{
    public abstract class ShapeFactoryBase
    {
        public abstract IShapeFactory CreateShape(Graphic graphic);
    }
}