using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using VectorGraphicViewer.Model;
using VectorGraphicViewer.Services.Factory;
using VectorGraphicViewer.Services.Visitor;
using WinLine = System.Windows.Shapes.Line;

namespace VectorGraphicViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RenderGraphics();
            canvas.MouseLeftButtonDown += Canvas_MouseLeftButtonDown;
        }
        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point mousePosition = e.GetPosition(canvas);

            foreach (UIElement element in canvas.Children)
            {
                if (element is Ellipse circle && IsMouseOverCircle(circle, mousePosition))
                {
                    CircleVisitor circleVisitor = new CircleVisitor(circle);
                    circleVisitor.Accept(new ShapeSelectionVisitor(canvas));
                    break;
                }
                if (element is Polygon triangle && IsMouseOverTriangle(triangle, mousePosition))
                {
                    MessageBox.Show($"Clicked on Triangle"); // TODO: Remove this line after immplement EditTriangleDialog

                    TriangleVisitor triangleVisitor = new TriangleVisitor(triangle);
                    triangleVisitor.Accept(new ShapeSelectionVisitor(canvas));
                }
                if (element is WinLine line && IsMouseOverLine(line, mousePosition))
                {
                    MessageBox.Show($"Clicked on Line"); // TODO: Remove this line after immplement EditLineDialog

                    LineVisitor lineVisitor = new LineVisitor(line);
                    lineVisitor.Accept(new ShapeSelectionVisitor(canvas));
                }
            }
        }
        private bool IsMouseOverCircle(Ellipse circle, System.Windows.Point mousePosition)
        {
            double circleCenterX = Canvas.GetLeft(circle) + circle.Width / 2;
            double circleCenterY = Canvas.GetTop(circle) + circle.Height / 2;
            double circleRadius = circle.Width / 2;

            double distance = Math.Sqrt(Math.Pow(mousePosition.X - circleCenterX, 2) + Math.Pow(mousePosition.Y - circleCenterY, 2));

            return distance <= circleRadius;
        }
        private bool IsMouseOverLine(WinLine line, System.Windows.Point mousePosition)
        {

            double x1 = line.X1;
            double y1 = line.Y1;
            double x2 = line.X2;
            double y2 = line.Y2;

            double dx = x2 - x1;
            double dy = y2 - y1;


            double length = Math.Sqrt(dx * dx + dy * dy);


            double unitX = dx / length;
            double unitY = dy / length;


            double vectorX = mousePosition.X - x1;
            double vectorY = mousePosition.Y - y1;


            double dotProduct = vectorX * unitX + vectorY * unitY;


            return dotProduct >= 0 && dotProduct <= length;

        }
        private bool IsMouseOverTriangle(Polygon triangle, System.Windows.Point mousePosition)
        {
            return triangle.RenderedGeometry.FillContains(mousePosition);
        }

        private void RenderGraphics()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            List<Graphic> graphics = ConvertToGraphicsModel();
            if (graphics.Count > 0)
                graphics.ForEach(graphic => shapeFactory.CreateShape(graphic).Draw(canvas));
        }
        private List<Graphic> ConvertToGraphicsModel()
        {
            string data = File.ReadAllText("graphics.json");
            if (data == null) return new List<Graphic>();
            string fileName = ConfigurationManager.AppSettings["FileName"];
            string fileExtension = System.IO.Path.GetExtension(fileName);

            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = fileExtension.TrimStart('.');
                SerializationrFactory serializationrFactory = new SerializationrFactory();
                var converter = serializationrFactory.CreateConverter(fileExtension);
                return converter.Deserialize(data);
            }
            return new List<Graphic>();
        }
    }
}