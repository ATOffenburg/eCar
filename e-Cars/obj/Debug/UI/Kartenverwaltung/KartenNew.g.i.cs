﻿#pragma checksum "..\..\..\..\UI\Kartenverwaltung\KartenNew.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "75E30BBC59B2136C3100B6306E690D68"
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


namespace e_Cars.UI.Kartenverwaltung {
    
    
    /// <summary>
    /// KartenNew
    /// </summary>
    public partial class KartenNew : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\UI\Kartenverwaltung\KartenNew.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonZurueck;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\UI\Kartenverwaltung\KartenNew.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBKart_ID;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\UI\Kartenverwaltung\KartenNew.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBKund_ID;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\UI\Kartenverwaltung\KartenNew.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBSperrV;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\UI\Kartenverwaltung\KartenNew.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePickerSperrdatum;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\UI\Kartenverwaltung\KartenNew.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSave;
        
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
            System.Uri resourceLocater = new System.Uri("/e-Cars;component/ui/kartenverwaltung/kartennew.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Kartenverwaltung\KartenNew.xaml"
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
            this.ButtonZurueck = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\UI\Kartenverwaltung\KartenNew.xaml"
            this.ButtonZurueck.Click += new System.Windows.RoutedEventHandler(this.ButtonZurueck_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TBKart_ID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TBKund_ID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TBSperrV = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.DatePickerSperrdatum = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.ButtonSave = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\UI\Kartenverwaltung\KartenNew.xaml"
            this.ButtonSave.Click += new System.Windows.RoutedEventHandler(this.ButtonSave_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

