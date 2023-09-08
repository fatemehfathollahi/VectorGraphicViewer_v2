using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VectorGraphicViewer.Services.Strategy;
using factory = VectorGraphicViewer.Services.Factory;

namespace VectorGraphicViewer.test.Serializations
{
    [TestClass]
    public class SerializationFactoryTests
    {
        [TestMethod]
        public void CreateConverter_ReturnsJsonSerializationForJsonFileType()
        {
            // Arrange
            var fileExtension = "json";
            var serializationFactory = new factory.SerializationrFactory();

            // Act
            var result = serializationFactory.CreateConverter(fileExtension);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(JsonSerialization));
        }

        [TestMethod]
        public void CreateConverter_ReturnsXmlSerializationForXmlFileType()
        {
            // Arrange
            var fileExtension = "xml";
            var serializationFactory = new factory.SerializationrFactory();

            // Act
            var result = serializationFactory.CreateConverter(fileExtension);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(XmlSerialization));
        }

        [TestMethod]
        public void CreateConverter_ThrowsExceptionForInvalidFileType()
        {
            // Arrange
            var fileExtension = "csv";
            var serializationFactory = new factory.SerializationrFactory();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => serializationFactory.CreateConverter(fileExtension));
        }
    }
}
