﻿#pragma checksum "..\..\..\..\..\..\..\Views\DialogRegion\Dialog\Views\DialogView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C6A0C5A7802FD677B94ADB0F4624ECD7D2E131993698EB7C3EBBAE337D6FCEEB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using VisiWin.Adapter;
using VisiWin.ApplicationFramework;
using VisiWin.Controls;
using VisiWin.Extensions;
using VisiWin.Shapes;


namespace HMI.Views.DialogRegion {
    
    
    /// <summary>
    /// DialogView
    /// </summary>
    public partial class DialogView : VisiWin.Controls.View, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\..\..\..\Views\DialogRegion\Dialog\Views\DialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.TextBlock HeaderText;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\..\..\Views\DialogRegion\Dialog\Views\DialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\..\..\Views\DialogRegion\Dialog\Views\DialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Region DialogArea;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\..\..\Views\DialogRegion\Dialog\Views\DialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button LeftButton;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\..\..\..\Views\DialogRegion\Dialog\Views\DialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button MiddleButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\..\..\Views\DialogRegion\Dialog\Views\DialogView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button RightButton;
        
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
            System.Uri resourceLocater = new System.Uri("/225764-Hanggi;component/views/dialogregion/dialog/views/dialogview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Views\DialogRegion\Dialog\Views\DialogView.xaml"
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
            this.HeaderText = ((VisiWin.Controls.TextBlock)(target));
            return;
            case 2:
            this.CancelButton = ((VisiWin.Controls.Button)(target));
            return;
            case 3:
            this.DialogArea = ((VisiWin.Controls.Region)(target));
            return;
            case 4:
            this.LeftButton = ((VisiWin.Controls.Button)(target));
            return;
            case 5:
            this.MiddleButton = ((VisiWin.Controls.Button)(target));
            return;
            case 6:
            this.RightButton = ((VisiWin.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

