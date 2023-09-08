
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TechTalk.SpecFlow;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Model;
using VectorGraphicViewer.Services.Factory;
using VectorGraphicViewer.Services.Strategy;

namespace VectorGraphicViewer.test.IntegrationTest
{
    [TestClass]
    [Binding]
    public class VectorGraphicIntegrationSteps
    {
        private readonly MainWindow mainWindow;
        List<Graphic> graphics = new List<Graphic>();
        Ellipse Ellipse;
        Canvas canvas;
        public VectorGraphicIntegrationSteps()
        {
            mainWindow = new MainWindow();
        }

        [Given(@"the canvas is empty")]
        public void GivenTheCanvasIsEmpty()
        {
            canvas = new Canvas();
            canvas.Background = Brushes.LightGray;
            canvas.Width = 400;
            canvas.Height = 300;
            mainWindow.Content = canvas;

        }

        [When(@"I read the circle data from the JSON file")]
        public void WhenIReadTheCircleDataFromTheJsonFile()
        {
            string jsonData = @"
        [
            {
                ""type"": ""circle"",
                ""center"": ""0; 0"",
                ""radius"": 15.0,
                ""filled"": false,
                ""color"": ""127; 255; 0; 0""
            }
        ]";

            Mock<ISerialization> jsonSerializationMock = new Mock<ISerialization>();


            jsonSerializationMock.Setup(mock => mock.Deserialize(It.IsAny<string>()))
                                 .Returns(new List<Graphic>());

            JsonSerialization jsonSerialization = new JsonSerialization();

            // Act
            graphics = jsonSerialization.Deserialize(jsonData);
            var shapeFactory = new ShapeFactory();
            foreach (var item in graphics)
            {
                Ellipse = shapeFactory.CreateShape(item).Draw(canvas) as Ellipse;
            }


        }

        [Then(@"the circle should be rendered on the canvas")]
        public void ThenTheCircleShouldBeRenderedOnTheCanvas()
        {
            //Assert
            Assert.IsTrue(canvas.Children.Contains(Ellipse), "The circle is not rendered on the canvas.");
        }
    }
}