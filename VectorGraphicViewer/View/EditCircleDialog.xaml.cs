using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using VectorGraphicViewer.Converters;
using VectorGraphicViewer.Model;
using VectorGraphicViewer.Services.Factory;
using VectorGraphicViewer.ViewModel;

namespace VectorGraphicViewer.View
{
    public partial class EditCircleDialog : Window
    {
        private Storyboard blinkStoryboard = null;
        private Canvas Canvas;
        private Ellipse Ellipse;
        private Ellipse UpdateEllipse;
        public EditCircleDialog(Ellipse ellipse, Canvas canvas)
        {
            InitializeComponent();
            Ellipse = ellipse;
            RenderAnimition(ellipse);
            Canvas = canvas;
        }
        private void RenderAnimition(Ellipse ellipse)
        {
            DoubleAnimation blinkAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            blinkStoryboard = new Storyboard();
            blinkStoryboard.Children.Add(blinkAnimation);
            Storyboard.SetTargetProperty(blinkAnimation, new PropertyPath("Opacity"));
            ellipse.BeginStoryboard(blinkStoryboard);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            RenderShape();
        }
        private void RenderShape()
        {
            CircleViewModel circleViewModel = DataContext as CircleViewModel;
            if (circleViewModel != null)
            {
                ShapeFactory shapeFactory = new ShapeFactory();
                string color = ConvertHexColorToObject(circleViewModel.SelectedColor);
                var shapedto = new ShapeDTO(
                     "circle",
                     null,
                     null,
                     null,
                     circleViewModel.CenterX + ";" + circleViewModel.CenterY,
                     circleViewModel.Radius,
                     circleViewModel.IsFillChecked,
                     color
                    );
                if (UpdateEllipse == null)
                {
                    Canvas.Children.Remove(Ellipse);
                }
                Canvas.Children.Remove(UpdateEllipse);

                Graphic graphic = ShapeMapper.ToGraphic(shapedto);
                Ellipse ellipse = shapeFactory.CreateShape(graphic).Draw(Canvas) as Ellipse;

                UpdateEllipse = ellipse;
            }

        }
        private string ConvertHexColorToObject(Color hexColor)
        {
            int alpha = hexColor.A;
            int red = hexColor.R;
            int green = hexColor.G;
            int blue = hexColor.B;
            string color = alpha + ";" + red + ";" + green + ";" + blue;
            return color;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            blinkStoryboard.Stop();
        }
    }
}