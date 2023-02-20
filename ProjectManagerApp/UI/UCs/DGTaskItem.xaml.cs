﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManagerApp.UI.UCs
{
    /// <summary>
    /// Логика взаимодействия для DGTaskItem.xaml
    /// </summary>
    public partial class DGTaskItem : UserControl
    {
        public DGTaskItem()
        {
            InitializeComponent();
           
        }

        private void UserControlDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
                if(e.NewValue == null)
                {
                    spUC.Visibility = Visibility.Hidden; 
                    
                }
            
        }
    }
}
