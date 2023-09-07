using System.Windows.Controls;

namespace VectorGraphicViewer.Contract
{
    public interface IShapeFactory
    {
        System.Windows.Shapes.Shape Draw(Canvas canvas, double zoomLevel = 1.0);
    }
}