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
            if(task != null )
            {
                _task = task;
                
            }
            else
            {
                _task.CreationDate = DateTime.Now.Date;
                _task.Status = status;
                _task.Deadline = DateTime.Now.Date;
                dpTaskDeadline.DisplayDateStart = _task.CreationDate;
                _task.Project = PageProject._project;

            }
            DataContext = _task;


            if (_task.StatusId == 4 )
            {
                tblTaskCompletion.Visibility = Visibility.Visible;
                dpTaskCompletion.Visibility = Visibility.Visible;
            }


            
            cbTaskMycroobject.ItemsSource = App.DataBase.Mycroobjects.ToList();
            cbTaskTypeOfWork.ItemsSource = App.DataBase.TypeOfWorks.ToList();
            cbTaskExecutor.ItemsSource = App.DataBase.Users.ToList();
            cbTaskStatus.ItemsSource = App.DataBase.Status.ToList();

            
            

        }

       

        private void btnSaveClik(object sender, RoutedEventArgs e)
        {
            

            var currentTask = _task;
            if (_task.Deadline < _task.CreationDate)
            {
                MessageBox.Show("Дейдлайн не может быть до начала создания проекта");
                return;
            }
            if (_task.Id == 0)
            {
                App.DataBase.Tasks.Add(_task);
            }
            try
            {
                if (_task != null)
                {
                    App.DataBase.SaveChanges();
                    MessageBox.Show("Изменения сохранены!");
                    InitializeComponent();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
