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
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        public StudentForm()
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

        private void clearAddCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string action = actionHidden.Text;
            string id = idHidden.Text;

            if(action == "add")
            {
                addStudent(sender, e);
            }
            else if (action == "edit")
            {
                editStudent(id);
            }
            else
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void addStudent(object sender, RoutedEventArgs e)
        {
            string scholarshipGrant = scholarshipGrantTxtBox.Text;
            string idNumber = idNumTxtBox.Text;
            string ay = ayTxtBox.Text;

            string lastName = lastNameTxtBox.Text;
            string firstName = firstNameTxtBox.Text;
            string middleName = middleNameTxtBox.Text;

            ComboBoxItem sexCMB = (ComboBoxItem)sexComBox.SelectedItem;
            ComboBoxItem civilStatusCMB = (ComboBoxItem)civilStatusComBox.SelectedItem;
            string program = programTxtBox.Text;
            ComboBoxItem yrLevelCMB = (ComboBoxItem)yrComBox.SelectedItem;
            ComboBoxItem semCMB = (ComboBoxItem)semComBox.SelectedItem;

            ComboBoxItem basisOfAdmissionCMB = (ComboBoxItem)basisOfAdmissionComBox.SelectedItem;
            string dateOfBirth = dateOfBirthTxtBox.Text;
            string placeOfBirth = placeOfBirthTxtBox.Text;

            string elemCompleted = elemCompletedTxtBox.Text;
            string elemYrGrad = elemYrGradTxtBox.Text;

            string hsCompleted = hsCompletedTxtBox.Text;
            string hsYrGrad = hsYrGradTxtBox.Text;

            string parentsGuardian = parentsGuardianTxtBox.Text;
            string contactNo = contactNoTxtBox.Text;

            string address = addressTxtBox.Text;
            string email = emailTxtBox.Text;

            if (scholarshipGrant == "" || idNumber == "" || ay == "" ||
                lastName == "" || firstName == "" || middleName == "" ||
                sexComBox.SelectedIndex < 0 || civilStatusComBox.SelectedIndex < 0 ||
                program == "" || yrComBox.SelectedIndex < 0 || semComBox.SelectedIndex < 0 ||
                basisOfAdmissionComBox.SelectedIndex < 0 || dateOfBirth == "" || placeOfBirth == "" ||
                elemCompleted == "" || elemYrGrad == "" || hsCompleted == "" || hsYrGrad == "" ||
                parentsGuardian == "" || contactNo == "" || address == "" || email == ""
                )
            {
                MessageWindow message = new MessageWindow();
                message.message.Text = "All field must not be empty.";
                message.ShowDialog();
            }
            else
            {
                string sex = sexCMB.Content.ToString();
                string civilStatus = civilStatusCMB.Content.ToString();
                string yrLevel = yrLevelCMB.Content.ToString();
                string sem = semCMB.Content.ToString();
                string basisOfAdmission = basisOfAdmissionCMB.Content.ToString();

                string cs = "Data Source=.\\EmsDB.db;Version=3";

                using var con = new SQLiteConnection(cs);
                con.Open();

                using var cmd = new SQLiteCommand(con);

                cmd.CommandText = "INSERT INTO students(" +
                    "lastName, firstName, middleName, " +
                    "scholarshipGrant, idNumber, ay, " +
                    "sex, civilStatus, program, yrLevel, sem, " +
                    "basisOfAdmission, dateOfBirth, placeOfBirth, " +
                    "elemCompleted, elemYrGrad, hsCompleted, hsYrGrad, " +
                    "parentsGuardian, contactNo, address, email" +
                    ") VALUES(" +
                    "@lastName, @firstName, @middleName, " +
                    "@scholarshipGrant, @idNumber, @ay," +
                    "@sex, @civilStatus, @program, @yrLevel, @sem, " +
                    "@basisOfAdmission, @dateOfBirth, @placeOfBirth, " +
                    "@elemCompleted, @elemYrGrad, @hsCompleted, @hsYrGrad, " +
                    "@parentsGuardian, @contactNo, @address, @email" +
                    ")";

                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@middleName", middleName);

                cmd.Parameters.AddWithValue("@scholarshipGrant", scholarshipGrant);
                cmd.Parameters.AddWithValue("@idNumber", idNumber);
                cmd.Parameters.AddWithValue("@ay", ay);
                
                cmd.Parameters.AddWithValue("@sex", sex);
                cmd.Parameters.AddWithValue("@civilStatus", civilStatus);
                cmd.Parameters.AddWithValue("@program", program);
                cmd.Parameters.AddWithValue("@yrLevel", yrLevel);
                cmd.Parameters.AddWithValue("@sem", sem);
                
                cmd.Parameters.AddWithValue("@basisOfAdmission", basisOfAdmission);
                cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@placeOfBirth", placeOfBirth);

                cmd.Parameters.AddWithValue("@elemCompleted", elemCompleted);
                cmd.Parameters.AddWithValue("@elemYrGrad", elemYrGrad);
                cmd.Parameters.AddWithValue("@hsCompleted", hsCompleted);
                cmd.Parameters.AddWithValue("@hsYrGrad", hsYrGrad);
                
                cmd.Parameters.AddWithValue("@parentsGuardian", parentsGuardian);
                cmd.Parameters.AddWithValue("@contactNo", contactNo);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                Close();

                MessageWindow message = new MessageWindow();
                message.message.Text = "Student Added";
                message.ShowDialog();
            }

        }

        private void editStudent(string id)
        {
            string scholarshipGrant = scholarshipGrantTxtBox.Text;
            string idNumber = idNumTxtBox.Text;
            string ay = ayTxtBox.Text;

            string lastName = lastNameTxtBox.Text;
            string firstName = firstNameTxtBox.Text;
            string middleName = middleNameTxtBox.Text;

            ComboBoxItem sexCMB = (ComboBoxItem)sexComBox.SelectedItem;
            ComboBoxItem civilStatusCMB = (ComboBoxItem)civilStatusComBox.SelectedItem;
            string program = programTxtBox.Text;
            ComboBoxItem yrLevelCMB = (ComboBoxItem)yrComBox.SelectedItem;
            ComboBoxItem semCMB = (ComboBoxItem)semComBox.SelectedItem;

            ComboBoxItem basisOfAdmissionCMB = (ComboBoxItem)basisOfAdmissionComBox.SelectedItem;
            string dateOfBirth = dateOfBirthTxtBox.Text;
            string placeOfBirth = placeOfBirthTxtBox.Text;

            string elemCompleted = elemCompletedTxtBox.Text;
            string elemYrGrad = elemYrGradTxtBox.Text;

            string hsCompleted = hsCompletedTxtBox.Text;
            string hsYrGrad = hsYrGradTxtBox.Text;

            string parentsGuardian = parentsGuardianTxtBox.Text;
            string contactNo = contactNoTxtBox.Text;

            string address = addressTxtBox.Text;
            string email = emailTxtBox.Text;

            if (scholarshipGrant == "" || idNumber == "" || ay == "" ||
                lastName == "" || firstName == "" || middleName == "" ||
                sexComBox.SelectedIndex < 0 || civilStatusComBox.SelectedIndex < 0 ||
                program == "" || yrComBox.SelectedIndex < 0 || semComBox.SelectedIndex < 0 ||
                basisOfAdmissionComBox.SelectedIndex < 0 || dateOfBirth == "" || placeOfBirth == "" ||
                elemCompleted == "" || elemYrGrad == "" || hsCompleted == "" || hsYrGrad == "" ||
                parentsGuardian == "" || contactNo == "" || address == "" || email == ""
                )
            {
                
                MessageWindow message = new MessageWindow();
                message.message.Text = "All field must not be empty.";
                message.ShowDialog();
            }
            else
            {
                string sex = sexCMB.Content.ToString();
                string civilStatus = civilStatusCMB.Content.ToString();
                string yrLevel = yrLevelCMB.Content.ToString();
                string sem = semCMB.Content.ToString();
                string basisOfAdmission = basisOfAdmissionCMB.Content.ToString();

                string cs = "Data Source=.\\EmsDB.db;Version=3";

                using var con = new SQLiteConnection(cs);
                con.Open();

                using var cmd = new SQLiteCommand(con);

                cmd.CommandText = "UPDATE students SET " +
                    "lastName = @lastName, firstName = @firstName, middleName = @middleName, " +
                    "scholarshipGrant = @scholarshipGrant, idNumber = @idNumber, ay = @ay, " +
                    "sex = @sex, civilStatus = @civilStatus, program = @program, yrLevel = @yrLevel, " +
                    "sem = @sem, basisOfAdmission = @basisOfAdmission, " +
                    "dateOfBirth = @dateOfBirth, placeOfBirth = @placeOfBirth, " +
                    "elemCompleted = @elemCompleted, elemYrGrad = @elemYrGrad, " +
                    "hsCompleted = @hsCompleted, hsYrGrad = @hsYrGrad, " +
                    "parentsGuardian = @parentsGuardian, contactNo = @contactNo, " +
                    "address = @address, email = @email WHERE id = @id";


                cmd.Parameters.AddWithValue("@id", id);

                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@middleName", middleName);

                cmd.Parameters.AddWithValue("@scholarshipGrant", scholarshipGrant);
                cmd.Parameters.AddWithValue("@idNumber", idNumber);
                cmd.Parameters.AddWithValue("@ay", ay);

                cmd.Parameters.AddWithValue("@sex", sex);
                cmd.Parameters.AddWithValue("@civilStatus", civilStatus);
                cmd.Parameters.AddWithValue("@program", program);
                cmd.Parameters.AddWithValue("@yrLevel", yrLevel);
                cmd.Parameters.AddWithValue("@sem", sem);

                cmd.Parameters.AddWithValue("@basisOfAdmission", basisOfAdmission);
                cmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth);
                cmd.Parameters.AddWithValue("@placeOfBirth", placeOfBirth);

                cmd.Parameters.AddWithValue("@elemCompleted", elemCompleted);
                cmd.Parameters.AddWithValue("@elemYrGrad", elemYrGrad);
                cmd.Parameters.AddWithValue("@hsCompleted", hsCompleted);
                cmd.Parameters.AddWithValue("@hsYrGrad", hsYrGrad);

                cmd.Parameters.AddWithValue("@parentsGuardian", parentsGuardian);
                cmd.Parameters.AddWithValue("@contactNo", contactNo);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@email", email);

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                Close();

                MessageWindow message = new MessageWindow();
                message.message.Text = "Saved";
                message.ShowDialog();
            }
        }


    }
}
