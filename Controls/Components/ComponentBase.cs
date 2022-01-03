using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Controls.Components
{
    public class ComponentBase : UserControl
    {
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
            DependencyProperty.Register("IsRuning", typeof(bool), typeof(ComponentBase),
                new PropertyMetadata(default(bool), new PropertyChangedCallback(OnRuningStateChanged)));
        public static void OnRuningStateChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            bool state = (bool)e.NewValue;
            VisualStateManager.GoToState(o as ComponentBase, state ? "RunState" : "StopState", false);
        }

        public bool IsWarning
        {
            get { return (bool)GetValue(IsWarningProperty); }
            set { SetValue(IsWarningProperty, value); }
        }
        public static readonly DependencyProperty IsWarningProperty =
            DependencyProperty.Register("IsWarning", typeof(bool), typeof(ComponentBase),
                new PropertyMetadata(default(bool), new PropertyChangedCallback(OnWarningStateChanged)));
        public static void OnWarningStateChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            bool state = (bool)e.NewValue;
            VisualStateManager.GoToState(o as ComponentBase, state ? "WarningState" : "NormalState", false);
        }


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(ComponentBase),
                new PropertyMetadata(default(ICommand)));


        public Object CommandParameter
        {
            get { return (Object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(Object), typeof(ComponentBase),
                new PropertyMetadata(default(Object)));


        public ComponentBase()
        {
            this.PreviewMouseLeftButtonDown += ComponentBase_PreviewMouseLeftButtonDown;
        }

        private void ComponentBase_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.IsSelected = !this.IsSelected;
            this.Command?.Execute(this.CommandParameter);
            e.Handled = true;
        }
    }
}
