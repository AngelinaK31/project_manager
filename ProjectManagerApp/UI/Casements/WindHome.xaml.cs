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
    public partial class WindHome : Window
    {
        public WindHome(Entities.User user)
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
            Window winAuth = new WindAuth();
            winAuth.Show();
            Close();
        }


        private void ListViewItemCLick(object sender, MouseButtonEventArgs e)
        {

            MainFrame.Navigate(new Pages.PageProject(((ListViewItem)sender).DataContext as Entities.Project));
        }

        private void btnCloseWind(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Drag(object sender, DragEventArgs e)
        {
            
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
               
                this.DragMove();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Normal;
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void btnResizeClick(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnHideClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
