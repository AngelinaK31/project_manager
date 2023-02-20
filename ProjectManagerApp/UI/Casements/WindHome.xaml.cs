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
    /// Логика взаимодействия для WindHome.xaml
    /// </summary>
    public partial class WindHome : Window
    {
        public WindHome()
        {
            InitializeComponent();
        }

        private void btnShowPwdClick(object sender, RoutedEventArgs e)
        {
            if(tbxPassword.Visibility == Visibility.Visible)
            {
                tbxPassword.Visibility = Visibility.Collapsed;
                pwdPassword.Visibility = Visibility.Visible;
            }
            else
            {
                pwdPassword.Visibility = Visibility.Collapsed;
                tbxPassword.Visibility = Visibility.Visible;
            }
        }

        private void tbxPasswordKeyUp(object sender, KeyEventArgs e)
        {
            pwdPassword.Password = tbxPassword.Text;
        }

        private void pwdPasswordKeyUp(object sender, KeyEventArgs e)
        {
            tbxPassword.Text = pwdPassword.Password;
        }

        private void btnLogInClick(object sender, RoutedEventArgs e)
        {
            var users = App.DataBase.Users.ToList();
            Entities.User currentUser = null;

            if (string.IsNullOrWhiteSpace(tbxLogin.Text) || string.IsNullOrWhiteSpace(tbxPassword.Text))
            {
                MessageBox.Show($"Введите логин и пароль!");
                return;
            }

            if (Classes.Authorization.LogIn(tbxLogin.Text, tbxPassword.Text, users, out currentUser))
            {
                MessageBox.Show($"Добро пожаловать, {currentUser.FirstName} {currentUser.Patronymic}!") ;
                Window windMain = new WindMain(currentUser);
                windMain.Show();
                Close();
            }
            else
            {
                MessageBox.Show($"Неправильно введен логин или пароль!");
            }
        }

        private void btnCloseWind(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Drag(object sender, DragEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
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
