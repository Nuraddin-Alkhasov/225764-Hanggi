﻿#pragma checksum "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DEDB4C2F47D209007B69CC07AE8DC34DE1F3269C7643F29997318D74A7B2ADAD"
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


namespace HMI.Views.MainRegion {
    
    
    /// <summary>
    /// Recipe_Selector
    /// </summary>
    public partial class Recipe_Selector : VisiWin.Controls.View, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.TextBlock HeaderText;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.TextVarOut tbName;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.TextVarOut tbParts;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.TextVarOut tbDescription;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_recipes;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button LeftButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal VisiWin.Controls.Button RightButton;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image gif;
        
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
            System.Uri resourceLocater = new System.Uri("/225764-Hanggi;component/views/mainregion/recipe/views/recipe_selector.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml"
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
            
            #line 7 "..\..\..\..\..\..\..\Views\MainRegion\Recipe\Views\Recipe_Selector.xaml"
            ((System.Windows.Controls.Grid)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Main_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HeaderText = ((VisiWin.Controls.TextBlock)(target));
            return;
            case 3:
            this.CancelButton = ((VisiWin.Controls.Button)(target));
            return;
            case 4:
            this.tbName = ((VisiWin.Controls.TextVarOut)(target));
            return;
            case 5:
            this.tbParts = ((VisiWin.Controls.TextVarOut)(target));
            return;
            case 6:
            this.tbDescription = ((VisiWin.Controls.TextVarOut)(target));
            return;
            case 7:
            this.dg_recipes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.LeftButton = ((VisiWin.Controls.Button)(target));
            return;
            case 9:
            this.RightButton = ((VisiWin.Controls.Button)(target));
            return;
            case 10:
            this.gif = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
