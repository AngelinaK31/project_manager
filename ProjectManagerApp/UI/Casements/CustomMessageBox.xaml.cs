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
    /// Логика взаимодействия для CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window 
    {
        public CustomMessageBox()
        {
            InitializeComponent();
            
           
        }

        public CustomMessageBox(string title, string description)
        {
            InitializeComponent();

            btnOK.Focus();

            Title = title;
            tbxDesciption.Text = description;
        }

        public static void Show(string title, string description)
        {
            var wind = new CustomMessageBox(title, description);

            wind.ShowDialog();

           
        }

        private void btnOKClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    


}
