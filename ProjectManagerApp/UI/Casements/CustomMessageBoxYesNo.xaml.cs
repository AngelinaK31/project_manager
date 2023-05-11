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
    public partial class CustomMessageBoxYesNo : Window 
    {
        private static bool _result {  get; set; }
        public CustomMessageBoxYesNo()
        {
            InitializeComponent();
            
           
        }

        public CustomMessageBoxYesNo(string title, string description)
        {
            InitializeComponent();

           

            Title = title;
            tbxDesciption.Text = description;
        }

        public static bool Show(string title, string description)
        {
            var wind = new CustomMessageBoxYesNo(title, description);

            wind.ShowDialog();

            var result = _result;
            return result;
           
        }


        private void btnYesClick(object sender, RoutedEventArgs e)
        {
            _result = true;
            Close();
        }

        private void btnNoClick(object sender, RoutedEventArgs e)
        {
            _result = false;
            Close();

        }
    }

    


}
