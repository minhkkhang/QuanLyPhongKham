﻿#pragma checksum "..\..\Settings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AD34AD420F236520AFB8A8E8C296B936834E1298"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QuanLyPhongKham;
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


namespace QuanLyPhongKham {
    
    
    /// <summary>
    /// Settings
    /// </summary>
    public partial class Settings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TienKhamTxt;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GioiHanTxt;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DonViTxt;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ThemDonViTxt;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TrieuChungTxt;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ThemTrieuChungTxt;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel OKPanel;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OKBtn;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/QuanLyPhongKham;component/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Settings.xaml"
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
            this.TienKhamTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.GioiHanTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.DonViTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ThemDonViTxt = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Settings.xaml"
            this.ThemDonViTxt.Click += new System.Windows.RoutedEventHandler(this.ThemDonViTxt_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TrieuChungTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ThemTrieuChungTxt = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\Settings.xaml"
            this.ThemTrieuChungTxt.Click += new System.Windows.RoutedEventHandler(this.ThemTrieuChungTxt_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.OKPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 8:
            this.OKBtn = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\Settings.xaml"
            this.OKBtn.Click += new System.Windows.RoutedEventHandler(this.OKBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CancelBtn = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
