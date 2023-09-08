using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VectorGraphicViewer.Model;
using VectorGraphicViewer.Services.Factory;

namespace VectorGraphicViewer.test.Shapes
{
    [TestClass]
    public class ShapeFactoryTests
    {
        [TestMethod]
        public void CreateShape_ReturnsCorrectShapeBasedOnGraphicType()
        {
            // Arrange
            var graphic = new Graphic("circle", new Point(), new Point(),new Point(), new Point(10, 20),15, true, Colors.Red);

            var shapeFactory = new ShapeFactory();

            // Act
            var result = shapeFactory.CreateShape(graphic);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Circle));
        }

        [TestMethod]
        public void CreateShape_ThrowsExceptionForInvalidShapeType()
        {
            // Arrange
            var graphic = new Graphic("invalidtype", new Point(), new Point(), new Point(), new Point(10, 20), 15, true, Colors.Red);

            var shapeFactory = new ShapeFactory();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => shapeFactory.CreateShape(graphic));
        }
    }
}
