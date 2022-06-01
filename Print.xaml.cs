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
    /// Interaction logic for Print.xaml
    /// </summary>
    public partial class Print : Page
    {
        public Print()
        {
            InitializeComponent();
        }

        private void slectStudent_Click(object sender, RoutedEventArgs e)
        {
            SelectStudent selectStudent = new SelectStudent();
            selectStudent.ShowDialog();
            string id = selectStudent.hiddenStudentId.Text;

            if (id != "")
            {
                setStudent(id);
            }
        }

        private void printPreviewBtn_Click(object sender, RoutedEventArgs e)
        {
            string lastname = lastName.Text;
            string firstname = firstName.Text;
            string middlename = middleName.Text;

            string scholarship = scholarshipGrant.Text;
            string idnumber = idNumber.Text;
            string aY = ay.Text;

            string gender = sex.Text;
            string civilstatus = civilStatus.Text;
            string progRam = program.Text;
            string yrlevel = yrLevel.Text;
            string semester = sem.Text;

            string basisofadmission = basisOfAdmission.Text;
            string birthDate = dateOfBirth.Text;
            string birthPlace = placeOfBirth.Text;

            string elemcompleted = elemCompleted.Text;
            string elemyrgrad = elemYrGrad.Text;

            string hscompleted = hsCompleted.Text;
            string hsyrgrad = hsYrGrad.Text;

            string guardian = parentsGuardian.Text;
            string contactnumber = contactNo.Text;

            string location = address.Text;
            string emailAdd = email.Text;

            string code1 = courseCode1.Text;
            string title1 = descriptiveTitle1.Text;
            string lecture1 = lec1.Text;
            string laboratory1 = lab1.Text;
            string teacher1 = instructor1.Text;

            string code2 = courseCode2.Text;
            string title2 = descriptiveTitle2.Text;
            string lecture2 = lec2.Text;
            string laboratory2 = lab2.Text;
            string teacher2 = instructor2.Text;

            string code3 = courseCode3.Text;
            string title3 = descriptiveTitle3.Text;
            string lecture3 = lec3.Text;
            string laboratory3 = lab3.Text;
            string teacher3 = instructor3.Text;

            string code4 = courseCode4.Text;
            string title4 = descriptiveTitle4.Text;
            string lecture4 = lec4.Text;
            string laboratory4 = lab4.Text;
            string teacher4 = instructor4.Text;

            string code5 = courseCode5.Text;
            string title5 = descriptiveTitle5.Text;
            string lecture5 = lec5.Text;
            string laboratory5 = lab5.Text;
            string teacher5 = instructor5.Text;

            string code6 = courseCode6.Text;
            string title6 = descriptiveTitle6.Text;
            string lecture6 = lec6.Text;
            string laboratory6 = lab6.Text;
            string teacher6 = instructor6.Text;

            string code7 = courseCode7.Text;
            string title7 = descriptiveTitle7.Text;
            string lecture7 = lec7.Text;
            string laboratory7 = lab7.Text;
            string teacher7 = instructor7.Text;

            string code8 = courseCode8.Text;
            string title8 = descriptiveTitle8.Text;
            string lecture8 = lec8.Text;
            string laboratory8 = lab8.Text;
            string teacher8 = instructor8.Text;

            string code9 = courseCode9.Text;
            string title9 = descriptiveTitle9.Text;
            string lecture9 = lec9.Text;
            string laboratory9 = lab9.Text;
            string teacher9 = instructor9.Text;

            string lectotal = lecTotal.Text;
            string labtotal = labTotal.Text;

            //setting textblocks below

            PrintPreview printPreview = new PrintPreview();

            if (basisofadmission == "New")
            {
                printPreview.OldAdminD.Visibility = Visibility.Hidden;
                printPreview.OldAdminS.Visibility = Visibility.Hidden;
                printPreview.NewAdminS.Visibility = Visibility.Visible;
                printPreview.NewAdminD.Visibility = Visibility.Visible;
            }
            else if (basisofadmission == "Old")
            {
                printPreview.NewAdminS.Visibility = Visibility.Hidden;
                printPreview.NewAdminD.Visibility = Visibility.Hidden;
                printPreview.OldAdminD.Visibility = Visibility.Visible;
                printPreview.OldAdminS.Visibility = Visibility.Visible;
            }
            else
            {
                printPreview.NewAdminS.Visibility = Visibility.Hidden;
                printPreview.NewAdminD.Visibility = Visibility.Hidden;
                printPreview.OldAdminD.Visibility = Visibility.Hidden;
                printPreview.OldAdminS.Visibility = Visibility.Hidden;
            }

            //setting student
            printPreview.headS.Text = basisofadmission + " STUDENTS (" +
                yrlevel + " to 4th Year)";
            printPreview.headProgramS.Text = progRam;

            printPreview.lastNameS.Text = lastname;
            printPreview.firstNameS.Text = firstname;
            printPreview.middleNameS.Text = middlename;

            printPreview.scholarshipGrantS.Text = scholarship;
            printPreview.idNumberS.Text = idnumber;
            printPreview.ayS.Text = aY;

            printPreview.sexS.Text = gender;
            printPreview.civilStatusS.Text = civilstatus;
            printPreview.programS.Text = progRam;
            printPreview.yrLevelS.Text = yrlevel;
            printPreview.semS.Text = semester;

            printPreview.basisOfAdmissionS.Text = basisofadmission;
            printPreview.dateOfBirthS.Text = birthDate;
            printPreview.placeOfBirthS.Text = birthPlace;

            printPreview.elemCompletedS.Text = elemcompleted;
            printPreview.elemYrGradS.Text = elemyrgrad;
            printPreview.hsCompletedS.Text = hscompleted;
            printPreview.hsYrGradS.Text = hsyrgrad;

            printPreview.parentsGuardianS.Text = guardian;
            printPreview.contactNoS.Text = contactnumber;
            printPreview.addressS.Text = location;
            printPreview.emailS.Text = emailAdd;

            printPreview.courseCode1S.Text = code1;
            printPreview.courseCode2S.Text = code2;
            printPreview.courseCode3S.Text = code3;
            printPreview.courseCode4S.Text = code4;
            printPreview.courseCode5S.Text = code5;
            printPreview.courseCode6S.Text = code6;
            printPreview.courseCode7S.Text = code7;
            printPreview.courseCode8S.Text = code8;
            printPreview.courseCode9S.Text = code9;

            printPreview.descriptiveTitle1S.Text = title1;
            printPreview.descriptiveTitle2S.Text = title2;
            printPreview.descriptiveTitle3S.Text = title3;
            printPreview.descriptiveTitle4S.Text = title4;
            printPreview.descriptiveTitle5S.Text = title5;
            printPreview.descriptiveTitle6S.Text = title6;
            printPreview.descriptiveTitle7S.Text = title7;
            printPreview.descriptiveTitle8S.Text = title8;
            printPreview.descriptiveTitle9S.Text = title9;

            printPreview.lec1S.Text = lecture1;
            printPreview.lec2S.Text = lecture2;
            printPreview.lec3S.Text = lecture3;
            printPreview.lec4S.Text = lecture4;
            printPreview.lec5S.Text = lecture5;
            printPreview.lec6S.Text = lecture6;
            printPreview.lec7S.Text = lecture7;
            printPreview.lec8S.Text = lecture8;
            printPreview.lec9S.Text = lecture9;

            printPreview.lab1S.Text = laboratory1;
            printPreview.lab2S.Text = laboratory2;
            printPreview.lab3S.Text = laboratory3;
            printPreview.lab4S.Text = laboratory4;
            printPreview.lab5S.Text = laboratory5;
            printPreview.lab6S.Text = laboratory6;
            printPreview.lab7S.Text = laboratory7;
            printPreview.lab8S.Text = laboratory8;
            printPreview.lab9S.Text = laboratory9;

            printPreview.instructor1S.Text = teacher1;
            printPreview.instructor2S.Text = teacher2;
            printPreview.instructor3S.Text = teacher3;
            printPreview.instructor4S.Text = teacher4;
            printPreview.instructor5S.Text = teacher5;
            printPreview.instructor6S.Text = teacher6;
            printPreview.instructor7S.Text = teacher7;
            printPreview.instructor8S.Text = teacher8;
            printPreview.instructor9S.Text = teacher9;

            printPreview.lecTotalS.Text = lectotal;
            printPreview.labTotalS.Text = labtotal;


            //setting Dean

            printPreview.headD.Text = basisofadmission + " STUDENTS (" +
                yrlevel + " to 4th Year)";
            printPreview.headProgramD.Text = progRam;

            printPreview.lastNameD.Text = lastname;
            printPreview.firstNameD.Text = firstname;
            printPreview.middleNameD.Text = middlename;

            printPreview.scholarshipGrantD.Text = scholarship;
            printPreview.idNumberD.Text = idnumber;
            printPreview.ayD.Text = aY;

            printPreview.sexD.Text = gender;
            printPreview.civilStatusD.Text = civilstatus;
            printPreview.programD.Text = progRam;
            printPreview.yrLevelD.Text = yrlevel;
            printPreview.semD.Text = semester;

            printPreview.basisOfAdmissionD.Text = basisofadmission;
            printPreview.dateOfBirthD.Text = birthDate;
            printPreview.placeOfBirthD.Text = birthPlace;

            printPreview.elemCompletedS.Text = elemcompleted;
            printPreview.elemYrGradD.Text = elemyrgrad;
            printPreview.hsCompletedD.Text = hscompleted;
            printPreview.hsYrGradD.Text = hsyrgrad;

            printPreview.parentsGuardianD.Text = guardian;
            printPreview.contactNoD.Text = contactnumber;
            printPreview.addressD.Text = location;
            printPreview.emailD.Text = emailAdd;

            printPreview.courseCode1D.Text = code1;
            printPreview.courseCode2D.Text = code2;
            printPreview.courseCode3D.Text = code3;
            printPreview.courseCode4D.Text = code4;
            printPreview.courseCode5D.Text = code5;
            printPreview.courseCode6D.Text = code6;
            printPreview.courseCode7D.Text = code7;
            printPreview.courseCode8D.Text = code8;
            printPreview.courseCode9D.Text = code9;

            printPreview.descriptiveTitle1D.Text = title1;
            printPreview.descriptiveTitle2D.Text = title2;
            printPreview.descriptiveTitle3D.Text = title3;
            printPreview.descriptiveTitle4D.Text = title4;
            printPreview.descriptiveTitle5D.Text = title5;
            printPreview.descriptiveTitle6D.Text = title6;
            printPreview.descriptiveTitle7D.Text = title7;
            printPreview.descriptiveTitle8D.Text = title8;
            printPreview.descriptiveTitle9D.Text = title9;

            printPreview.lec1D.Text = lecture1;
            printPreview.lec2D.Text = lecture2;
            printPreview.lec3D.Text = lecture3;
            printPreview.lec4D.Text = lecture4;
            printPreview.lec5D.Text = lecture5;
            printPreview.lec6D.Text = lecture6;
            printPreview.lec7D.Text = lecture7;
            printPreview.lec8D.Text = lecture8;
            printPreview.lec9D.Text = lecture9;

            printPreview.lab1D.Text = laboratory1;
            printPreview.lab2D.Text = laboratory2;
            printPreview.lab3D.Text = laboratory3;
            printPreview.lab4D.Text = laboratory4;
            printPreview.lab5D.Text = laboratory5;
            printPreview.lab6D.Text = laboratory6;
            printPreview.lab7D.Text = laboratory7;
            printPreview.lab8D.Text = laboratory8;
            printPreview.lab9D.Text = laboratory9;

            printPreview.instructor1D.Text = teacher1;
            printPreview.instructor2D.Text = teacher2;
            printPreview.instructor3D.Text = teacher3;
            printPreview.instructor4D.Text = teacher4;
            printPreview.instructor5D.Text = teacher5;
            printPreview.instructor6D.Text = teacher6;
            printPreview.instructor7D.Text = teacher7;
            printPreview.instructor8D.Text = teacher8;
            printPreview.instructor9D.Text = teacher9;

            printPreview.lecTotalD.Text = lectotal;
            printPreview.labTotalD.Text = labtotal;

            // SHOW PINT PREVIEW
            printPreview.ShowDialog();
        }

        private void setStudent(string id)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'students' WHERE id = " + id;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                lastName.Text = rdr.GetString(1);
                firstName.Text = rdr.GetString(2);
                middleName.Text = rdr.GetString(3);

                scholarshipGrant.Text = rdr.GetString(4);
                idNumber.Text = rdr.GetString(5);
                ay.Text = rdr.GetString(6);

                sex.Text = rdr.GetString(7);
                civilStatus.Text = rdr.GetString(8);
                program.Text = rdr.GetString(9);
                yrLevel.Text = rdr.GetString(10);
                sem.Text = rdr.GetString(11);
                basisOfAdmission.Text = rdr.GetString(12);

                dateOfBirth.Text = rdr.GetString(13);
                placeOfBirth.Text = rdr.GetString(14);

                elemCompleted.Text = rdr.GetString(15);
                elemYrGrad.Text = rdr.GetString(16);

                hsCompleted.Text = rdr.GetString(17);
                hsYrGrad.Text = rdr.GetString(18);

                parentsGuardian.Text = rdr.GetString(19);
                contactNo.Text = rdr.GetString(20);

                address.Text = rdr.GetString(21);
                email.Text = rdr.GetString(22);
            }
        }

        private void selectCourse1_Click(object sender, RoutedEventArgs e)
        {
            SelectCourse courses = new SelectCourse();
            courses.ShowDialog();

            if (courses.hiddenCourseId.Text != "")
            {
                setCoureRow1(courses.hiddenCourseId.Text);
                lecTotal.Text = sumLec().ToString();
                labTotal.Text = sumLab().ToString();
            }

        }

        private void selectCourse2_Click(object sender, RoutedEventArgs e)
        {
            SelectCourse courses = new SelectCourse();
            courses.ShowDialog();

            if (courses.hiddenCourseId.Text != "")
            {
                setCoureRow2(courses.hiddenCourseId.Text);
                lecTotal.Text = sumLec().ToString();
                labTotal.Text = sumLab().ToString();
            }
        }

        private void selectCourse3_Click(object sender, RoutedEventArgs e)
        {
            SelectCourse courses = new SelectCourse();;
            courses.ShowDialog(); 

            if (courses.hiddenCourseId.Text != "")
            {
                setCoureRow3(courses.hiddenCourseId.Text);
                lecTotal.Text = sumLec().ToString();
                labTotal.Text = sumLab().ToString();
            }
        }

        private void selectCourse4_Click(object sender, RoutedEventArgs e)
        {
            SelectCourse courses = new SelectCourse();
            courses.ShowDialog();

            if (courses.hiddenCourseId.Text != "")
            {
                setCoureRow4(courses.hiddenCourseId.Text);
                lecTotal.Text = sumLec().ToString();
                labTotal.Text = sumLab().ToString();
            }
        }

        private void selectCourse5_Click(object sender, RoutedEventArgs e)
        {
            SelectCourse courses = new SelectCourse();
            courses.ShowDialog();

            if (courses.hiddenCourseId.Text != "")
            {
                setCoureRow5(courses.hiddenCourseId.Text);

                lecTotal.Text = sumLec().ToString();
                labTotal.Text = sumLab().ToString();
            }

        }

        private void selectCourse6_Click(object sender, RoutedEventArgs e)
        {
            SelectCourse courses = new SelectCourse();
            courses.ShowDialog();

            if (courses.hiddenCourseId.Text != "")
            {
                setCoureRow6(courses.hiddenCourseId.Text);

                lecTotal.Text = sumLec().ToString();
                labTotal.Text = sumLab().ToString();
            }
        }

        private void selectCourse7_Click(object sender, RoutedEventArgs e)
        {
            SelectCourse courses = new SelectCourse();
            courses.ShowDialog();

            if (courses.hiddenCourseId.Text != "")
            {
                setCoureRow7(courses.hiddenCourseId.Text);

                lecTotal.Text = sumLec().ToString();
                labTotal.Text = sumLab().ToString();
            };
        }

        private void selectCourse8_Click(object sender, RoutedEventArgs e)
        {
            SelectCourse courses = new SelectCourse();
            courses.ShowDialog();

            if (courses.hiddenCourseId.Text != "")
            {
                setCoureRow8(courses.hiddenCourseId.Text);

                lecTotal.Text = sumLec().ToString();
                labTotal.Text = sumLab().ToString();
            }
        }

        private void selectCourse9_Click(object sender, RoutedEventArgs e)
        {
            SelectCourse courses = new SelectCourse();
            courses.ShowDialog();

            if (courses.hiddenCourseId.Text != "")
            {
                setCoureRow9(courses.hiddenCourseId.Text);

                lecTotal.Text = sumLec().ToString();
                labTotal.Text = sumLab().ToString();
            }
        }

        private void setCoureRow1(string id)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'courses' WHERE id = " + id;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                courseCode1.Text = rdr.GetString(1);
                descriptiveTitle1.Text = rdr.GetString(2);
                lec1.Text = rdr.GetInt32(3).ToString();
                lab1.Text = rdr.GetInt32(4).ToString();
                instructor1.Text = rdr.GetString(6);
            }
        }
        private void setCoureRow2(string id)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'courses' WHERE id = " + id;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                courseCode2.Text = rdr.GetString(1);
                descriptiveTitle2.Text = rdr.GetString(2);
                lec2.Text = rdr.GetInt32(3).ToString();
                lab2.Text = rdr.GetInt32(4).ToString();
                instructor2.Text = rdr.GetString(6);
            }
        }
        private void setCoureRow3(string id)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'courses' WHERE id = " + id;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                courseCode3.Text = rdr.GetString(1);
                descriptiveTitle3.Text = rdr.GetString(2);
                lec3.Text = rdr.GetInt32(3).ToString();
                lab3.Text = rdr.GetInt32(4).ToString();
                instructor3.Text = rdr.GetString(6);
            }
        }
        private void setCoureRow4(string id)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'courses' WHERE id = " + id;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                courseCode4.Text = rdr.GetString(1);
                descriptiveTitle4.Text = rdr.GetString(2);
                lec4.Text = rdr.GetInt32(3).ToString();
                lab4.Text = rdr.GetInt32(4).ToString();
                instructor4.Text = rdr.GetString(6);
            }
        }
        private void setCoureRow5(string id)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'courses' WHERE id = " + id;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                courseCode5.Text = rdr.GetString(1);
                descriptiveTitle5.Text = rdr.GetString(2);
                lec5.Text = rdr.GetInt32(3).ToString();
                lab5.Text = rdr.GetInt32(4).ToString();
                instructor5.Text = rdr.GetString(6);
            }
        }
        private void setCoureRow6(string id)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'courses' WHERE id = " + id;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                courseCode6.Text = rdr.GetString(1);
                descriptiveTitle6.Text = rdr.GetString(2);
                lec6.Text = rdr.GetInt32(3).ToString();
                lab6.Text = rdr.GetInt32(4).ToString();
                instructor6.Text = rdr.GetString(6);
            }
        }
        private void setCoureRow7(string id)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'courses' WHERE id = " + id;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                courseCode7.Text = rdr.GetString(1);
                descriptiveTitle7.Text = rdr.GetString(2);
                lec7.Text = rdr.GetInt32(3).ToString();
                lab7.Text = rdr.GetInt32(4).ToString();
                instructor7.Text = rdr.GetString(6);
            }
        }
        private void setCoureRow8(string id)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'courses' WHERE id = " + id;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                courseCode8.Text = rdr.GetString(1);
                descriptiveTitle8.Text = rdr.GetString(2);
                lec8.Text = rdr.GetInt32(3).ToString();
                lab8.Text = rdr.GetInt32(4).ToString();
                instructor8.Text = rdr.GetString(6);
            }
        }
        private void setCoureRow9(string id)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'courses' WHERE id = " + id;

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                courseCode9.Text = rdr.GetString(1);
                descriptiveTitle9.Text = rdr.GetString(2);
                lec9.Text = rdr.GetInt32(3).ToString();
                lab9.Text = rdr.GetInt32(4).ToString();
                instructor9.Text = rdr.GetString(6);
            }
        }



        private int sumLec()
        {
            int addLec1, addLec2, addLec3, addLec4, addLec5;
            int addLec6, addLec7, addLec8, addLec9;

            if (lec1.Text == "")
            {
                addLec1 = 0;
            } 
            else 
            {
                addLec1 = Convert.ToInt32(lec1.Text);
            }

            if (lec2.Text == "")
            {
                addLec2 = 0;
            }
            else
            {
                addLec2 = Convert.ToInt32(lec2.Text);
            }

            if (lec3.Text == "")
            {
                addLec3 = 0;
            }
            else
            {
                addLec3 = Convert.ToInt32(lec3.Text);
            }

            if (lec4.Text == "")
            {
                addLec4 = 0;
            }
            else
            {
                addLec4 = Convert.ToInt32(lec4.Text);
            }

            if (lec5.Text == "")
            {
                addLec5 = 0;
            }
            else
            {
                addLec5 = Convert.ToInt32(lec5.Text);
            }

            if (lec6.Text == "")
            {
                addLec6 = 0;
            }
            else
            {
                addLec6 = Convert.ToInt32(lec6.Text);
            }

            if (lec7.Text == "")
            {
                addLec7 = 0;
            }
            else
            {
                addLec7 = Convert.ToInt32(lec7.Text);
            }

            if (lec8.Text == "")
            {
                addLec8 = 0;
            }
            else
            {
                addLec8 = Convert.ToInt32(lec8.Text);
            }

            if (lec9.Text == "")
            {
                addLec9 = 0;
            }
            else
            {
                addLec9 = Convert.ToInt32(lec9.Text);
            }

            return addLec1 + addLec2 + addLec3 +
                addLec4 + addLec5 + addLec6 + addLec7 +
                addLec8 + addLec9;
        }

        private int sumLab()
        {
            int addLab1, addLab2, addLab3, addLab4, addLab5;
            int addLab6, addLab7, addLab8, addLab9;

            if (lab1.Text == "")
            {
                addLab1 = 0;
            }
            else
            {
                addLab1 = Convert.ToInt32(lab1.Text);
            }

            if (lab2.Text == "")
            {
                addLab2 = 0;
            }
            else
            {
                addLab2 = Convert.ToInt32(lab2.Text);
            }

            if (lab3.Text == "")
            {
                addLab3 = 0;
            }
            else
            {
                addLab3 = Convert.ToInt32(lab3.Text);
            }

            if (lab4.Text == "")
            {
                addLab4 = 0;
            }
            else
            {
                addLab4 = Convert.ToInt32(lab4.Text);
            }

            if (lab5.Text == "")
            {
                addLab5 = 0;
            }
            else
            {
                addLab5 = Convert.ToInt32(lab5.Text);
            }

            if (lab6.Text == "")
            {
                addLab6 = 0;
            }
            else
            {
                addLab6 = Convert.ToInt32(lab6.Text);
            }

            if (lab7.Text == "")
            {
                addLab7 = 0;
            }
            else
            {
                addLab7 = Convert.ToInt32(lab7.Text);
            }

            if (lab8.Text == "")
            {
                addLab8 = 0;
            }
            else
            {
                addLab8 = Convert.ToInt32(lab8.Text);
            }

            if (lab9.Text == "")
            {
                addLab9 = 0;
            }
            else
            {
                addLab9 = Convert.ToInt32(lab9.Text);
            }

            return addLab1 + addLab2 + addLab3 +
                addLab4 + addLab5 + addLab6 + addLab7 +
                addLab8 + addLab9;
        }


        private void removeCourse1_Click(object sender, RoutedEventArgs e)
        {

            courseCode1.Text = "";
            descriptiveTitle1.Text = "";
            lec1.Text = "";
            lab1.Text = "";
            instructor1.Text = "";
            
            lecTotal.Text = sumLec().ToString();
            labTotal.Text = sumLab().ToString();
        }

        private void removeCourse2_Click(object sender, RoutedEventArgs e)
        {
            courseCode2.Text = "";
            descriptiveTitle2.Text = "";
            lec2.Text = "";
            lab2.Text = "";
            instructor2.Text = "";

            lecTotal.Text = sumLec().ToString();
            labTotal.Text = sumLab().ToString();
        }

        private void removeCourse3_Click(object sender, RoutedEventArgs e)
        {
            courseCode3.Text = "";
            descriptiveTitle3.Text = "";
            lec3.Text = "";
            lab3.Text = "";
            instructor3.Text = "";

            lecTotal.Text = sumLec().ToString();
            labTotal.Text = sumLab().ToString();
        }

        private void removeCourse4_Click(object sender, RoutedEventArgs e)
        {

            courseCode4.Text = "";
            descriptiveTitle4.Text = "";
            lec4.Text = "";
            lab4.Text = "";
            instructor4.Text = "";

            lecTotal.Text = sumLec().ToString();
            labTotal.Text = sumLab().ToString();
        }

        private void removeCourse5_Click(object sender, RoutedEventArgs e)
        {

            courseCode5.Text = "";
            descriptiveTitle5.Text = "";
            lec5.Text = "";
            lab5.Text = "";
            instructor5.Text = "";

            lecTotal.Text = sumLec().ToString();
            labTotal.Text = sumLab().ToString();
        }

        private void removeCourse6_Click(object sender, RoutedEventArgs e)
        {

            courseCode6.Text = "";
            descriptiveTitle6.Text = "";
            lec6.Text = "";
            lab6.Text = "";
            instructor6.Text = "";

            lecTotal.Text = sumLec().ToString();
            labTotal.Text = sumLab().ToString();
        }

        private void removeCourse7_Click(object sender, RoutedEventArgs e)
        {

            courseCode7.Text = "";
            descriptiveTitle7.Text = "";
            lec7.Text = "";
            lab7.Text = "";
            instructor7.Text = "";

            lecTotal.Text = sumLec().ToString();
            labTotal.Text = sumLab().ToString();
        }

        private void removeCourse8_Click(object sender, RoutedEventArgs e)
        {

            courseCode8.Text = "";
            descriptiveTitle8.Text = "";
            lec8.Text = "";
            lab8.Text = "";
            instructor8.Text = "";

            lecTotal.Text = sumLec().ToString();
            labTotal.Text = sumLab().ToString();
        }

        private void removeCourse9_Click(object sender, RoutedEventArgs e)
        {

            courseCode9.Text = "";
            descriptiveTitle9.Text = "";
            lec9.Text = "";
            lab9.Text = "";
            instructor9.Text = "";

            lecTotal.Text = sumLec().ToString();
            labTotal.Text = sumLab().ToString();
        }
    }
}
