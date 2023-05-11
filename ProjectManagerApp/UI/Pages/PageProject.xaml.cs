using ProjectManagerApp.Classes;
using ProjectManagerApp.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManagerApp.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProject.xaml
    /// </summary>
    public partial class PageProject : Page
    {
        public static Project _project;
        public PageProject(Project project)
        {
            InitializeComponent();

            lvCurrentProjects.ItemsSource = App.DataBase.Projects.Where(p => p.IsCompleted == false).ToList();
            lvOldProjects.ItemsSource = App.DataBase.Projects.Where(p => p.IsCompleted == true).ToList();



            if(UserHolder.User.TypeOfUserId != 1)
            {
                spEditProject.Visibility = Visibility.Hidden; 
                spEditProject.IsEnabled = false;
                btnAddProject.Visibility = Visibility.Collapsed;
            }

            if(project == null)
            {
                spProjects.Visibility = Visibility.Visible;
            }
            else
            {
                _project = project;
                DataContext = project;

                if (project.Deadline == null)
                {
                    spDescription.Visibility = Visibility.Collapsed;
                }

                var currentProjectTasks = App.DataBase.Tasks.Where(p => p.Project.Id == project.Id).ToList();
                var currentProjectToRemove = App.DataBase.Tasks.Where(p => p.Project.Id != project.Id).ToList();
                var tasks = new List<List<Entities.Task>>();
                var statuses = App.DataBase.Status.ToList();
                var currentstatuses = new List<Status>();

                foreach (var status in statuses)
                {
                    status.Tasks = currentProjectTasks.Where(p => p.Status == status).ToList();
                }
                spTasks.ItemsSource = statuses;

                float laborCost = LaborCost.CalcLaborCost(project);
                tblLaborCost.Text = $"Трудозатраты - {laborCost}ч.";
            }

           

        }
        private void cellDGTasksMouseDown(object sender, MouseButtonEventArgs e)
        {
            

        }

        private void btnEditInfoClick(object sender, RoutedEventArgs e)
        {
            tbxName.IsEnabled = true;
            tbxDescription.IsEnabled = true;
           
            tpDeadline.IsEnabled = true;

            btnEditInfo.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Visible;

        }

        private void btnSaveClik(object sender, RoutedEventArgs e)
        {
            tbxName.IsEnabled = false;
            tbxDescription.IsEnabled = false;
            
            tpDeadline.IsEnabled = false;

            btnEditInfo.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Collapsed;

            var currentProject = _project;
            if(currentProject.Deadline < currentProject.CreationDate)
            {
                MessageBox.Show("Дейдлайн не может быть до начала создания проекта");
                return;
            }
            try
            {
                if (currentProject != null)
                {
                    App.DataBase.SaveChanges();
                    MessageBox.Show("Изменения сохранены!");
                    this.InitializeComponent();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void btnHideInfoClick(object sender, RoutedEventArgs e)
        {
            gInfo.Visibility = Visibility.Collapsed;
        }

        private void btnShowInfoClick(object sender, RoutedEventArgs e)
        {
            gInfo.Visibility = Visibility.Visible;
        }

        private void btnAddProjectClick(object sender, RoutedEventArgs e)
        {
            Manager._frame.Navigate(new PageAddProject());
        }

        private void btnCurrentProjectsClick(object sender, RoutedEventArgs e)
        {
            if (lvCurrentProjects.Visibility == Visibility.Collapsed)
                lvCurrentProjects.Visibility = Visibility.Visible;
            else
                lvCurrentProjects.Visibility = Visibility.Collapsed;
        }

        private void btnOldProjectsClick(object sender, RoutedEventArgs e)
        {
            if (lvOldProjects.Visibility == Visibility.Collapsed)
                lvOldProjects.Visibility = Visibility.Visible;
            else
                lvOldProjects.Visibility = Visibility.Collapsed;
        }
        private void ListViewItemCLick(object sender, MouseButtonEventArgs e)
        {
            spProjects.Visibility = Visibility.Collapsed;
            Manager._frame.Navigate(new Pages.PageProject(((ListViewItem)sender).DataContext as Entities.Project));
            
        }

        private void btnDelProjectClick(object sender, RoutedEventArgs e)
        {
            var tasks = _project.Tasks.ToList();
            if(Casements.CustomMessageBoxYesNo.Show("Предупреждение", "Вы точно хотите удалить этот проект?"))
            {
               if(tasks.Count > 0)
                {
                    foreach(var task in tasks)
                    {
                        App.DataBase.Tasks.Remove(task);
                    }
                }
                App.DataBase.Projects.Remove(_project);
                try
                {
                    App.DataBase.SaveChanges();
                    Casements.CustomMessageBox.Show("Успешно", "Проект успешно удален");
                    Manager._frame.Navigate(new PageProject(null));
                }
                catch(Exception ex)
                {
                    Casements.CustomMessageBox.Show("Ошибка", ex.Message.ToString());
                }
            }
            else
            {
                Casements.CustomMessageBox.Show("нет", "нет");

            }

        }

        private void btnInfoClick(object sender, RoutedEventArgs e)
        {
            Manager._frame.Navigate(new PageInfo());
        }
    }
}
