using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Serialization;

namespace ProjectManagerApp.Styles
{
    public partial class MessageBoxStyle
    {
        private void WindLoaded (object sender, RoutedEventArgs e)
        {
            (sender as System.Windows.Window).StateChanged += WindStateChanged;
        }

        private void WindStateChanged(object sender, EventArgs e)
        {
            System.Windows.Window me = (sender as System.Windows.Window);
            Button btnResizeCaption = me.Template.FindName("btnResize", me) as Button;
            if(btnResizeCaption != null)
            {
                btnResizeCaption.Content = me.WindowState == System.Windows.WindowState.Maximized ? "2" : "1";
            }
        }

        private void btnCloseClick( object sender, RoutedEventArgs e)
        {
            ((sender as FrameworkElement).TemplatedParent as System.Windows.Window).Close();
        }

        private void btnResizeClick(object sender, RoutedEventArgs e)
        {
            ((sender as FrameworkElement).TemplatedParent as System.Windows.Window)
                .WindowState = (((sender as FrameworkElement).TemplatedParent as System.Windows.Window)
                .WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }

        private void btnHideClick(object sender, RoutedEventArgs e)
        {
            ((sender as FrameworkElement).TemplatedParent as System.Windows.Window)
                .WindowState = WindowState.Minimized;
        }

        private void gMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if (((sender as FrameworkElement).TemplatedParent as System.Windows.Window)
                .WindowState == WindowState.Maximized)
                {
                    ((sender as FrameworkElement).TemplatedParent as System.Windows.Window)
                .WindowState = WindowState.Normal;
                    
                }
                    

                ((sender as FrameworkElement).TemplatedParent as System.Windows.Window)
                 .DragMove();
            }
        }
    }
}
