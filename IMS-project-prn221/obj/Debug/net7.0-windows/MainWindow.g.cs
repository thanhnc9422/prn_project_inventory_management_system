﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8B34208BED60BBC1D943E2538FE13CA2C9D34E4C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using IMS_project_prn221;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace IMS_project_prn221 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeViewItem whName;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeViewItem empManagement;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeViewItem orderManagement;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button signOutBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/IMS-project-prn221;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.whName = ((System.Windows.Controls.TreeViewItem)(target));
            return;
            case 2:
            
            #line 41 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TreeViewItem)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Chart_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 42 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TreeViewItem)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Sell_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 43 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.TreeViewItem)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.SellHistory_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.empManagement = ((System.Windows.Controls.TreeViewItem)(target));
            return;
            case 6:
            
            #line 47 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ViewEmployees_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 48 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.AddEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.orderManagement = ((System.Windows.Controls.TreeViewItem)(target));
            return;
            case 9:
            
            #line 52 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.OrderHistory_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 53 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).PreviewMouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Order_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.signOutBtn = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\MainWindow.xaml"
            this.signOutBtn.Click += new System.Windows.RoutedEventHandler(this.signOutBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

