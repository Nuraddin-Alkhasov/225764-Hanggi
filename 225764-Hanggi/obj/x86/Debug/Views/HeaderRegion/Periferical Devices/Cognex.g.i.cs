﻿#pragma checksum "..\..\..\..\..\..\Views\HeaderRegion\Periferical Devices\Cognex.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A3D14083D2741BCFC76898A2163D0482DB8F828A96DD8A796E403A3B69747CBA"
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


namespace HMI.Views {
    
    
    /// <summary>
    /// Cognex
    /// </summary>
    public partial class Cognex : VisiWin.Controls.View, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\..\..\..\Views\HeaderRegion\Periferical Devices\Cognex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.TextVarOut status;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\..\Views\HeaderRegion\Periferical Devices\Cognex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button CheckConnection;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\..\Views\HeaderRegion\Periferical Devices\Cognex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button openConnection;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\..\Views\HeaderRegion\Periferical Devices\Cognex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button closeConnection;
        
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
            System.Uri resourceLocater = new System.Uri("/225764-Hanggi;component/views/headerregion/periferical%20devices/cognex.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\HeaderRegion\Periferical Devices\Cognex.xaml"
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
            this.status = ((VisiWin.Controls.TextVarOut)(target));
            return;
            case 2:
            this.CheckConnection = ((VisiWin.Controls.Button)(target));
            
            #line 17 "..\..\..\..\..\..\Views\HeaderRegion\Periferical Devices\Cognex.xaml"
            this.CheckConnection.Click += new System.Windows.RoutedEventHandler(this.CheckConnection_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.openConnection = ((VisiWin.Controls.Button)(target));
            
            #line 20 "..\..\..\..\..\..\Views\HeaderRegion\Periferical Devices\Cognex.xaml"
            this.openConnection.Click += new System.Windows.RoutedEventHandler(this.OpenConnection_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.closeConnection = ((VisiWin.Controls.Button)(target));
            
            #line 21 "..\..\..\..\..\..\Views\HeaderRegion\Periferical Devices\Cognex.xaml"
            this.closeConnection.Click += new System.Windows.RoutedEventHandler(this.CloseConnection_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

