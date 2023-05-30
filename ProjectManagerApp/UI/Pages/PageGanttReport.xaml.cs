using nGantt.GanttChart;
using nGantt.PeriodSplitter;
using ProjectManagerApp.UI.Casements;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Runtime.Serialization;
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
    /// Логика взаимодействия для PageGanttReport.xaml
    /// </summary>
    public partial class PageGanttReport : Page
    {
        private ObservableCollection<ContextMenuItem> ganttTaskContextMenuItems = new ObservableCollection<ContextMenuItem>();
        private ObservableCollection<SelectionContextMenuItem> selectionContextMenuItems = new ObservableCollection<SelectionContextMenuItem>();

        public PageGanttReport()
        {
            InitializeComponent();

            cbProjects.ItemsSource = App.DataBase.Projects.ToList();

           

        }

        private void NewClicked(Period selectionPeriod)
        {
            MessageBox.Show("New clicked for task " + selectionPeriod.Start.ToString() + " -> " + selectionPeriod.End.ToString());
        }

        private void ViewClicked(GanttTask ganttTask)
        {
            MessageBox.Show("New clicked for task " + ganttTask.Name);
        }

        private void EditClicked(GanttTask ganttTask)
        {
            MessageBox.Show("Edit clicked for task " + ganttTask.Name);
        }

        private void DeleteClicked(GanttTask ganttTask)
        {
            MessageBox.Show("Delete clicked for task " + ganttTask.Name);
        }

        void gantReport_GanttRowAreaSelected(object sender, PeriodEventArgs e)
        {
            MessageBox.Show(e.SelectionStart.ToString() + " -> " + e.SelectionEnd.ToString());
        }

        private string FormatYear(Period period)
        {
            return period.Start.Year.ToString();
        }

        private string FormatMonth(Period period)
        {
            return period.Start.Month.ToString();
        }

        private string FormatDay(Period period)
        {
            return period.Start.Day.ToString();
        }

        private string FormatDayName(Period period)
        {
            return period.Start.ToString("ddd");
        }

        private System.Windows.Media.Brush DetermineBackground(TimeLineItem timeLineItem)
        {
            if (timeLineItem.End.Date.DayOfWeek == DayOfWeek.Saturday || timeLineItem.End.Date.DayOfWeek == DayOfWeek.Sunday)
                return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightCoral);
            else
                return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Transparent);
        }

        private void btnFormDiagClick(object sender, RoutedEventArgs e)
        {
            btnPrint.Visibility = Visibility.Collapsed;
            gantReport.ClearGantt();
            if(cbProjects.SelectedItem == null)
            {
                CustomMessageBox.Show("Внимание", "Выберите проект");
                return;
            }
            var selectedProject = cbProjects.SelectedItem as Entities.Project;

            DateTime minDate = (DateTime)dpStartDate.SelectedDate;
            DateTime maxDate = (DateTime)dpEndDate.SelectedDate;

            if (dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null)
            {
                CustomMessageBox.Show("Внимание", "Выберите дату");
                return;
            }
            if (dpStartDate.SelectedDate > dpEndDate.SelectedDate)
            {
                CustomMessageBox.Show("Внимание", "Дата начала не может быть позже даты окончания отчетного периода");
                return;
            }

            int tasksPerSelectedDates=0;
            foreach (var projectTask in selectedProject.Tasks)
            {
                if (projectTask.CreationDate > maxDate || projectTask.Deadline < minDate)
                {
                    tasksPerSelectedDates++;
                }
            }
            if(tasksPerSelectedDates == selectedProject.Tasks.Count())
            {
                CustomMessageBox.Show("Внимание", "За данный отчетный период отсутсвуют задачи");
                return;
            }
            btnPrint.Visibility = Visibility.Visible;
                // Set selection -mode
                gantReport.TaskSelectionMode = nGantt.GanttControl.SelectionMode.Single;
            // Enable GanttTasks to be selected
            gantReport.AllowUserSelection = true;

            // listen to the GanttRowAreaSelected event
            gantReport.GanttRowAreaSelected += new EventHandler<PeriodEventArgs>(gantReport_GanttRowAreaSelected);

            // define ganttTask context menu and action when each item is clicked
            ganttTaskContextMenuItems.Add(new ContextMenuItem(ViewClicked, "View..."));
            ganttTaskContextMenuItems.Add(new ContextMenuItem(EditClicked, "Edit..."));
            ganttTaskContextMenuItems.Add(new ContextMenuItem(DeleteClicked, "Delete..."));
            gantReport.GanttTaskContextMenuItems = ganttTaskContextMenuItems;

            // define selection context menu and action when each item is clicked
            selectionContextMenuItems.Add(new SelectionContextMenuItem(NewClicked, "New..."));
            gantReport.SelectionContextMenuItems = selectionContextMenuItems;

            
            
            
            gantReport.Initialize(minDate, maxDate);





            gantReport.CreateTimeLine(new PeriodYearSplitter(minDate, maxDate), FormatYear);
            gantReport.CreateTimeLine(new PeriodMonthSplitter(minDate, maxDate), FormatMonth);
            var gridLineTimeLine = gantReport.CreateTimeLine(new PeriodDaySplitter(minDate, maxDate), FormatDay);
            gantReport.CreateTimeLine(new PeriodDaySplitter(minDate, maxDate), FormatDayName);

            // Set the timeline to atatch gridlines to
            gantReport.SetGridLinesTimeline(gridLineTimeLine, DetermineBackground);

            // Create and data
            var rowgroup1 = gantReport.CreateGanttRowGroup("");
            
            foreach (var projectTask in selectedProject.Tasks)
            {
                if((projectTask.CreationDate <= minDate && projectTask.Deadline >= minDate) || (projectTask.CreationDate >= minDate && projectTask.CreationDate <=  maxDate))
                {
                    var row = gantReport.CreateGanttRow(rowgroup1, projectTask.Name);
                    gantReport.AddGanttTask(row, new GanttTask() { Start = projectTask.CreationDate, End = projectTask.Deadline, Name = projectTask.Name, TaskProgressVisibility = System.Windows.Visibility.Hidden });

                }

            }
            
            

        }

        private void btnPrintClick(object sender, RoutedEventArgs e)
        {
            
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(gantReport, "Распечатка диаграммы Ганта");
                CustomMessageBox.Show("Сообщение", "Документ успешно напечатан");
            }
        }

        private void dpStartDateSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var startDate = (DateTime)dpStartDate.SelectedDate;
            var endDate = startDate.AddDays(30);
            dpEndDate.DisplayDateStart = startDate;
            dpEndDate.DisplayDateEnd = endDate;
        }
    }
}
