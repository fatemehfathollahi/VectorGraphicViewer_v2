using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.View;
using VectorGraphicViewer.ViewModel;

namespace VectorGraphicViewer.Services.Visitor
{
    public class ShapeSelectionVisitor : IShapeVisitor
    {
        Canvas Canvas;
        public ShapeSelectionVisitor(Canvas canvas)
        {
            Canvas = canvas;
        }
        public void Visit(CircleVisitor circleVisitor)
        {
            Ellipse circle = circleVisitor.Ellipse;
            EditCircleDialog dialog = new EditCircleDialog(circle, Canvas);
            double circleCenterX = Canvas.GetLeft(circle) + circle.Width / 2;
            double circleCenterY = Canvas.GetTop(circle) + circle.Height / 2;
            double circleRadius = circle.Width / 2;
            var circleBorderBrush = circle.Stroke as SolidColorBrush;
            CircleViewModel circleViewModel = new CircleViewModel();
            circleViewModel.CenterY = circleCenterY.ToString();
            circleViewModel.CenterX = circleCenterX.ToString();
            circleViewModel.Radius = circleRadius;
            circleViewModel.SelectedColor = circleBorderBrush.Color;
            dialog.DataContext = circleViewModel;
            if (circle.Fill != null)
                circleViewModel.IsFillChecked = true;
            if (dialog.ShowDialog() == true) { }
        }

        public void Visit(LineVisitor line)
        {
            //TODO: Immplement EditLineDialog
        }

        public void Visit(TriangleVisitor triangle)
        {
            //TODO: Immplemnt EditTriangleDialog
        }
    }
}