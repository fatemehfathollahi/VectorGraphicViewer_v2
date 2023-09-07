using System;
using System.Globalization;
using System.Windows.Media;
using VectorGraphicViewer.Model;
using VectorGraphicViewer.ViewModel;

namespace VectorGraphicViewer.Converters
{
    public static class ShapeMapper
    {
        private static readonly char[] Separator = { ';' };
        public static Graphic ToGraphic(ShapeDTO shapeDTO)
        {
            return new Graphic(shapeDTO.Type, ParsePoint(shapeDTO.A), ParsePoint(shapeDTO.B),
                        ParsePoint(shapeDTO.C), ParsePoint(shapeDTO.Center),
                        shapeDTO.Radius, shapeDTO.Filled, ParseColor(shapeDTO.Color));
        }

        private static Point ParsePoint(string value)
        {
            if (value == null) return new Point();
            var parts = value.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            var x = double.Parse(parts[0], CultureInfo.InvariantCulture);
            var y = double.Parse(parts[1], CultureInfo.InvariantCulture);
            return new Point(x, y);
        }

        private static Color ParseColor(string value)
        {
            var parts = value.Split(Separator, StringSplitOptions.RemoveEmptyEntries);
            var a = byte.Parse(parts[0], CultureInfo.InvariantCulture);
            var r = byte.Parse(parts[1], CultureInfo.InvariantCulture);
            var g = byte.Parse(parts[2], CultureInfo.InvariantCulture);
            var b = byte.Parse(parts[3], CultureInfo.InvariantCulture);
            return Color.FromArgb(a, r, g, b);
        }
    }
}

