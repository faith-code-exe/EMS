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
    /// Interaction logic for ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Window
    {
        public ForgetPassword()
        {
            InitializeComponent();
            fetchQuestions();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if  (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void fetchQuestions()
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";

            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT question FROM 'recoveryquestions'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            int count = 1;
            while (rdr.Read())
            {
                if (count == 1)
                {
                    question1.Text = rdr.GetString(0);
                }
                else if (count == 2)
                {
                    question2.Text = rdr.GetString(0);
                }
                else if (count == 3)
                {
                    question3.Text = rdr.GetString(0);
                }

                count++;
            }
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            string ans1 = answer1.Text.ToLower();
            string ans2 = answer2.Text.ToLower();
            string ans3 = answer3.Text.ToLower();

            string ques1 = question1.Text;
            string ques2 = question2.Text;
            string ques3 = question3.Text;

            string a1 = getQuestion(ques1);
            string a2 = getQuestion(ques2);
            string a3 = getQuestion(ques3);


            if (ans1 != a1 || ans2 != a2 || ans3 != a3)
            {
                MessageWindow msg = new MessageWindow();
                msg.message.Text = "Incorrect Answers";
                msg.ShowDialog();
            }
            else
            {
                Close();

                MessageWindow msg = new MessageWindow();
                msg.message.Text = "All answers are correct";
                msg.ShowDialog();
                
                PasswordReset pwdReset = new PasswordReset();
                pwdReset.ShowDialog();
            }
            
        }

        private string getQuestion(string question)
        {
            string answer = "";
            string cs = "Data Source=.\\EmsDB.db;Version=3";

            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT answer FROM 'recoveryquestions' WHERE question = @question";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@question", question);

            cmd.Prepare();

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                answer = rdr.GetString(0);
            }

            var answerText = System.Convert.FromBase64String(answer);
            string ans = System.Text.Encoding.UTF8.GetString(answerText);

            con.Close();

            return ans;
        }
       
    }
}
