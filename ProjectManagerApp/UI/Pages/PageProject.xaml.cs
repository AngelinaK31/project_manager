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
        public static Entities.Project _project;
        public PageProject(Entities.Project project)
        {
            InitializeComponent();
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
            var currentstatuses = new List<Entities.Status>();

            foreach(var status in statuses)
            {
                status.Tasks = currentProjectTasks.Where(p => p.Status == status).ToList();
            }
            spTasks.ItemsSource = statuses;

            float laborCost = Classes.LaborCost.CalcLaborCost(project);
            laborCost = (float)Math.Round(laborCost, 2, MidpointRounding.AwayFromZero);
            tblLaborCost.Text = $"Трудозатраты - {laborCost}ч.";

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
    }
}
