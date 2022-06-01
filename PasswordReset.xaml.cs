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
    /// Interaction logic for PasswordReset.xaml
    /// </summary>
    public partial class PasswordReset : Window
    {
        
        public PasswordReset()
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

        private void resetPwdBtn_Click(object sender, RoutedEventArgs e)
        {
            string password = "";
            string confirmPWD = confirmPassword.Password;


            if (passwordPwd.IsVisible)
            {
                password = passwordPwd.Password;
            }
            else if (passwordTxt.IsVisible)
            {
                password = passwordTxt.Text;
            }


            if (password != confirmPWD)
            {
                MessageWindow msg = new MessageWindow();
                msg.message.Text = "Confirm password do not match.";
                msg.ShowDialog();
            }
            else if (password.Length < 6 || password.Length > 12)
            {
                MessageWindow msg = new MessageWindow();
                msg.message.Text = "Minimum of 6 characters and maximum of 12 characters is required for password.";
                msg.ShowDialog();
            }
            else
            {
                var pwdByte = System.Text.Encoding.UTF8.GetBytes(password);
                password = System.Convert.ToBase64String(pwdByte);
                try
                {
                    changePassowrd(password);
                    MessageWindow msg = new MessageWindow();
                    msg.message.Text = "Password Changed";
                    msg.ShowDialog();
                    Close();

                    
                }
                catch (Exception err)
                {
                    MessageWindow msg = new MessageWindow();
                    msg.message.Text = err.ToString();
                    msg.ShowDialog();
                }
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

        private void changePassowrd(string password)
        {
            int id = getUserId();

            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = "UPDATE user SET password = @password WHERE id = @id";

            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Prepare();

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private int getUserId()
        {
            int id = 0;

            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT id FROM 'user'";
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
            }

            return id;
        }
    }
}
