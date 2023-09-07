using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Model
{
    public class Circle : VectorGraphicViewer.Contract.Shape, IShapeFactory
    {
        public Point Center { get; private set; }
        public double Radius { get; private set; }
        public bool? Filled { get; private set; }

        public Circle(Point center, double radius, bool? filled, Color color)
        {
            Center = center;
            Radius = radius;
            Filled = filled;
            Color = color;
        }

        public System.Windows.Shapes.Shape Draw(Canvas canvas, double zoomLevel = 1.0)
        {
            double diameter = 2 * Radius;
            if (diameter >= 100)
                zoomLevel = diameter / 100;
            var circle = new System.Windows.Shapes.Ellipse
            {
                Width = diameter * zoomLevel,
                Height = diameter * zoomLevel,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1
            };

            if (Filled == true)
            {
                circle.Fill = new SolidColorBrush(Color);
            }

            Canvas.SetLeft(circle, Center.X - Radius);
            Canvas.SetTop(circle, Center.Y - Radius);
            canvas.Children.Add(circle);
            return circle;
        }
    }
}
