using System.Text.Json.Serialization;
using System.Windows.Media;

namespace VectorGraphicViewer.Model
{
    public class Graphic
    {
        public Graphic()
        {

        }
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
        
        public string Type { get;  set; }
        public Point A { get;  set; } 
        public Point B { get;  set; }
        public Point C { get;  set; } 
        public Point Center { get;  set; }
        public double Radius { get;  set; }
        public bool? Filled { get;  set; }
        public Color Color { get;  set; }
    }
}