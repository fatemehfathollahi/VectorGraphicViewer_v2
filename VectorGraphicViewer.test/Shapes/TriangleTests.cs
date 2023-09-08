using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Model;

namespace VectorGraphicViewer.test.Shapes
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void Draw_ReturnsTriangleShape()
        {
            // Arrange
            var pointA = new Point(10, 10);
            var pointB = new Point(50, 10);
            var pointC = new Point(30, 40);
            var filled = true;
            var color = Colors.Green;

            var canvas = new Canvas();
            var triangle = new Triangle(pointA, pointB, pointC, filled, color);

            // Act
            var result = triangle.Draw(canvas);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.Windows.Shapes.Polygon));
        }
    }
}
