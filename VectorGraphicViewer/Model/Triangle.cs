using System;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Model
{
    public class Triangle : Shape, IShapeFactory
    {
        public Triangle(Point a, Point b, Point c, bool? filled, Color color)
        {
            A = a;
            B = b;
            C = c;
            Filled = filled;
            Color = color;
        }
        public Point A { get; private set; }
        public Point B { get; private set; }
        public Point C { get; private set; }
        public bool? Filled { get; private set; }

        public System.Windows.Shapes.Shape  Draw(Canvas canvas, double zoomLevel = 1.0)
        {
            var polygon = new System.Windows.Shapes.Polygon
            {
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1
            };

            if (Filled == true)
            {
                polygon.Fill = new SolidColorBrush(Color);
            }

            double side1Length = Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
            double side2Length = Math.Sqrt(Math.Pow(C.X - B.X, 2) + Math.Pow(C.Y - B.Y, 2));
            double side3Length = Math.Sqrt(Math.Pow(A.X - C.X, 2) + Math.Pow(A.Y - C.Y, 2));

            if (side1Length > 100 || side2Length > 100 || side3Length > 100)
            {
                zoomLevel = Math.Max(Math.Max(side1Length, side2Length), side3Length) / 100;
            }

            polygon.Points = new PointCollection { new System.Windows.Point(A.X * zoomLevel, A.Y * zoomLevel),
            new System.Windows.Point(B.X * zoomLevel, B.Y * zoomLevel),
            new System.Windows.Point(C.X * zoomLevel, C.Y * zoomLevel) };

            canvas.Children.Add(polygon);
            return polygon;
        }
    }
}