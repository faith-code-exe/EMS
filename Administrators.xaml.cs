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
using EMS.Models;

namespace EMS
{
    /// <summary>
    /// Interaction logic for Administrators.xaml
    /// </summary>
    public partial class Administrators : Page
    {
        string cs = "Data Source=.\\EmsDB.db;Version=3";

        public Administrators()
        {
            InitializeComponent();
            fetchAdministrators();
        }

        private void fetchAdministrators()
        {

            administratorsList.Items.Clear();
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'administrators'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Administrator administrator = new Administrator();

                administrator.id = rdr.GetInt32(0);
                administrator.position = rdr.GetString(1);
                administrator.name = rdr.GetString(2);

                administratorsList.Items.Add(administrator);
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            Administrator administrator = ((FrameworkElement)sender).DataContext as Administrator;

            int id = administrator.id;
            string position = administrator.position;
            string name = administrator.name;

            AdministratorEdit editAdministrator = new AdministratorEdit();

            editAdministrator.idTxtBox.Text = id.ToString();

            editAdministrator.adminEdtHdr.Text = "Set Name for " + position;

            if (name == "Not yet specified" || name == "Not specified")
            {
                editAdministrator.nameTxtBox.Text = "";
            } else
            {
                editAdministrator.nameTxtBox.Text = name;
            }

            editAdministrator.ShowDialog();
            fetchAdministrators();
        }
    }
}
