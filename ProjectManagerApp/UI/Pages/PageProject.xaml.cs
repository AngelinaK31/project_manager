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

namespace ProjectManagerApp.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProject.xaml
    /// </summary>
    public partial class PageProject : Page
    {
        private Entities.Project _project;
        public PageProject(Entities.Project project)
        {
            InitializeComponent();
            _project=project;
            DataContext = project;
            
            if(project.Deadline == null)
            {
                spDescription.Visibility = Visibility.Collapsed;
            }

            var currentExecutors = App.DataBase.Users.Where(p => p.ProjectTeams.Where(j => j.Id == project.ProjectTeamId).FirstOrDefault() != default && p.Specialization != null).ToList();
            
            var currentProjectTasks = App.DataBase.Tasks.Where(p => p.Project.Id == project.Id).ToList();
            var tasks = new List<List<Entities.Task>>();
            foreach(var currentTask in currentProjectTasks)
            {
                var task = new List<Entities.Task>();   
                foreach (var currentExecutor in currentExecutors)
                {
                    if(currentTask.User == currentExecutor)
                    {
                        task.Add(currentTask);
                    }
                }
                tasks.Add(task);
            }

            LoadTasks(currentExecutors, tasks);
        }

        private void LoadTasks(List<Entities.User> headers, List<List<Entities.Task>> tasks)
        {
            dgTasks.Items.Clear();  
            for(int i= 0; i< headers.Count; i++)
            {
                FrameworkElementFactory headerFactory = new FrameworkElementFactory(typeof(UCs.DGTaskHeaderUC));
                headerFactory.SetValue(DataContextProperty, headers[i]);
                var headerTemplate = new DataTemplate
                {
                    VisualTree = headerFactory
                };

                FrameworkElementFactory cellFactory = new FrameworkElementFactory(typeof(UCs.DGTaskItem));
                cellFactory.SetBinding(DataContextProperty, new Binding($"[{i}]"));
                cellFactory.AddHandler(MouseDownEvent, new MouseButtonEventHandler(cellDGTasksMouseDown), true);
                var cellTemplate = new DataTemplate
                {
                    VisualTree = cellFactory
                };

                var columnTemplate = new DataGridTemplateColumn
                {
                    HeaderTemplate = headerTemplate,
                    Width = new DataGridLength(1, DataGridLengthUnitType.Auto),
                    CellTemplate = cellTemplate
                };

                dgTasks.Columns.Add(columnTemplate);

            }
            dgTasks.ItemsSource = tasks;
        }

        private void cellDGTasksMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnEditInfoClick(object sender, RoutedEventArgs e)
        {
            tbxName.IsEnabled = true;
            tbxDescription.IsEnabled = true;
            tpCreationDate.IsEnabled = true;
            tpDeadline.IsEnabled = true;

            btnEditInfo.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Visible;

        }

        private void btnSaveClik(object sender, RoutedEventArgs e)
        {
            tbxName.IsEnabled = false;
            tbxDescription.IsEnabled = false;
            tpCreationDate.IsEnabled = false;
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

        
    }
}
