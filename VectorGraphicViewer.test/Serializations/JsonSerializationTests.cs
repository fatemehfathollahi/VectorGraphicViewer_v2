using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Text.Json;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Model;
using VectorGraphicViewer.Services.Strategy;

namespace VectorGraphicViewer.test.Serializations
{

    [TestClass]
    public class JsonSerializationTests
    {
        [TestMethod]
        public void Deserialize_WhenValidDataProvided_ShouldReturnListOfGraphics()
        {
            // Arrange
            string jsonData = @"
        [
            {
                ""type"": ""line"",
                ""a"": ""-1,5; 3,4"",
                ""b"": ""2,2; 5,7"",
                ""color"": ""127; 255; 255; 255""
            },
            {
                ""type"": ""circle"",
                ""center"": ""0; 0"",
                ""radius"": 15.0,
                ""filled"": false,
                ""color"": ""127; 255; 0; 0""
            },
            {
                ""type"": ""triangle"",
                ""a"": ""-15; -20"",
                ""b"": ""15; -20,3"",
                ""c"": ""0; 21"",
                ""filled"": true,
                ""color"": ""127; 255; 0; 255""
            }
        ]";

            Mock<ISerialization> jsonSerializationMock = new Mock<ISerialization>();

            // Configure the mock behavior
            jsonSerializationMock.Setup(mock => mock.Deserialize(It.IsAny<string>()))
                                 .Returns(new List<Graphic>());

            JsonSerialization jsonSerialization = new JsonSerialization();

            // Act
            List<Graphic> result = jsonSerialization.Deserialize(jsonData);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(JsonException))]
        public void Deserialize_WhenInvalidDataProvided_ShouldThrowJsonException()
        {
            // Arrange
            string invalidData = "Invalid JSON data";

            Mock<ISerialization> jsonSerializationMock = new Mock<ISerialization>();

            // Act
            jsonSerializationMock.Setup(mock => mock.Deserialize(It.IsAny<string>()))
                                 .Returns(new List<Graphic>());
            JsonSerialization jsonSerialization = new JsonSerialization();

            jsonSerialization.Deserialize(invalidData);
        }
    }
}
