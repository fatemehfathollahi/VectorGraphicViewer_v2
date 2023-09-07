using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace VectorGraphicViewer.ViewModel
{
    public class CircleViewModel : INotifyPropertyChanged
    {
        public CircleViewModel()
        {
            Colors = new ObservableCollection<Color>
        {
           (Color)ColorConverter.ConvertFromString("#FF0000"),
            (Color)ColorConverter.ConvertFromString("#0000FF"),
            (Color)ColorConverter.ConvertFromString("#00FF00"),
            (Color)ColorConverter.ConvertFromString("#FFFF00"),
             (Color)ColorConverter.ConvertFromString("#7FFF0000")
        };
        }
        
        private string _centerY;
        public string CenterY
        {
            get { return _centerY; }
            set
            {
                if (_centerY != value)
                {
                    _centerY = value;
                    OnPropertyChanged(nameof(CenterY));
                }
            }
        }
        private string _centerX;
        public string CenterX
        {
            get { return _centerX; }
            set
            {
                if (_centerX != value)
                {
                    _centerX = value;
                    OnPropertyChanged(nameof(CenterX));
                }
            }
        }
        private double _radius;
        public double Radius
        {
            get { return _radius; }
            set
            {
                if (_radius != value)
                {
                    _radius = value;
                    OnPropertyChanged(nameof(Radius));
                }
            }
        }
        private ObservableCollection<Color> _colors;
        public ObservableCollection<Color> Colors
        {
            get { return _colors; }
            set
            {
                _colors = value;
                OnPropertyChanged();
            }
        }

        private Color _selectedColor;
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                OnPropertyChanged();
            }
        }

        private bool _isFillChecked;
        public bool IsFillChecked
        {
            get { return _isFillChecked; }
            set
            {
                _isFillChecked = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}