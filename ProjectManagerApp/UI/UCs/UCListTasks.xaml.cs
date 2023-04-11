﻿using ProjectManagerApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для UCListTasks.xaml
    /// </summary>
    public partial class UCListTasks : UserControl
    {
        public UCListTasks()
        {
            InitializeComponent();
            
        }

        private void lvPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            

            Manager._frame.Navigate(new Pages.PageTask((Entities.Task)(sender as ListViewItem).DataContext, null));

        }

        private void ListViewItem_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(sender as ListViewItem, new DataObject(DataFormats.Serializable, (sender as ListViewItem).DataContext), DragDropEffects.Move);
            }
        }

        private void lvTasksToDo_Drop(object sender, DragEventArgs e)
        {
            Entities.Status list = (sender as ListView).DataContext as Entities.Status;
            var task = e.Data.GetData(DataFormats.Serializable) as Entities.Task;


            Entities.Status statusTaskToRemove = App.DataBase.Status.FirstOrDefault(s=>s.Id == task.StatusId);
            statusTaskToRemove.Tasks.Remove(task);

            list.Tasks.Add(task);
            App.DataBase.SaveChanges();

            Manager._frame.Navigate(new Pages.PageProject(task.Project));
        }

        private void btnAddTaskClick(object sender, RoutedEventArgs e)
        {
            
            Manager._frame.Navigate(new Pages.PageTask(null, this.DataContext as Entities.Status));
        }

        
    }
}
