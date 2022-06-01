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

using System.ComponentModel;
using System.Runtime.CompilerServices;

using System.Data.SQLite;



namespace EMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool isOpen = false;

        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Dashboard();
            this.isOpen = true;
        }


        // pages navigations
        private void ViewStudents(object sender, RoutedEventArgs e)
        {
            Main.Content = new Students();
        }
        private void ViewDashboard(object sender, RoutedEventArgs e)
        {
            Main.Content = new Dashboard();
        }
        private void ViewCourses(object sender, RoutedEventArgs e)
        {
            Main.Content = new Courses();
        }
        private void ViewAdministrators(object sender, RoutedEventArgs e)
        {
            Main.Content = new Administrators();
        }
        private void ViewPrint(object sender, RoutedEventArgs e)
        {
            Main.Content = new Print();
        }
        private void ViewAccountSettings(object sender, RoutedEventArgs e)
        {
            Main.Content = new AccountSettings();
        }
        // end of pages navigations









        
        public void Close(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        

        
        public void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void maximize_restore(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }
    }
}
