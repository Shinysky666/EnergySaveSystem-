﻿#pragma checksum "..\..\..\View\SystemMonitor.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "60746DD05374C8737D098CDB70F55BECB22594336B1DD78F64B8700226E3375E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Controls;
using Controls.Components;
using EnergySaveSystem.Base;
using EnergySaveSystem.View;
using EnergySaveSystem.ViewModel;
using LiveCharts.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace EnergySaveSystem.View {
    
    
    /// <summary>
    /// SystemMonitor
    /// </summary>
    public partial class SystemMonitor : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 76 "..\..\..\View\SystemMonitor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewbox MainViewbox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EnergySaveSystem;component/view/systemmonitor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\SystemMonitor.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 72 "..\..\..\View\SystemMonitor.xaml"
            ((System.Windows.Controls.Canvas)(target)).MouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.Canvas_MouseWheel);
            
            #line default
            #line hidden
            
            #line 73 "..\..\..\View\SystemMonitor.xaml"
            ((System.Windows.Controls.Canvas)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 74 "..\..\..\View\SystemMonitor.xaml"
            ((System.Windows.Controls.Canvas)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 75 "..\..\..\View\SystemMonitor.xaml"
            ((System.Windows.Controls.Canvas)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.Canvas_MouseMove);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainViewbox = ((System.Windows.Controls.Viewbox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

