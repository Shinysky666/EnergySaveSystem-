using EnergySaveSystem.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EnergySaveSystem.ViewModel
{
    public class MainWindowViewModel: NotifyPropertyBase
    {
        private UIElement _mainContent; 

        public UIElement MainContent
        {
            get { return _mainContent; }
            set { Set<UIElement>(ref _mainContent, value); }
        }

        public CommandBase TabChangedCommand { get; set; }

        public MainWindowViewModel()
        {
            //MainContent事件绑定
            TabChangedCommand = new CommandBase(OnTabChanged);
            //初始化 MainContent
            OnTabChanged("EnergySaveSystem.View.SystemMonitor");
        }

        private void OnTabChanged(object obj)
        {
            if (obj == null)
                return;

            //完整方式
            /*string[] strValues = o.ToString().Split('|');
            Assembly assembly = Assembly.LoadFrom(strValues[0]);
            Type type = assembly.GetType(strValues[1]);*/

            //简化方式 必须在同一程序集下
            Type type = Type.GetType(obj.ToString());
            this.MainContent = (UIElement)Activator.CreateInstance(type);
        }
    }
}
