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
    /// Interaction logic for AdministratorEdit.xaml
    /// </summary>
    public partial class AdministratorEdit : Window
    {
        public AdministratorEdit()
        {
            InitializeComponent();
        }

        //top bar functions
        public void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        //top bar functions

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string id = idTxtBox.Text;
            string name = nameTxtBox.Text;

            if (name == "")
            {
                name = "Not specified";
            }

            string cs = "Data Source=.\\EmsDB.db;Version=3";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = "UPDATE administrators SET name = @name WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);

            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Close();
        }
    }
}
