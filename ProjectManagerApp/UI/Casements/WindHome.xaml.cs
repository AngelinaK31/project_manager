using ProjectManagerApp.Classes;
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

            UserHolder.User = user;
            Manager._frame = MainFrame;

            Manager._frame.Navigate(new Pages.PageHome());


            if (user.TypeOfUserId == 2 )
            {
                btnReport.Visibility = Visibility.Hidden;
                btnReport.IsEnabled = false;
            }
        }

        


        

       

        private void btnExitClick(object sender, RoutedEventArgs e)
        {
            Window winAuth = new WindAuth();
            winAuth.Show();
            Close();
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

        private void btnBackClick(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void MainFrameContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else
                btnBack.Visibility = Visibility.Collapsed;
        }

        private void btnPageTeamsClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageTeams());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageProject(null));
        }

        private void btnReportClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageReports());
        }

        private void BtnHomeClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.PageHome());
        }
    }
}
