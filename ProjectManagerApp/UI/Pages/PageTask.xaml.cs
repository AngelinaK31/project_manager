using ProjectManagerApp.Classes;
using ProjectManagerApp.Entities;
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
using System.Xml.Linq;

namespace ProjectManagerApp.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTaks.xaml
    /// </summary>
    public partial class PageTask : Page
    {
        private Entities.Task _task = new Entities.Task();

        public PageTask(Entities.Task task, Status status)
        {
            InitializeComponent();


            cbTaskMycroobject.ItemsSource = App.DataBase.Mycroobjects.ToList();
            cbTaskTypeOfWork.ItemsSource = App.DataBase.TypeOfWorks.ToList();
            cbTaskStatus.ItemsSource = App.DataBase.Status.ToList();
           

            if (task != null )
            {
                _task = task;
                
            }
            else
            {
                _task.CreationDate = DateTime.Now.Date;
                _task.Deadline = DateTime.Now.Date;
                dpTaskDeadline.DisplayDateStart = _task.CreationDate;
                _task.Project = PageProject._project;

            }

            DataContext = _task;

            cbTaskStatus.SelectedItem = status;
            cbTaskExecutor.ItemsSource = App.DataBase.Users.Where(u => u.ProjectTeamId == _task.Project.ProjectTeamId).ToList();

            if (_task.StatusId == 4 )
            {
                tblTaskCompletion.Visibility = Visibility.Visible;
                dpTaskCompletion.Visibility = Visibility.Visible;
            }

           
            

        }

       

        private void btnSaveClik(object sender, RoutedEventArgs e)
        {
            

            var currentTask = _task;
            if (_task.Deadline < _task.CreationDate)
            {
                CustomMessageBox.Show("Внимание", "Дедлайн не может быть до начала создания проекта");
                return;
            }
            if (CheckTask(currentTask))
            {
                if (currentTask.Id == 0)
                {
                    App.DataBase.Tasks.Add(currentTask);
                }
                try
                {
                    if (currentTask != null)
                    {
                        App.DataBase.SaveChanges();
                        CustomMessageBox.Show("Успешно", "Изменения сохранены!");
                        Manager._frame.Navigate(new PageProject(currentTask.Project));
                    }

                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Ошибка", ex.ToString());
                }
            }
            
        }
        
        private bool CheckTask(Entities.Task task)
        {
            StringBuilder errors = new StringBuilder();
            
            if (string.IsNullOrWhiteSpace(task.Name))
                errors.AppendLine("Введите название задачи.");
            if (task.Status == null)
                errors.AppendLine("Выберите статус задачи.");
            if (task.TypeOfWork == null)
                errors.AppendLine("Выберите тип работы.");
            if (task.Mycroobject == null)
                errors.AppendLine("Выберите микрообъект.");
            
            if(errors.Length > 0)
            {
                CustomMessageBox.Show("Внимание", errors.ToString());
                return false;
            }
            return true;
        }
    }
}
