using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Data.SQLite;

namespace EMS
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            //char c = '\u2022';
            
        }

        

        private void Close(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {

            string password = "";
            string userPwd = "";

            if (passwordPwd.IsVisible)
            {
                password = passwordPwd.Password;
            }
            else if (passwordTxt.IsVisible)
            {
                password = passwordTxt.Text;
            }

            string cs = "Data Source=.\\EmsDB.db;Version=3";

            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM user";

            using var cmd = new SQLiteCommand(stm, con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                userPwd = rdr.GetString(2);
            }


            var passwordHashByte = System.Text.Encoding.UTF8.GetBytes(password);
            string passwordHash = System.Convert.ToBase64String(passwordHashByte);


            if (passwordHash != userPwd)
            {
                MessageWindow message = new MessageWindow();
                message.message.Text = "Incorrect Password";
                message.ShowDialog();
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                Close();
                mainWindow.Show();
            }
            
            /*
            var passwordHashByte = System.Text.Encoding.UTF8.GetBytes(passwordPwd.Password);
            string passwordHash = System.Convert.ToBase64String(passwordHashByte);

            var passwordText = System.Convert.FromBase64String(passwordHash);
            string passwordString = System.Text.Encoding.UTF8.GetString(passwordText);

            MessageBox.Show("hash :" + passwordHash + "\n" + "text: " + passwordString);
            */
        }

        private void forgetPwd_CLick(object sender, RoutedEventArgs e)
        {  
            ForgetPassword forgetPwd = new ForgetPassword();
            forgetPwd.ShowDialog();
        }

        private void showPwd(object sender, RoutedEventArgs e)
        {
            passwordPwd.Visibility = Visibility.Hidden;
            passwordTxt.Visibility = Visibility.Visible;
            passwordTxt.Text = passwordPwd.Password;
        }

        private void hidePwd(object sender, RoutedEventArgs e)
        {
            passwordPwd.Visibility = Visibility.Visible;
            passwordTxt.Visibility = Visibility.Hidden;
            passwordPwd.Password = passwordTxt.Text;
        }
    }
}
