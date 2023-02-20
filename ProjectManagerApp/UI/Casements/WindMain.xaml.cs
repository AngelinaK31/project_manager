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
using System.Windows.Shapes;

namespace ProjectManagerApp.UI.Casements
{
    /// <summary>
    /// Логика взаимодействия для WindMain.xaml
    /// </summary>
    public partial class WindMain : Window
    {
        public WindMain(Entities.User user)
        {
            InitializeComponent();

            
            lvCurrentProjects.ItemsSource = App.DataBase.Projects.Where(p=>p.IsCompleted == false).ToList();
            lvOldProjects.ItemsSource = App.DataBase.Projects.Where(p => p.IsCompleted == true).ToList();
        }

        


        private void btnCurrentProjectsClick(object sender, RoutedEventArgs e)
        {
            if(lvCurrentProjects.Visibility == Visibility.Collapsed)
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

        private void btnExitClick(object sender, RoutedEventArgs e)
        {
            Window winHome = new WindHome();
            winHome.Show();
            Close();
        }


        private void ListViewItemCLick(object sender, MouseButtonEventArgs e)
        {

            MainFrame.Navigate(new Pages.PageProject(((ListViewItem)sender).DataContext as Entities.Project));
        }
    }
}
