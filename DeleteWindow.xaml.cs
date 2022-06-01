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
    /// Interaction logic for DeleteCourse.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
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

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            string table = tableParameter.Text;
            string id = idParameter.Text;

            string cs = "Data Source=.\\EmsDB.db;Version=3";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            if (table == "courses")
            {
                cmd.CommandText = "DELETE from courses WHERE id = @id";
            }
            else if (table == "students")
            {
                cmd.CommandText = "DELETE from students WHERE id = @id";
            }

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Prepare();
            cmd.ExecuteNonQuery();

            Close();

            MessageWindow message = new MessageWindow();
            message.message.Text = "Information Deleted";
            message.ShowDialog();
        }
    }
}
