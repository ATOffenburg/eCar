﻿#pragma checksum "..\..\..\..\UI\Kunden\UserOverview.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C8F87EC503511B4F42E378A0855D36AD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18444
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
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
using e_Cars.UI.Kunden;


namespace e_Cars.UI.Kunden {
    
    
    /// <summary>
    /// UserOverview
    /// </summary>
    public partial class UserOverview : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\UI\Kunden\UserOverview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonBack;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\UI\Kunden\UserOverview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCreateNew;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\UI\Kunden\UserOverview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxFilter;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\UI\Kunden\UserOverview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView myListView;
        
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
            System.Uri resourceLocater = new System.Uri("/e-Cars;component/ui/kunden/useroverview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Kunden\UserOverview.xaml"
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
            
            #line 8 "..\..\..\..\UI\Kunden\UserOverview.xaml"
            ((e_Cars.UI.Kunden.UserOverview)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtonBack = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\UI\Kunden\UserOverview.xaml"
            this.ButtonBack.Click += new System.Windows.RoutedEventHandler(this.ButtonBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtonCreateNew = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\UI\Kunden\UserOverview.xaml"
            this.ButtonCreateNew.Click += new System.Windows.RoutedEventHandler(this.ButtonCreateNew_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextBoxFilter = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\..\UI\Kunden\UserOverview.xaml"
            this.TextBoxFilter.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxFilter_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.myListView = ((System.Windows.Controls.ListView)(target));
            
            #line 35 "..\..\..\..\UI\Kunden\UserOverview.xaml"
            this.myListView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.myListView_MouseDoubleClick);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\..\UI\Kunden\UserOverview.xaml"
            this.myListView.AddHandler(System.Windows.Controls.Primitives.ButtonBase.ClickEvent, new System.Windows.RoutedEventHandler(this.GridViewColumnHeaderClickedHandler));
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

