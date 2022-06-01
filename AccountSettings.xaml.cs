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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace EMS
{
    /// <summary>
    /// Interaction logic for AccountSettings.xaml
    /// </summary>
    public partial class AccountSettings : Page
    {
        public AccountSettings()
        {
            InitializeComponent();
            getUser();
        }

        private void changeNameBtn_Click(object sender, RoutedEventArgs e)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            string id = userId.Text;
            string name = nameTxtBox.Text;
            try
            {
                using var con = new SQLiteConnection(cs);
                con.Open();

                using var cmd = new SQLiteCommand(con);

                cmd.CommandText = "UPDATE user SET name = @name WHERE id = @id";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                MessageWindow msg = new MessageWindow();
                msg.message.Text = "Name Saved";
                msg.ShowDialog();

                getUser();

                nameTxtBox.Visibility = Visibility.Hidden;
                nameTxtBlock.Visibility = Visibility.Visible;

                editNameBtn.Visibility = Visibility.Visible;
                cancelNameBtn.Visibility = Visibility.Hidden;
                changeNameBtn.Visibility = Visibility.Hidden;
            }
            catch(Exception err)
            {
                MessageWindow msg = new MessageWindow();
                msg.message.Text = err.ToString();
                msg.ShowDialog();
            }
        }

        private void editNameBtn_Click(object sender, RoutedEventArgs e)
        {
            nameTxtBox.Text = nameTxtBlock.Text;
            nameTxtBox.Visibility = Visibility.Visible;
            nameTxtBlock.Visibility = Visibility.Hidden;

            editNameBtn.Visibility = Visibility.Hidden;
            cancelNameBtn.Visibility = Visibility.Visible;
            changeNameBtn.Visibility = Visibility.Visible;

        }

        private void cancelNameBtn_Click(object sender, RoutedEventArgs e)
        {
            nameTxtBox.Visibility = Visibility.Hidden;
            nameTxtBlock.Visibility = Visibility.Visible;

            editNameBtn.Visibility = Visibility.Visible;
            cancelNameBtn.Visibility = Visibility.Hidden;
            changeNameBtn.Visibility = Visibility.Hidden;
        }

        private void getUser()
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";

            try
            {
                using var con = new SQLiteConnection(cs);
                con.Open();

                string stm = "SELECT * FROM 'user'";

                using var cmd = new SQLiteCommand(stm, con);
                using SQLiteDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        userId.Text = rdr.GetInt32(0).ToString();
                        nameTxtBlock.Text = rdr.GetString(1);
                    }
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageWindow msg = new MessageWindow();
                msg.message.Text = err.ToString();
                msg.ShowDialog();
            }
            
        }

        private void changePwdBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmPassword conPwd = new ConfirmPassword();
            conPwd.ShowDialog();
        }
    }
}
