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
    public partial class WindAuth : Window
    {
        public WindAuth()
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
            tbxLogin.IsEnabled = false;
            tbxPassword.IsEnabled = false;
            pwdPassword.IsEnabled = false;
            btnLogIn.IsEnabled = false;

            var users = App.DataBase.Users.ToList();
            Entities.User currentUser = null;
            

            if (string.IsNullOrWhiteSpace(tbxLogin.Text) || string.IsNullOrWhiteSpace(tbxPassword.Text))
            {
                CustomMessageBox.Show("Ошибка",$"Введите логин и пароль!");
                tbxLogin.IsEnabled = true;
                tbxPassword.IsEnabled = true;
                pwdPassword.IsEnabled = true;
                btnLogIn.IsEnabled = true;
                return;
            }

            if (Classes.Authorization.LogIn(tbxLogin.Text, tbxPassword.Text, users, out currentUser))
            {
                CustomMessageBox.Show("", $"Добро пожаловать, {currentUser.FirstName} {currentUser.Patronymic}!") ;
                Window windHome = new WindHome(currentUser);
                windHome.Show();
                Close();
            }
            else
            {
                CustomMessageBox.Show("Ошибка", $"Неправильно введен логин или пароль!");
                tbxLogin.IsEnabled = true;
                tbxPassword.IsEnabled = true;
                pwdPassword.IsEnabled = true;
                btnLogIn.IsEnabled = true;
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
