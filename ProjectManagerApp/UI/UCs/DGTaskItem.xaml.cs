﻿using ProjectManagerApp.Classes;
using ProjectManagerApp.Entities;
using System;
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

        private void btnDelTaskClick(object sender, RoutedEventArgs e)
        {
            var taskToDelete = (sender as Button).DataContext as Entities.Task;
            var project = taskToDelete.Project;
            try
            {
                App.DataBase.Tasks.Remove(taskToDelete);
                App.DataBase.SaveChanges();
                Manager._frame.Navigate(new Pages.PageProject(project));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
