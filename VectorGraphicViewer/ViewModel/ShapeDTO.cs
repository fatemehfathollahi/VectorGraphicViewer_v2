namespace VectorGraphicViewer.ViewModel
{
    public class ShapeDTO
    {
        public ShapeDTO(string type, string a, string b, string c, string center, double radius, bool filled, string color)
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
        public string A { get; private set; }
        public string B { get; private set; }
        public string C { get; private set; }
        public string Center { get; private set; }
        public double Radius { get; private set; }
        public bool Filled { get; private set; }
        public string Color { get; private set; }
    }
}