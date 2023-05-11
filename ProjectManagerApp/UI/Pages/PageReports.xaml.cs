using nGantt.GanttChart;
using nGantt;
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
using System.Collections.ObjectModel;
using nGantt.PeriodSplitter;
using System.Runtime.Serialization;

namespace ProjectManagerApp.UI.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageReports.xaml
    /// </summary>
    public partial class PageReports : Page
    {
        
        
        public PageReports()
        {
            InitializeComponent();
        }

        private void Grid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Classes.Manager._frame.Navigate(new Pages.PageGanttReport());
        }
    }
}
