// Updated by XamlIntelliSenseFileGenerator 2021/12/30 17:24:24
#pragma checksum "..\..\..\Components\CoolingTower.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1796B90F5FE47EB2026B42FFA179C9CB69B2C9900EC1F505056625119E048AFF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Controls.Components;
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


namespace Controls.Components
{


    /// <summary>
    /// CoolingTower
    /// </summary>
    public partial class CoolingTower : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {


#line 45 "..\..\..\Components\CoolingTower.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.RotateTransform flabellumrt;

#line default
#line hidden


#line 130 "..\..\..\Components\CoolingTower.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.GradientStop gsGreen;

#line default
#line hidden


#line 139 "..\..\..\Components\CoolingTower.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.GradientStop gsRed;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Controls;component/components/coolingtower.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Components\CoolingTower.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.flabellumrt = ((System.Windows.Media.RotateTransform)(target));
                    return;
                case 2:
                    this.gsGreen = ((System.Windows.Media.GradientStop)(target));
                    return;
                case 3:
                    this.gsRed = ((System.Windows.Media.GradientStop)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.VisualState RunState;
        internal System.Windows.VisualState StopState;
        internal System.Windows.VisualState WarningState;
        internal System.Windows.VisualState NormalState;
    }
}
