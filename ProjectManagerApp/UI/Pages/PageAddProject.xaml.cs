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
    /// Логика взаимодействия для PageAddProject.xaml
    /// </summary>
    public partial class PageAddProject : Page
    {
        private Entities.Project _project = new Entities.Project();
        public PageAddProject()
        {
            InitializeComponent();
            _project.CreationDate = DateTime.Now;
            _project.Deadline = DateTime.Now;
            DataContext = _project;
            
            
            cbProjectTeam.ItemsSource = App.DataBase.ProjectTeams.ToList();
        }

        private void btnAddProjectClick(object sender, RoutedEventArgs e)
        {
            _project.IsCompleted = false;

            App.DataBase.Projects.Add(_project);
            try
            {
                App.DataBase.SaveChanges();
                Casements.CustomMessageBox messageBox = new Casements.CustomMessageBox("Сообщение", "Проект успешно добавлен");
                messageBox.ShowDialog();
            }
            catch (Exception ex)
            {
                Casements.CustomMessageBox messageBox = new Casements.CustomMessageBox("Ошибка", ex.ToString());
                messageBox.ShowDialog();
            }
        }
    }
}
