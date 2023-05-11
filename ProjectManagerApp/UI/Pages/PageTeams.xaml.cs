using ProjectManagerApp.Classes;
using ProjectManagerApp.UI.Casements;
using ProjectManagerApp.UI.UCs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для PageTeams.xaml
    /// </summary>
    /// 
    
    public partial class PageTeams : Page
    {
        private Entities.User _user = new Entities.User();
        public PageTeams()
        {
            InitializeComponent();

            fillDG();
            
            if(UserHolder.User.TypeOfUser.Id == 3)
            {
                cbGender.ItemsSource = App.DataBase.Genders.ToList();
                cbSpecialization.ItemsSource = App.DataBase.Specializations.ToList();
            }
            else
            {
                spTeamsEdit.Visibility = Visibility.Hidden; 
                spTeamsEdit.IsEnabled = false;
            }

           
            
        }

        private void btnAddNewUserClick(object sender, RoutedEventArgs e)
        {
            if(_user != null)
            {
                _user.TypeOfUserId = 2;

                try
                {
                    App.DataBase.Users.Add(_user);
                    App.DataBase.SaveChanges();
                    CustomMessageBox customMessage = new CustomMessageBox("Сообщение", "Сотрудник успешно добавлен");
                    customMessage.ShowDialog();
                    fillDG();
                }
                catch (DbEntityValidationException ex)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        sb.AppendLine("Object: " + validationError.Entry.Entity.ToString());
                        
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            sb.AppendLine(err.ErrorMessage + "");
                        }
                    }
                    CustomMessageBox customMessage = new CustomMessageBox("Ошибка", sb.ToString());
                    customMessage.ShowDialog();
                }
            }
        }

        private void btnShowAddUserClick(object sender, RoutedEventArgs e)
        {

            spAddUser.Visibility = Visibility.Visible;
            spAddUser.DataContext = _user;

            DataContext = _user;

            cbTeam.ItemsSource = App.DataBase.ProjectTeams.ToList();
        }

        private void fillDG()
        {
            var users = App.DataBase.Users.ToList();
            ListCollectionView dgUsers = new ListCollectionView(users);

            dgUsers.GroupDescriptions.Add(new PropertyGroupDescription("ProjectTeam.Id"));

            dgTeams.ItemsSource = dgUsers;
        }

        private void btnAddTeamClick(object sender, RoutedEventArgs e)
        {
            Entities.ProjectTeam _team = new Entities.ProjectTeam();
            App.DataBase.ProjectTeams.Add(_team);
            try
            {
                App.DataBase.SaveChanges();
                CustomMessageBox.Show("Сообщение", "Команда успешно добавлена");
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Ошибка", ex.Message.ToString());
            }
        }

        private void btnDeleteRecieverClick(object sender, RoutedEventArgs e)
        {
            var user = (sender as Button).DataContext as Entities.User;
            App.DataBase.Users.Remove(user);
            App.DataBase.SaveChanges();
            fillDG();
        }
    }
}
