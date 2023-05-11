using ProjectManagerApp.Classes;
using ProjectManagerApp.UI.Casements;
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
            
            if(UserHolder.User.TypeOfUserId != 1)
            {
                btnAddTask.Visibility = Visibility.Collapsed;
            }
        }

        private void lvPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            

            Manager._frame.Navigate(new Pages.PageTask((Entities.Task)(sender as ListViewItem).DataContext, null));

        }

        private void ListViewItem_MouseMove(object sender, MouseEventArgs e)
        {
            var task = (Entities.Task)(sender as ListViewItem).DataContext;
            if (e.LeftButton == MouseButtonState.Pressed && UserHolder.User == task.User)
            {
                DragDrop.DoDragDrop(sender as ListViewItem, new DataObject(DataFormats.Serializable, (sender as ListViewItem).DataContext), DragDropEffects.Move);
            }
            else if(e.LeftButton == MouseButtonState.Pressed && UserHolder.User != task.User)
            {
                CustomMessageBox.Show("Внимание", "Вы не можете изменить статус задачи, за которую Вы не ответственны!");
            }
            else if (e.LeftButton == MouseButtonState.Pressed && UserHolder.User.TypeOfUserId == 3)
            {
                CustomMessageBox.Show("Внимание", "Вы не можете изменять статус задач!");
            }
        }

        private void lvTasksToDo_Drop(object sender, DragEventArgs e)
        {
            Entities.Status list = (sender as ListView).DataContext as Entities.Status;
            var task = e.Data.GetData(DataFormats.Serializable) as Entities.Task;


            Entities.Status statusTaskToRemove = App.DataBase.Status.FirstOrDefault(s=>s.Id == task.StatusId);
            statusTaskToRemove.Tasks.Remove(task);
            
            list.Tasks.Add(task);
            task.StatusId = list.Id;

            if (task.StatusId == 4)
            {
                task.CompletionDate = DateTime.Now;
            }
            else
            {
                task.CompletionDate = null;
            }

            App.DataBase.SaveChanges();
            Manager._frame.Navigate(new Pages.PageProject(task.Project));
        }

        private void btnAddTaskClick(object sender, RoutedEventArgs e)
        {
          
                Manager._frame.Navigate(new Pages.PageTask(null, this.DataContext as Entities.Status));

            
        }

        
    }
}
