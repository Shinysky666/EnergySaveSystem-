using EnergySaveSystem.ViewModel;
using System;
using System.Collections.Generic;
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

namespace EnergySaveSystem.View
{
    /// <summary>
    /// SystemMonitor.xaml 的交互逻辑
    /// </summary>
    public partial class SystemMonitor : UserControl
    {
        public SystemMonitor()
        {
            InitializeComponent();
        }

        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Console.WriteLine("Canvas_MouseWheel");
            double newWidth = this.MainViewbox.ActualWidth + e.Delta;
            double newHeight = this.MainViewbox.ActualHeight + e.Delta;
            //限制最小长宽
            if (newWidth < 100)
                newWidth = 100;
            if (newHeight < 500)
                newHeight = 500;
            this.MainViewbox.Width = newWidth;
            this.MainViewbox.Height = newHeight;

            //以屏幕中心缩放 可改写以鼠标位置缩放
            this.MainViewbox.SetValue(Canvas.LeftProperty, (this.RenderSize.Width - this.MainViewbox.Width) / 2);
        }

        //鼠标按下拖动MainViewbox
        bool _isMoving = false;
        Point _MouseClickPoint = new Point(0, 0);
        double MainViewbox_left = 0, MainViewbox_top = 0;

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isMoving = true;
            _MouseClickPoint = e.GetPosition(sender as Canvas);
            //获取鼠标点击前的位置
            MainViewbox_left = double.Parse(this.MainViewbox.GetValue(Canvas.LeftProperty).ToString());
            MainViewbox_top = double.Parse(this.MainViewbox.GetValue(Canvas.TopProperty).ToString());
            (sender as Canvas).CaptureMouse();
            e.Handled = true;
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {          
            _isMoving = false;
            (sender as Canvas).ReleaseMouseCapture();
            e.Handled = true;
        }

        //鼠标拖动Canvas 更改MainViewbox位置
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(_isMoving)
            {
                e.Handled = true;
                Point currentPoint = e.GetPosition(sender as Canvas);
                this.MainViewbox.SetValue(Canvas.LeftProperty, 
                    MainViewbox_left + (currentPoint.X - _MouseClickPoint.X));
                this.MainViewbox.SetValue(Canvas.TopProperty,
                    MainViewbox_top + (currentPoint.Y - _MouseClickPoint.Y));
            }
        }
    }
}
