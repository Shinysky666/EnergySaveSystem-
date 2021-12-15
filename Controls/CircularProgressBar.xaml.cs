using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace Controls
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class CircularProgressBar : UserControl
    {
        public CircularProgressBar()
        {
            InitializeComponent();
            this.SizeChanged += CircularProgressBar_SizeChanged;
        }

        private void CircularProgressBar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //图形加载渲染后,设置前端Grid的Width
            this.gridlayout.Width = Math.Min(this.RenderSize.Width, this.RenderSize.Height);
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // 依赖属性
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(
                default(double),new PropertyChangedCallback(OnpropertyChanged)));

        private static void OnpropertyChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            (d as CircularProgressBar).UpdateValue();
        }

        private void UpdateValue()
        {
            // double radius= Math.Min(this.RenderSize.Width, this.RenderSize.Height)/2 ;
            double newX = 0.0, newY = 0.0;
            double radius = this.gridlayout.Width / 2;
            if (radius < 0)
                return;

            newX = radius + (radius - 3) * Math.Cos((this.Value % 100 * 3.6 - 90) * Math.PI / 180);
            newY = radius + (radius - 3) * Math.Sin((this.Value % 100 * 3.6 - 90) * Math.PI / 180);

            string pathDataStr = "M{0} 3A{1} {1} 0 0 1 {2} {3}";
            pathDataStr = string.Format(pathDataStr, radius, radius - 3, newX, newY);

            //图形转换
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            this.Arcpath.Data = (Geometry)converter.ConvertFrom(pathDataStr);
            //M75 3A75 75 0 0 1 147 75

        }


    }
}
