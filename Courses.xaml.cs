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
using System.Data;

using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EMS
{
    /// <summary>
    /// Interaction logic for Courses.xaml
    /// </summary>
    public partial class Courses : Page
    {

        string cs = "Data Source=.\\EmsDB.db;Version=3";


        public Courses()
        {
            InitializeComponent();
            fetchCourses();
        }

        private void searchCourses_Click(object sender, RoutedEventArgs e)
        {
            string searchCourse = searchCourseTxtBox.Text;

            coursesList.Items.Clear();
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM courses WHERE descriptiveTitle LIKE @searchCourse or courseCode LIKE @searchCourse";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@searchCourse", "%" + searchCourse+ "%");

            cmd.Prepare();

            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Course course = new Course();

                course.id = rdr.GetInt32(0);
                course.courseCode = rdr.GetString(1);
                course.descriptiveTitle = rdr.GetString(2);
                course.lec = rdr.GetInt32(3);
                course.lab = rdr.GetInt32(4);
                course.units = rdr.GetInt32(5);
                course.instructor = rdr.GetString(6);

                coursesList.Items.Add(course);
            }


        }

        private void AddCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCourse addCourseWindow = new AddCourse();
            addCourseWindow.ShowDialog();
            fetchCourses();
        }

        public void fetchCourses()
        {
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
                course.lec = rdr.GetInt32(3);
                course.lab = rdr.GetInt32(4);
                course.units = rdr.GetInt32(5);
                course.instructor = rdr.GetString(6);

                coursesList.Items.Add(course);
            }
        }

        private void editCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Course edtCourse = ((FrameworkElement)sender).DataContext as Course;

                int id = edtCourse.id;
                string courseCode = edtCourse.courseCode;
                string descriptiveTitle = edtCourse.descriptiveTitle;
                int lec = edtCourse.lec;
                int lab = edtCourse.lab;
                int units = edtCourse.units;
                string instructor = edtCourse.instructor;

                EditCourse edtCourseWindow = new EditCourse();
                edtCourseWindow.courseCoudeTxtBox.Text = courseCode;
                edtCourseWindow.descriptiveTitleTxtBox.Text = descriptiveTitle;
                edtCourseWindow.lecTxtBox.Text = lec.ToString();
                edtCourseWindow.labTxtBox.Text = lab.ToString();
                edtCourseWindow.unitsTxtBox.Text = units.ToString();
                edtCourseWindow.instructorTxtBox.Text = instructor;
                edtCourseWindow.idParameter.Text = id.ToString();
                edtCourseWindow.ShowDialog();
                fetchCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void deleteCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Course dltCourse = ((FrameworkElement)sender).DataContext as Course;
                int id = dltCourse.id;
                string courseCode = dltCourse.courseCode;
                string descriptiveTitle = dltCourse.descriptiveTitle;

                DeleteWindow deleteCourseWindow = new DeleteWindow();

                deleteCourseWindow.tableParameter.Text = "courses";
                deleteCourseWindow.idParameter.Text = id.ToString();
                deleteCourseWindow.deleteMessage.Text = "Are you sure you want " +
                    "to delete the course (" + courseCode +") " + 
                    descriptiveTitle + "?";
                deleteCourseWindow.ShowDialog();
                fetchCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
