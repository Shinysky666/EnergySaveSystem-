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

namespace Controls.Components
{
    /// <summary>
    /// Pipeline.xaml 的交互逻辑
    /// </summary>
    public partial class Pipeline : UserControl
    {

        //默认管道流向从E(西)往W(东)
        public int Direction
        {
            get { return (int)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(int), typeof(Pipeline), 
                new PropertyMetadata(default(int),new PropertyChangedCallback(OnDirectionChanged)));
        private static void OnDirectionChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            int value = int.Parse(e.NewValue.ToString());
            VisualStateManager.GoToState(o as Pipeline, value == 1 ? "WEFlowState" : "EWFlowState", false);
        }

        //管道流水颜色
        public Brush liquidColor
        {
            get { return (Brush)GetValue(liquidColorProperty); }
            set { SetValue(liquidColorProperty, value); }
        }
        public static readonly DependencyProperty liquidColorProperty =
            DependencyProperty.Register("liquidColor", typeof(Brush), typeof(Pipeline), 
                new PropertyMetadata(Brushes.Orange));

        //管道圆角
        public int CapRadius
        {
            get { return (int)GetValue(CapRadiusProperty); }
            set { SetValue(CapRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CapRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CapRadiusProperty =
            DependencyProperty.Register("CapRadius", typeof(int), typeof(Pipeline), 
                new PropertyMetadata(default(int)));


        public Pipeline()
        {
            InitializeComponent();
        }

    }
}
