using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Model;

namespace VectorGraphicViewer.test.Shapes
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void Draw_ReturnsEllipseShape()
        {
            // Arrange
            var center = new Point(50, 50);
            var radius = 30.0;
            var filled = true;
            var color = Colors.Red;

            var canvas = new Canvas();
            var circle = new Circle(center, radius, filled, color);

            // Act
            var result = circle.Draw(canvas);
            var brush = new SolidColorBrush(color);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.Windows.Shapes.Ellipse));
            Assert.AreEqual((radius * 2), result.Width, "The circle is not rendered at the expected X coordinate.");
            Assert.AreEqual((radius * 2), result.Height, "The circle is not rendered at the expected Y coordinate.");
            Assert.AreEqual(brush, result.Fill, "The circle does not have the expected color.");
        }
    }
}
