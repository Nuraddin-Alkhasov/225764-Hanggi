﻿#pragma checksum "..\..\..\..\..\..\..\Views\TouchpadRegion\TouchPads\Views\AlphaTouchpadView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DEAE600A0C6441951CD0AFFBE908E219DE2CDB62688BFD51F54F16CC49EAE8FA"
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
using System.Windows.Interactivity;
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


namespace HMI {
    
    
    /// <summary>
    /// AlphaTouchpadView
    /// </summary>
    public partial class AlphaTouchpadView : VisiWin.Controls.View, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\..\..\Views\TouchpadRegion\TouchPads\Views\AlphaTouchpadView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid border;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\..\..\Views\TouchpadRegion\TouchPads\Views\AlphaTouchpadView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.TextBlock lblAlphaPadDescription;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\..\..\Views\TouchpadRegion\TouchPads\Views\AlphaTouchpadView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\..\..\Views\TouchpadRegion\TouchPads\Views\AlphaTouchpadView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.TextVarIn textVarIn1;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\..\..\Views\TouchpadRegion\TouchPads\Views\AlphaTouchpadView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.TouchKeyboard TouchKeyboard;
        
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
            System.Uri resourceLocater = new System.Uri("/225764-Hanggi;component/views/touchpadregion/touchpads/views/alphatouchpadview.x" +
                    "aml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Views\TouchpadRegion\TouchPads\Views\AlphaTouchpadView.xaml"
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
            
            #line 7 "..\..\..\..\..\..\..\Views\TouchpadRegion\TouchPads\Views\AlphaTouchpadView.xaml"
            ((HMI.AlphaTouchpadView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.View_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.border = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.lblAlphaPadDescription = ((VisiWin.Controls.TextBlock)(target));
            return;
            case 4:
            this.CancelButton = ((VisiWin.Controls.Button)(target));
            
            #line 29 "..\..\..\..\..\..\..\Views\TouchpadRegion\TouchPads\Views\AlphaTouchpadView.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.TouchKeyboard_Close);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textVarIn1 = ((VisiWin.Controls.TextVarIn)(target));
            
            #line 34 "..\..\..\..\..\..\..\Views\TouchpadRegion\TouchPads\Views\AlphaTouchpadView.xaml"
            this.textVarIn1.WriteValueCompleted += new System.Windows.RoutedEventHandler(this.TouchKeyboard_Close);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TouchKeyboard = ((VisiWin.Controls.TouchKeyboard)(target));
            
            #line 35 "..\..\..\..\..\..\..\Views\TouchpadRegion\TouchPads\Views\AlphaTouchpadView.xaml"
            this.TouchKeyboard.EscapeKeyPressed += new System.Windows.RoutedEventHandler(this.TouchKeyboard_Close);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

