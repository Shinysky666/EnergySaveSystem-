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
    /// CoolingTower.xaml 的交互逻辑
    /// </summary>
    public partial class CoolingTower : UserControl
    {
        public CoolingTower()
        {
            InitializeComponent();
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            { 
                _isSelected = value;
                VisualStateManager.GoToState(this, value ? "SelectedState" : "UnSelectedState", false);
            }
        }

        public bool IsRuning
        {
            get { return (bool)GetValue(IsRuningProperty); }
            set { SetValue(IsRuningProperty, value); }
        }

        public static readonly DependencyProperty IsRuningProperty =
            DependencyProperty.Register("IsRuning", typeof(bool), typeof(CoolingTower),
                new PropertyMetadata(default(bool), new PropertyChangedCallback(OnRuningStateChanged)));
        public static void OnRuningStateChanged(DependencyObject o,DependencyPropertyChangedEventArgs e)
        {
            bool state = (bool)e.NewValue;
            VisualStateManager.GoToState(o as CoolingTower, state ? "RunState" : "StopState", false);
        }

        public bool IsWarning
        {
            get { return (bool)GetValue(IsWarningProperty); }
            set { SetValue(IsWarningProperty, value); }
        }

        public static readonly DependencyProperty IsWarningProperty =
            DependencyProperty.Register("IsWarning", typeof(bool), typeof(CoolingTower),
                new PropertyMetadata(default(bool), new PropertyChangedCallback(OnWarningStateChanged)));
        public static void OnWarningStateChanged(DependencyObject o,DependencyPropertyChangedEventArgs e)
        {
            bool state = (bool)e.NewValue;
            VisualStateManager.GoToState(o as CoolingTower, state ? "WarningState" : "NormalState", false);
        }

    }
}
