#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ACDB4F02DEE0E1BD1F2D5CCB7DE6B7313B31629"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using BDD_MERLIN_MOUTY;
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


namespace BDD_MERLIN_MOUTY {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Taskbar;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FidelioGestionButton;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FidelioButton;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClientButton;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EntrepriseButton;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FournisseurButton;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FournirButton;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PieceButton;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CommandeButton;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button VeloButton;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StatsButton;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StockButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BDD_MERLIN_MOUTY;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Taskbar = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 2:
            this.FidelioGestionButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\MainWindow.xaml"
            this.FidelioGestionButton.Click += new System.Windows.RoutedEventHandler(this.GoFidelio);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FidelioButton = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\MainWindow.xaml"
            this.FidelioButton.Click += new System.Windows.RoutedEventHandler(this.GoAdhesion);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\MainWindow.xaml"
            this.ClientButton.Click += new System.Windows.RoutedEventHandler(this.GoClient);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EntrepriseButton = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\MainWindow.xaml"
            this.EntrepriseButton.Click += new System.Windows.RoutedEventHandler(this.GoEntreprise);
            
            #line default
            #line hidden
            return;
            case 6:
            this.FournisseurButton = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\MainWindow.xaml"
            this.FournisseurButton.Click += new System.Windows.RoutedEventHandler(this.GoFournisseur);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FournirButton = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\MainWindow.xaml"
            this.FournirButton.Click += new System.Windows.RoutedEventHandler(this.GoFournir);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PieceButton = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\MainWindow.xaml"
            this.PieceButton.Click += new System.Windows.RoutedEventHandler(this.GoPiece);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CommandeButton = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\MainWindow.xaml"
            this.CommandeButton.Click += new System.Windows.RoutedEventHandler(this.GoCommande);
            
            #line default
            #line hidden
            return;
            case 10:
            this.VeloButton = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\MainWindow.xaml"
            this.VeloButton.Click += new System.Windows.RoutedEventHandler(this.GoVelo);
            
            #line default
            #line hidden
            return;
            case 11:
            this.StatsButton = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\..\MainWindow.xaml"
            this.StatsButton.Click += new System.Windows.RoutedEventHandler(this.GoStats);
            
            #line default
            #line hidden
            return;
            case 12:
            this.StockButton = ((System.Windows.Controls.Button)(target));
            
            #line 91 "..\..\..\MainWindow.xaml"
            this.StockButton.Click += new System.Windows.RoutedEventHandler(this.GoStock);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

