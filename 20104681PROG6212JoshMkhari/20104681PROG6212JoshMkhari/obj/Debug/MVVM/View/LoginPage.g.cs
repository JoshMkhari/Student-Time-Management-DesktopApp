﻿#pragma checksum "..\..\..\..\MVVM\View\LoginPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8EFF575E979B3332D5B50DE1542DE7F7DF1D3836D22185130E2941244A7FCC00"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using _20104681PROG6212JoshMkhari.MVVM.View;


namespace _20104681PROG6212JoshMkhari.MVVM.View {
    
    
    /// <summary>
    /// LoginPage
    /// </summary>
    public partial class LoginPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\..\MVVM\View\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TViewName;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\MVVM\View\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TUserName;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\MVVM\View\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TPassword;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\MVVM\View\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Login;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\MVVM\View\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SignUp;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\MVVM\View\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSignUp;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\MVVM\View\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnLogin;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\..\MVVM\View\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TDisplayHelp;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\..\MVVM\View\LoginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider updater;
        
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
            System.Uri resourceLocater = new System.Uri("/20104681PROG6212JoshMkhari;component/mvvm/view/loginpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\View\LoginPage.xaml"
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
            this.TViewName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TUserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 48 "..\..\..\..\MVVM\View\LoginPage.xaml"
            this.TUserName.GotFocus += new System.Windows.RoutedEventHandler(this.TUserName_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TPassword = ((System.Windows.Controls.TextBox)(target));
            
            #line 62 "..\..\..\..\MVVM\View\LoginPage.xaml"
            this.TPassword.GotFocus += new System.Windows.RoutedEventHandler(this.TPassword_GotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Login = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\..\MVVM\View\LoginPage.xaml"
            this.Login.Click += new System.Windows.RoutedEventHandler(this.Login_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SignUp = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\..\..\MVVM\View\LoginPage.xaml"
            this.SignUp.Click += new System.Windows.RoutedEventHandler(this.SignUp_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnSignUp = ((System.Windows.Controls.Button)(target));
            
            #line 113 "..\..\..\..\MVVM\View\LoginPage.xaml"
            this.BtnSignUp.Click += new System.Windows.RoutedEventHandler(this.BtnSignUp_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 129 "..\..\..\..\MVVM\View\LoginPage.xaml"
            this.BtnLogin.Click += new System.Windows.RoutedEventHandler(this.BtnLogin_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TDisplayHelp = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.updater = ((System.Windows.Controls.Slider)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

