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
    /// Interaction logic for ConfirmPassword.xaml
    /// </summary>
    public partial class ConfirmPassword : Window
    {
        public ConfirmPassword()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void submitPwd_Click(object sender, RoutedEventArgs e)
        {
            string password = "";

            if (passwordPwd.IsVisible)
            {
                password = passwordPwd.Password;
            }
            else if (passwordTxt.IsVisible)
            {
                password = passwordTxt.Text;
            }

            if (!checkPassword(password))
            {
                MessageWindow msg = new MessageWindow();
                msg.message.Text = "Incorrect Password";
                msg.ShowDialog();
            } else
            {
                Close();
                PasswordReset pwd = new PasswordReset();
                pwd.resetPwdBtn.Content = "Change Password";
                pwd.Show();

            }
            
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

        private bool checkPassword(string password)
        {
            string userPwd = "";

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

            return userPwd == passwordHash;
        }
    }
}
