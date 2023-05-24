using ProjectManagerApp.Classes;
using ProjectManagerApp.UI.Casements;
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
            _project.ProjectTeamId = (int)UserHolder.User.ProjectTeamId;
            DataContext = _project;

            tbTeam.Text = UserHolder.User.ProjectTeamId.ToString();
            
        }

        private void btnAddProjectClick(object sender, RoutedEventArgs e)
        {
            _project.IsCompleted = false;

            if (_project.Deadline < _project.CreationDate)
            {
                MessageBox.Show("Дедлайн не может быть до начала создания проекта");
                return;
            }
            if (string.IsNullOrWhiteSpace(_project.Name))
            {
                MessageBox.Show("Ввдите наименование проекта");
                return;
            }

            App.DataBase.Projects.Add(_project);
           
            try
            {
                App.DataBase.SaveChanges();
                CustomMessageBox.Show("Сообщение", "Проект успешно добавлен");
                Manager._frame.Navigate(new PageProject(_project));
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Ошибка", ex.ToString());
            }
        }

       

    }
}
