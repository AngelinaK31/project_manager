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

namespace ProjectManagerApp.UI.UCs
{
    /// <summary>
    /// Логика взаимодействия для UCReport.xaml
    /// </summary>
    public partial class UCReport : UserControl
    {
        public  string ReportName { get; set; }
        public  string ImageSource { get; set; }
        public UCReport()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Grid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Classes.Manager._frame.Navigate(new Pages.PageGanttReport());
        }

        
    }
}
