using ProjectManagerApp.Classes;
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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManagerApp.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageHome.xaml
    /// </summary>
    public partial class PageHome : Page
    {
        public PageHome()
        {
            InitializeComponent();

            tbHello.Text = UserHolder.User.FullNameRow;

            var tasks = UserHolder.User.Tasks.ToList();


            tbTaskCount.Text = UserHolder.User.Tasks.Where(task=> task.CompletionDate?.Date == DateTime.Now.Date).Count().ToString();

            lvTasks.ItemsSource = App.DataBase.Tasks.Where(task => task.ExecutorId == UserHolder.User.Id && task.StatusId != 4).ToList();

        }

        
    }
}
