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
using EMS.Models;

namespace EMS
{
    /// <summary>
    /// Interaction logic for SelectStudent.xaml
    /// </summary>
    public partial class SelectStudent : Window
    {
        public SelectStudent()
        {
            InitializeComponent();
            fetchStudent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        private void fetchStudent()
        {
            studentsList.Items.Clear();

            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'students'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Student student = new Student();

                student.id = rdr.GetInt32(0);

                student.lastName = rdr.GetString(1);
                student.firstName = rdr.GetString(2);
                student.middleName = rdr.GetString(3);

                studentsList.Items.Add(student);
            }
        }

        private void searchStudents_Click(object sender, RoutedEventArgs e)
        {
            string search = searchStudentTxtBox.Text;

            string cs = "Data Source=.\\EmsDB.db;Version=3";

            studentsList.Items.Clear();

            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM students WHERE lastName LIKE @search or firstName LIKE @search or middleName LIKE @search";

            using var cmd = new SQLiteCommand(stm, con);

            cmd.Parameters.AddWithValue("@search", "%" + search + "%");
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Student student = new Student();

                student.id = rdr.GetInt32(0);

                student.lastName = rdr.GetString(1);
                student.firstName = rdr.GetString(2);
                student.middleName = rdr.GetString(3);

                studentsList.Items.Add(student);
            }
        }

        public void selectStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            Student selectedStudent = ((FrameworkElement)sender).DataContext as Student;

            hiddenStudentId.Text = selectedStudent.id.ToString();
            Close();
        }      
    }
}
