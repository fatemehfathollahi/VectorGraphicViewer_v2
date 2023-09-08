using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Xml;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Model;
using VectorGraphicViewer.Services.Strategy;

namespace VectorGraphicViewer.test.Serializations
{
    [TestClass]
    public class XmlSerializationTests
    {

        [TestMethod]
        public void Deserialize_ValidData_ReturnsListOfGraphics()
        {
            // Arrange
            string xmlString = @"<Shapes>
        <Shape>
            <Type>line</Type>
            <A>-1,5; 3,4</A>
            <B>2,2; 5,7</B>
            <Color>127; 255; 255; 255</Color>
        </Shape>
        <Shape>
            <Type>circle</Type>
            <Center>0; 0</Center>
            <Radius>15.0</Radius>
            <Filled>false</Filled>
            <Color>127; 255; 0; 0</Color>
        </Shape>
        <Shape>
            <Type>triangle</Type>
            <A>-15; -20</A>
            <B>15; -20,3</B>
            <C>0; 21</C>
            <Filled>true</Filled>
            <Color>127; 255; 0; 255</Color>
        </Shape>
    </Shapes>";

            // Act
            Mock<ISerialization> xmlSerializationMock = new Mock<ISerialization>();

            // Configure the mock behavior
            xmlSerializationMock.Setup(mock => mock.Deserialize(It.IsAny<string>()))
                                 .Returns(new List<Graphic>());

            XmlSerialization xmlSerialization = new XmlSerialization();

            var result = xmlSerialization.Deserialize(xmlString);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Graphic>));
        }

        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void Deserialize_InvalidData_ThrowsJsonException()
        {
            // Arrange
            string invalidData = "invalid_data.xml";

            // Act
            Mock<ISerialization> xmlSerializationMock = new Mock<ISerialization>();

            xmlSerializationMock.Setup(mock => mock.Deserialize(It.IsAny<string>()))
                                 .Returns(new List<Graphic>());

            XmlSerialization xmlSerialization = new XmlSerialization();
            xmlSerialization.Deserialize(invalidData);
        }
        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void Deserialize_Data_Is_Null_ThrowsJsonException()
        {
            // Arrange
            string invalidData = null;

            // Act
            Mock<ISerialization> xmlSerializationMock = new Mock<ISerialization>();

            xmlSerializationMock.Setup(mock => mock.Deserialize(It.IsAny<string>()))
                                 .Returns(new List<Graphic>());

            XmlSerialization xmlSerialization = new XmlSerialization();
            xmlSerialization.Deserialize(invalidData);
        }
    }
}
