using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RockStarProject.Themes
{
    /// <summary>
    /// Interaction logic for PropertyDial.xaml
    /// </summary>
    public partial class PropertyDial : UserControl, INotifyPropertyChanged
    {
        public PropertyDial()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private void Grid_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            this.Angle = GetAngle(e.ManipulationOrigin, this.RenderSize);
            this.Amount = (int)(this.Angle / 360 * 100);
        }

        int m_Amount = default(int);
        public int Amount
        {
            get { return m_Amount; }
            set
            {
                SetProperty(ref m_Amount, value);
            }
        }

        double m_Angle = default(double);
        public double Angle
        {
            get { return m_Angle; }
            set
            {
                SetProperty(ref m_Angle, value);
            }
        }

        // Please note the changes with OnPropertyChanged and SetProperty
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;
            storage = value;
            OnPropertyChanged(propName);
            return true;
        }

        public enum Quadrants : int { nw = 2, ne = 1, sw = 4, se = 3 }
        private double GetAngle(Point touchPoint, Size circleSize)
        {
            var _X = touchPoint.X - (circleSize.Width / 2d);
            var _Y = circleSize.Height - touchPoint.Y - (circleSize.Height / 2d);
            var _Hypot = Math.Sqrt(_X * _X + _Y * _Y);
            var _Value = Math.Asin(_Y / _Hypot) * 180 / Math.PI;
            var _Quadrant = (_X >= 0) ?
                (_Y >= 0) ? Quadrants.ne : Quadrants.se :
                (_Y >= 0) ? Quadrants.nw : Quadrants.sw;
            switch (_Quadrant)
            {
                case Quadrants.ne: _Value = 090 - _Value; break;
                case Quadrants.nw: _Value = 270 + _Value; break;
                case Quadrants.se: _Value = 090 - _Value; break;
                case Quadrants.sw: _Value = 270 + _Value; break;
            }
            return _Value;
        }
    }
}
