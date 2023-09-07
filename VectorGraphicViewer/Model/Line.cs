using System;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Model
{
    public class Line : Shape, IShapeFactory
    {
        public Line(Point a, Point b, Color color)
        {
            A = a;
            B = b;
            Color = color;
        }
        public Point A { get; private set; }
        public Point B { get; private set; }

        public System.Windows.Shapes.Shape Draw(Canvas canvas, double zoomLevel = 1.0)
        {
            double sideLength = Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));

            if (sideLength > 100)
            {
                zoomLevel = sideLength / 100;
            }

            var line = new System.Windows.Shapes.Line
            {
                X1 = A.X * zoomLevel,
                Y1 = A.Y * zoomLevel,
                X2 = B.X * zoomLevel,
                Y2 = B.Y * zoomLevel,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1
            };
            canvas.Children.Add(line);
            return line;
        }
    }
}