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
    /// Interaction logic for SelectCourse.xaml
    /// </summary>
    public partial class SelectCourse : Window
    {
        public SelectCourse()
        {
            InitializeComponent();
            fetchCourse();
        }

        //top bar functions
        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        //end of top bar functions


        private void searchCourses_Click(object sender, RoutedEventArgs e)
        {
            string searchCourse = searchCoursesTxtBox.Text;

            string cs = "Data Source=.\\EmsDB.db;Version=3";


            coursesList.Items.Clear();
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM courses WHERE descriptiveTitle LIKE @searchCourse or courseCode LIKE @searchCourse";

            using var cmd = new SQLiteCommand(stm, con);

            cmd.Parameters.AddWithValue("@searchCourse", "%" + searchCourse + "%");
            cmd.Prepare();

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Course course = new Course();

                course.id = rdr.GetInt32(0);
                course.courseCode = rdr.GetString(1);
                course.descriptiveTitle = rdr.GetString(2);

                coursesList.Items.Add(course);
            }
        }

        private void fetchCourse()
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";

            coursesList.Items.Clear();
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'courses'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Course course = new Course();

                course.id = rdr.GetInt32(0);
                course.courseCode = rdr.GetString(1);
                course.descriptiveTitle = rdr.GetString(2);

                coursesList.Items.Add(course);
            }
        }

        private void selectCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            Course slctCourse = ((FrameworkElement)sender).DataContext as Course;
            hiddenCourseId.Text = slctCourse.id.ToString();
            Close();
        }
    }
}
