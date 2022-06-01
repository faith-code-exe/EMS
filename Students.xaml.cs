using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.ComponentModel;
using System.Runtime.CompilerServices;

using System.Data.SQLite;
using EMS.Models;

namespace EMS
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Page
    {
        public Students()
        {
            InitializeComponent();
            fetchStudent();
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

            while(rdr.Read())
            {
                Student student = new Student();

                student.id = rdr.GetInt32(0);

                student.lastName = rdr.GetString(1);
                student.firstName = rdr.GetString(2);
                student.middleName = rdr.GetString(3);

                student.scholarshipGrant = rdr.GetString(4);
                student.idNumber = rdr.GetString(5);
                student.ay = rdr.GetString(6);

                student.sex = rdr.GetString(7);
                student.civilStatus = rdr.GetString(8);
                student.program = rdr.GetString(9);
                student.yrLevel = rdr.GetString(10);
                student.sem = rdr.GetString(11);
                student.basisOfAdmission = rdr.GetString(12);

                student.dateOfBirth = rdr.GetString(13);
                student.placeOfBirth = rdr.GetString(14);

                student.elemCompleted = rdr.GetString(15);
                student.elemYrGrad = rdr.GetString(16);

                student.hsCompleted = rdr.GetString(17);
                student.hsYrGrad = rdr.GetString(18);

                student.parentsGuardian = rdr.GetString(19);
                student.contactNo = rdr.GetString(20);

                student.address = rdr.GetString(21);
                student.email = rdr.GetString(22);

                studentsList.Items.Add(student);
            }
        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.actionHidden.Text = "add";
            studentForm.submitBtn.Content = "Add Student";
            studentForm.studentFormHeadText.Text = "Add Student";
            studentForm.ShowDialog();
            fetchStudent();
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

                student.scholarshipGrant = rdr.GetString(4);
                student.idNumber = rdr.GetString(5);
                student.ay = rdr.GetString(6);

                student.sex = rdr.GetString(7);
                student.civilStatus = rdr.GetString(8);
                student.program = rdr.GetString(9);
                student.yrLevel = rdr.GetString(10);
                student.sem = rdr.GetString(11);
                student.basisOfAdmission = rdr.GetString(12);

                student.dateOfBirth = rdr.GetString(13);
                student.placeOfBirth = rdr.GetString(14);

                student.elemCompleted = rdr.GetString(15);
                student.elemYrGrad = rdr.GetString(16);

                student.hsCompleted = rdr.GetString(17);
                student.hsYrGrad = rdr.GetString(18);

                student.parentsGuardian = rdr.GetString(19);
                student.contactNo = rdr.GetString(20);

                student.address = rdr.GetString(21);
                student.email = rdr.GetString(22);

                studentsList.Items.Add(student);
            }
        }

        private void editStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            Student edtstudent = ((FrameworkElement)sender).DataContext as Student;

            int id = edtstudent.id;

            string lastName = edtstudent.lastName;
            string firstName = edtstudent.firstName;
            string middleName = edtstudent.middleName;

            string scholarshipGrant = edtstudent.scholarshipGrant;
            string idNumber = edtstudent.idNumber;
            string ay = edtstudent.ay;

            string sex = edtstudent.sex;
            string civilStatus = edtstudent.civilStatus;
            string program = edtstudent.program;
            string yrLevel = edtstudent.yrLevel;
            string sem = edtstudent.sem;

            string basisOfAdmission = edtstudent.basisOfAdmission;
            string dateOfBirth = edtstudent.dateOfBirth;
            string placeOfBirth = edtstudent.placeOfBirth;

            string elemCompleted = edtstudent.elemCompleted;
            string elemYrGrad = edtstudent.elemYrGrad;
            string hsCompleted = edtstudent.hsCompleted;
            string hsYrGrad = edtstudent.hsYrGrad;

            string parentsGuardian = edtstudent.parentsGuardian;
            string contactNo = edtstudent.contactNo;
            string address = edtstudent.address;
            string email = edtstudent.email;


            StudentForm studentForm = new StudentForm();

            studentForm.studentFormHeadText.Text = "Edit Student";

            studentForm.lastNameTxtBox.Text = lastName;
            studentForm.firstNameTxtBox.Text = firstName;
            studentForm.middleNameTxtBox.Text = middleName;

            studentForm.scholarshipGrantTxtBox.Text = scholarshipGrant;
            studentForm.idNumTxtBox.Text = idNumber;
            studentForm.ayTxtBox.Text = ay;

            //studentForm.sexComBox;
            foreach (var item in studentForm.sexComBox.Items)
            {
                if (item is ComboBoxItem cbItem && cbItem.Content.Equals(sex))
                {
                    studentForm.sexComBox.SelectedItem = cbItem;
                }
            }
            //studentForm.civilStatusComBox
            foreach (var item in studentForm.civilStatusComBox.Items)
            {
                if (item is ComboBoxItem cbItem && cbItem.Content.Equals(civilStatus))
                {
                    studentForm.civilStatusComBox.SelectedItem = cbItem;
                }
            }
            studentForm.programTxtBox.Text = program;
            //studentForm.yrComBox
            foreach (var item in studentForm.yrComBox.Items)
            {
                if (item is ComboBoxItem cbItem && cbItem.Content.Equals(yrLevel))
                {
                    studentForm.yrComBox.SelectedItem = cbItem;
                }
            }
            //studentForm.semComBox
            foreach (var item in studentForm.semComBox.Items)
            {
                if (item is ComboBoxItem cbItem && cbItem.Content.Equals(sem))
                {
                    studentForm.semComBox.SelectedItem = cbItem;
                }
            }

            //studentForm.basisOfAdmissionComBox
            foreach (var item in studentForm.basisOfAdmissionComBox.Items)
            {
                if (item is ComboBoxItem cbItem && cbItem.Content.Equals(basisOfAdmission))
                {
                    studentForm.basisOfAdmissionComBox.SelectedItem = cbItem;
                }
            }
            studentForm.dateOfBirthTxtBox.Text = dateOfBirth;
            studentForm.placeOfBirthTxtBox.Text = placeOfBirth;

            studentForm.elemCompletedTxtBox.Text = elemCompleted;
            studentForm.elemYrGradTxtBox.Text = elemYrGrad;
            studentForm.hsCompletedTxtBox.Text = hsCompleted;
            studentForm.hsYrGradTxtBox.Text = hsYrGrad;

            studentForm.parentsGuardianTxtBox.Text = parentsGuardian;
            studentForm.contactNoTxtBox.Text = contactNo;
            studentForm.addressTxtBox.Text = address;
            studentForm.emailTxtBox.Text = email;

            //hidden text boxes
            studentForm.actionHidden.Text = "edit";
            studentForm.idHidden.Text = id.ToString();

            studentForm.submitBtn.Content = "Save";
            
            studentForm.ShowDialog();
            fetchStudent();
        }

        private void deleteStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student dltStudent = ((FrameworkElement)sender).DataContext as Student;
                int id = dltStudent.id;
                string lastName = dltStudent.lastName;
                string firstName = dltStudent.firstName;
                string middleName = dltStudent.middleName;


                DeleteWindow deleteWindow = new DeleteWindow();

                deleteWindow.tableParameter.Text = "students";
                deleteWindow.idParameter.Text = id.ToString();
                deleteWindow.deleteMessage.Text = "Are you sure you want " +
                    "to delete the Student " + firstName + " " +
                    middleName + " " + lastName + "?";
                deleteWindow.ShowDialog();
                fetchStudent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
