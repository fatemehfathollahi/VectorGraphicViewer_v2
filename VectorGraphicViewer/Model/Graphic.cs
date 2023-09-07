using System.Windows.Media;

namespace VectorGraphicViewer.Model
{
    public class Graphic
    {
        public Graphic(string type, Point a, Point b, Point c, Point center, double radius, bool filled, Color color)
        {
            Type = type;
            A = a;
            B = b;
            C = c;
            Center = center;
            Radius = radius;
            Filled = filled;
            Color = color;
        }
        public string Type { get; private set; }
        public Point A { get; private set; } 
        public Point B { get; private set; }
        public Point C { get; private set; } 
        public Point Center { get; private set; }
        public double Radius { get; private set; }
        public bool? Filled { get; private set; }
        public Color Color { get; private set; }
    }
}