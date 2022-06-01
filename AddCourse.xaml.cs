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
using System.Windows.Automation.Peers;

namespace EMS
{
    /// <summary>
    /// Interaction logic for AddCourse.xaml
    /// </summary>
    /// 

    public partial class AddCourse : Window
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        //top bar functions
        public void Close(object sender, RoutedEventArgs e)
        {
            clearTextBox();
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

        


        private void clearTextBox()
        {
            courseCoudeTxtBox.Clear();
            descriptiveTitleTxtBox.Clear();
            lecTxtBox.Clear();
            labTxtBox.Clear();
            unitsTxtBox.Clear();
            instructorTxtBox.Clear();
        }

        private void addCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            string courseCode = courseCoudeTxtBox.Text;
            string descriptiveTitle = descriptiveTitleTxtBox.Text;
            string lec = lecTxtBox.Text;
            string lab = labTxtBox.Text;
            string units = unitsTxtBox.Text;
            string instructor = instructorTxtBox.Text;

            bool lecIsNumber = int.TryParse(lec, out int n);
            bool labIsNumber = int.TryParse(lab, out int m);
            bool unitsIsNumber = int.TryParse(units, out int o);

            if (courseCode == "" || descriptiveTitle == "" 
                || lec == "" || lab == "" || units == ""
                || instructor == "")
            {
                //MessageBox.Show("Please fill in all the fields.");
                MessageWindow message = new MessageWindow();
                message.message.Text = "Please fill in all the fields.";
                message.ShowDialog();
            } 
            else if (!lecIsNumber || !labIsNumber || !unitsIsNumber)
            {
                //MessageBox.Show("Lec, Lab and Units must be a number.");
                MessageWindow message = new MessageWindow();
                message.message.Text = "Lec, Lab and Units must be a number.";
                message.ShowDialog();
            }
            else
            {
                string cs = "Data Source=.\\EmsDB.db;Version=3";

                using var con = new SQLiteConnection(cs);
                con.Open();

                using var cmd = new SQLiteCommand(con);
                cmd.CommandText = "INSERT INTO courses(courseCode, " +
                    "descriptiveTitle, lec, lab, units," +
                    "instructor) VALUES(@courseCode, " +
                    "@descriptiveTitle, @lec, @lab, @units," +
                    "@instructor)";

                cmd.Parameters.AddWithValue("@courseCode", courseCode);
                cmd.Parameters.AddWithValue("@descriptiveTitle", descriptiveTitle);
                cmd.Parameters.AddWithValue("@lec", lec);
                cmd.Parameters.AddWithValue("@lab", lab);
                cmd.Parameters.AddWithValue("@units", units);
                cmd.Parameters.AddWithValue("@instructor", instructor);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                clearTextBox();

                Close();

                //MessageBox.Show("Course Added");
                MessageWindow message = new MessageWindow();
                message.message.Text = "Course Added";
                message.ShowDialog();

            }
        }

        private void clearAddCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            clearTextBox();
        }
    }
}
