﻿#pragma checksum "..\..\..\..\UI\Pages\PageTeams.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F117DA22A6A38840AE033D1A59572A6318B371E4E98573C766AB92A8671B1045"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectManagerApp.UI.Pages;
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


namespace ProjectManagerApp.UI.Pages {
    
    
    /// <summary>
    /// PageTeams
    /// </summary>
    public partial class PageTeams : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\UI\Pages\PageTeams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgTeams;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\UI\Pages\PageTeams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spTeamsEdit;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\UI\Pages\PageTeams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spAddUser;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\UI\Pages\PageTeams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbGender;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\UI\Pages\PageTeams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSpecialization;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\UI\Pages\PageTeams.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTeam;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectManagerApp;component/ui/pages/pageteams.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Pages\PageTeams.xaml"
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
            this.dgTeams = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.spTeamsEdit = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            
            #line 59 "..\..\..\..\UI\Pages\PageTeams.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAddTeamClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 60 "..\..\..\..\UI\Pages\PageTeams.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnShowAddUserClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.spAddUser = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.cbGender = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.cbSpecialization = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.cbTeam = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            
            #line 105 "..\..\..\..\UI\Pages\PageTeams.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAddNewUserClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
