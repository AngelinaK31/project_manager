﻿using ProjectManagerApp.Classes;
using ProjectManagerApp.Entities;
using ProjectManagerApp.UI.Casements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManagerApp.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProject.xaml
    /// </summary>
    public partial class PageProject : Page
    {
        public static Project _project;
        public PageProject(Project project)
        {
            InitializeComponent();

            if (UserHolder.User.TypeOfUserId == 3)
            {
                lvCurrentProjects.ItemsSource = App.DataBase.Projects.Where(p => p.IsCompleted == false).ToList();
                lvOldProjects.ItemsSource = App.DataBase.Projects.Where(p => p.IsCompleted == true).ToList();
            }
            else
            {
                lvCurrentProjects.ItemsSource = App.DataBase.Projects.Where(p => p.IsCompleted == false && p.ProjectTeam.Id == UserHolder.User.ProjectTeamId).ToList();
                lvOldProjects.ItemsSource = App.DataBase.Projects.Where(p => p.IsCompleted == true && p.ProjectTeam.Id == UserHolder.User.ProjectTeamId).ToList();

            }

            if (UserHolder.User.TypeOfUserId != 1)
            {
                spEditProject.Visibility = Visibility.Hidden;
                spEditProject.IsEnabled = false;
                btnAddProject.Visibility = Visibility.Collapsed;
            }

            if (project == null)
            {
                spProjects.Visibility = Visibility.Visible;
                return;
            }

            


          

            if (project.Tasks.Count()>0 && project.Tasks.Where(t=>t.StatusId == 4).Count() == project.Tasks.Count())
            {
                if (CustomMessageBoxYesNo.Show("Сообщение","Все задачи выполнены. Завершить проект?"))
                {
                    _project.IsCompleted = true;
                    _project.CompletionDate = DateTime.Now.Date;
                    App.DataBase.SaveChanges();
                }
            }

                _project = project;
                DataContext = project;

                if (project.Deadline == null)
                {
                    spDescription.Visibility = Visibility.Collapsed;
                }

                List<Entities.Task> currentProjectTasks = App.DataBase.Tasks.Where(t=> t.ProjectId == project.Id).ToList();

                listStat1.Status = App.DataBase.Status.First(s => s.Id == 1);
                listStat1.Tasks = currentProjectTasks.Where(t=>t.StatusId == 1).ToList();
                listStat2.Status = App.DataBase.Status.First(s => s.Id == 2);
                listStat2.Tasks = currentProjectTasks.Where(t => t.StatusId == 2).ToList();
                listStat3.Status = App.DataBase.Status.First(s => s.Id == 3);
                listStat3.Tasks = currentProjectTasks.Where(t => t.StatusId == 3).ToList();
                listStat4.Status = App.DataBase.Status.First(s => s.Id == 4);
                listStat4.Tasks = currentProjectTasks.Where(t => t.StatusId == 4).ToList();

                var laborCost = LaborCost.CalcLaborCost(project);
                tblLaborCost.Text = $"Трудозатраты - {laborCost}ч.";
           
        }

       
        private void btnEditInfoClick(object sender, RoutedEventArgs e)
        {
            tbxName.IsEnabled = true;
            tbxDescription.IsEnabled = true;
           
            tpDeadline.IsEnabled = true;

            btnEditInfo.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Visible;

        }

        private void btnSaveClik(object sender, RoutedEventArgs e)
        {
            tbxName.IsEnabled = false;
            tbxDescription.IsEnabled = false;
            
            tpDeadline.IsEnabled = false;

            btnEditInfo.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Collapsed;

            var currentProject = _project;
            if(currentProject.Deadline < currentProject.CreationDate)
            {
                MessageBox.Show("Дедлайн не может быть до начала создания проекта");
                return;
            }
            if (string.IsNullOrWhiteSpace(currentProject.Name))
            {
                MessageBox.Show("Ввдите наименование проекта");
                return;
            }
            try
            {
                if (currentProject != null)
                {
                    
                    App.DataBase.SaveChanges();
                    MessageBox.Show("Изменения сохранены!");
                    this.InitializeComponent();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

      

        private void btnHideInfoClick(object sender, RoutedEventArgs e)
        {
            gInfo.Visibility = Visibility.Collapsed;
        }

        private void btnShowInfoClick(object sender, RoutedEventArgs e)
        {
            gInfo.Visibility = Visibility.Visible;
            
        }

        private void btnAddProjectClick(object sender, RoutedEventArgs e)
        {
           
            Manager._frame.Navigate(new PageAddProject());
        }

        private void btnCurrentProjectsClick(object sender, RoutedEventArgs e)
        {
            if (lvCurrentProjects.Visibility == Visibility.Collapsed)
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
        private void ListViewItemCLick(object sender, MouseButtonEventArgs e)
        {
            spProjects.Visibility = Visibility.Collapsed;
            Manager._frame.Navigate(new PageProject(((ListViewItem)sender).DataContext as Project));
            
        }

        private void btnDelProjectClick(object sender, RoutedEventArgs e)
        {
            var tasks = _project.Tasks.ToList();
            if(CustomMessageBoxYesNo.Show("Предупреждение", "Вы точно хотите удалить этот проект?"))
            {
               if(tasks.Count > 0)
                {
                    foreach(var task in tasks)
                    {
                        App.DataBase.Tasks.Remove(task);
                    }
                }
                App.DataBase.Projects.Remove(_project);
                try
                {
                    
                    App.DataBase.SaveChanges();
                    CustomMessageBox.Show("Успешно", "Проект успешно удален");
                    Manager._frame.Navigate(new PageProject(null));
                }
                catch(Exception ex)
                {
                    CustomMessageBox.Show("Ошибка", ex.Message.ToString());
                }
            }
            

        }

        private void btnInfoClick(object sender, RoutedEventArgs e)
        {
            Manager._frame.Navigate(new PageInfo());
        }
    }
}
