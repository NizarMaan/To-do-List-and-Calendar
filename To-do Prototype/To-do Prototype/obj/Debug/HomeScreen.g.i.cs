﻿#pragma checksum "..\..\HomeScreen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "03B5A299B54BF8C1FCD85510A376EB2B"
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


namespace To_do_Prototype {
    
    
    /// <summary>
    /// HomeScreen
    /// </summary>
    public partial class HomeScreen : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TopIcons;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgReport;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgCalender;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgSort;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel TaskSection;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgHome;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgToday;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgAdd;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid SelectionGrid;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lsvSortBy;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\HomeScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lsvViewBy;
        
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
            System.Uri resourceLocater = new System.Uri("/To-do Prototype;component/homescreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\HomeScreen.xaml"
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
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.TopIcons = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.imgReport = ((System.Windows.Controls.Image)(target));
            
            #line 23 "..\..\HomeScreen.xaml"
            this.imgReport.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.imgSync_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.imgCalender = ((System.Windows.Controls.Image)(target));
            
            #line 24 "..\..\HomeScreen.xaml"
            this.imgCalender.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.imgCalender_MouseDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.imgSort = ((System.Windows.Controls.Image)(target));
            
            #line 25 "..\..\HomeScreen.xaml"
            this.imgSort.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.imgSort_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TaskSection = ((System.Windows.Controls.StackPanel)(target));
            
            #line 31 "..\..\HomeScreen.xaml"
            this.TaskSection.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TaskSection_MouseDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.imgHome = ((System.Windows.Controls.Image)(target));
            
            #line 42 "..\..\HomeScreen.xaml"
            this.imgHome.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.imgHome_MouseDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.imgToday = ((System.Windows.Controls.Image)(target));
            
            #line 43 "..\..\HomeScreen.xaml"
            this.imgToday.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.imgToday_MouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.imgAdd = ((System.Windows.Controls.Image)(target));
            
            #line 44 "..\..\HomeScreen.xaml"
            this.imgAdd.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.AddNewTask);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SelectionGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.lsvSortBy = ((System.Windows.Controls.ListView)(target));
            return;
            case 12:
            
            #line 56 "..\..\HomeScreen.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.lviAlphabetical);
            
            #line default
            #line hidden
            
            #line 56 "..\..\HomeScreen.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.lviAlphabetical);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 57 "..\..\HomeScreen.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.lviDueDate);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 58 "..\..\HomeScreen.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.vbiCategory);
            
            #line default
            #line hidden
            return;
            case 15:
            this.lsvViewBy = ((System.Windows.Controls.ListView)(target));
            return;
            case 16:
            
            #line 61 "..\..\HomeScreen.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.lviAgenda);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 62 "..\..\HomeScreen.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.lviMonthly);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

