using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Model;

namespace VectorGraphicViewer.test.Shapes
{
    [TestClass]
    public class LineTests
    {
        [TestMethod]
        public void Draw_ReturnsLineShape()
        {
            // Arrange
            var pointA = new Point(10, 10);
            var pointB = new Point(50, 50);
            var color = Colors.Blue;

            var canvas = new Canvas();
            var line = new Line(pointA, pointB, color);

            // Act
            var result = line.Draw(canvas);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.Windows.Shapes.Line));
        }
    }
}
