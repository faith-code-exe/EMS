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
    /// Interaction logic for FirstTImeUse.xaml
    /// </summary>
    public partial class FirstTImeUse : Window
    {
        public FirstTImeUse()
        {
            InitializeComponent();
            bindQuestion1("");
            bindQuestion2(""); 
            bindQuestion3("");
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ShowPassowrd_Checked(object sender, RoutedEventArgs e)
        {
            passwordPwd.Visibility = Visibility.Hidden;
            passwordText.Visibility = Visibility.Visible;
            passwordText.Text = passwordPwd.Password;
        }

        private void HidePassword_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordPwd.Visibility = Visibility.Visible;
            passwordText.Visibility = Visibility.Hidden;
            passwordPwd.Password = passwordText.Text;
        }

        private void bindQuestion1(string selectedQuestion)
        {
            question1.Items.Clear();

            string choiceQuestion1 = "What is your mother's maiden name?";
            string choiceQuestion2 = "What is the name of your first pet?";
            string choiceQuestion3 = "What was your first vehicle?";
            string choiceQuestion4 = "What elementary school did you attend?";
            string choiceQuestion5 = "What is the name of the town where you were born?";

            if (question2.SelectedIndex != 0 && question3.SelectedIndex != 0
                && choiceQuestion1 != selectedQuestion)
            {
                question1.Items.Add(new ComboBoxItem() { Content = choiceQuestion1 });
            }
            if (question2.SelectedIndex != 1 && question3.SelectedIndex != 1
                && choiceQuestion2 != selectedQuestion)
            {
                question1.Items.Add(new ComboBoxItem() { Content = choiceQuestion2 });
            }
            if (question2.SelectedIndex != 2 || question3.SelectedIndex != 2
                && choiceQuestion3 != selectedQuestion)
            {
                question1.Items.Add(new ComboBoxItem() { Content = choiceQuestion3 });
            }
            if (question2.SelectedIndex != 3 || question3.SelectedIndex != 3
                && choiceQuestion4 != selectedQuestion)
            {
                question1.Items.Add(new ComboBoxItem() { Content = choiceQuestion4 });
            }
            if (question2.SelectedIndex != 4 || question3.SelectedIndex != 4
                && choiceQuestion5 != selectedQuestion)
            {
                question1.Items.Add(new ComboBoxItem() { Content = choiceQuestion5 });
            }
        }

        private void bindQuestion2(string selectedQuestion)
        {
            question2.Items.Clear();

            string choiceQuestion1 = "What is your mother's maiden name?";
            string choiceQuestion2 = "What is the name of your first pet?";
            string choiceQuestion3 = "What was your first vehicle?";
            string choiceQuestion4 = "What elementary school did you attend?";
            string choiceQuestion5 = "What is the name of the town where you were born?";

            if (question1.SelectedIndex != 0 && question3.SelectedIndex != 0
                && choiceQuestion1 != selectedQuestion)
            {
                question2.Items.Add(new ComboBoxItem() { Content = choiceQuestion1});
            }
            if (question1.SelectedIndex != 1 && question3.SelectedIndex != 1
                && choiceQuestion2 != selectedQuestion)
            {
                question2.Items.Add(new ComboBoxItem() { Content = choiceQuestion2 });
            }
            if (question1.SelectedIndex != 2 || question3.SelectedIndex != 2
                && choiceQuestion3 != selectedQuestion)
            {
                question2.Items.Add(new ComboBoxItem() { Content = choiceQuestion3 });
            }
            if (question1.SelectedIndex != 3 || question3.SelectedIndex != 3
                && choiceQuestion4 != selectedQuestion)
            {
                question2.Items.Add(new ComboBoxItem() { Content = choiceQuestion4 });
            }
            if (question1.SelectedIndex != 4 || question3.SelectedIndex != 4
                && choiceQuestion5 != selectedQuestion)
            {
                question2.Items.Add(new ComboBoxItem() { Content = choiceQuestion5 });
            }   
        }

        private void bindQuestion3(string selectedQuestion)
        {
            question3.Items.Clear();

            string choiceQuestion1 = "What is your mother's maiden name?";
            string choiceQuestion2 = "What is the name of your first pet?";
            string choiceQuestion3 = "What was your first vehicle?";
            string choiceQuestion4 = "What elementary school did you attend?";
            string choiceQuestion5 = "What is the name of the town where you were born?";

            if (question1.SelectedIndex != 0 && question2.SelectedIndex != 0
                && choiceQuestion1 != selectedQuestion)
            {
                question3.Items.Add(new ComboBoxItem() { Content = choiceQuestion1 });
            }
            if (question1.SelectedIndex != 1 && question2.SelectedIndex != 1
                && choiceQuestion2 != selectedQuestion)
            {
                question3.Items.Add(new ComboBoxItem() { Content = choiceQuestion2 });
            }
            if (question1.SelectedIndex != 2 || question2.SelectedIndex != 2
                && choiceQuestion3 != selectedQuestion)
            {
                question3.Items.Add(new ComboBoxItem() { Content = choiceQuestion3 });
            }
            if (question1.SelectedIndex != 3 || question2.SelectedIndex != 3
                && choiceQuestion4 != selectedQuestion)
            {
                question3.Items.Add(new ComboBoxItem() { Content = choiceQuestion4 });
            }
            if (question1.SelectedIndex != 4 || question2.SelectedIndex != 4
                && choiceQuestion5 != selectedQuestion)
            {
                question3.Items.Add(new ComboBoxItem() { Content = choiceQuestion5 });
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxt.Text;
            string password = "";
            string confirmPassword = confirmPasswordPwd.Password;

            if (passwordPwd.IsVisible)
            {
                password = passwordPwd.Password;
            }
            else if (passwordText.IsVisible)
            {
                password = passwordText.Text;
            }

            ComboBoxItem q1CMB = (ComboBoxItem)question1.SelectedItem;
            ComboBoxItem q2CMB = (ComboBoxItem)question2.SelectedItem;
            ComboBoxItem q3CMB = (ComboBoxItem)question3.SelectedItem;

            string ans1 = answer1.Text.ToLower();
            string ans2 = answer2.Text.ToLower();
            string ans3 = answer3.Text.ToLower();

            if (name == "" || password == "" || confirmPassword == "" ||
                ans1 == "" || ans2 == "" || ans3 == "")
            {
                MessageWindow message = new MessageWindow();
                message.message.Text = "All fields must not be empty";
                message.ShowDialog();
            }
            else if (question1.SelectedIndex < 0 || question2.SelectedIndex < 0
                || question3.SelectedIndex < 0 ||
                question1.SelectedIndex == question2.SelectedIndex ||
                question1.SelectedIndex == question3.SelectedIndex ||
                question3.SelectedIndex == question2.SelectedIndex)
            {
                MessageWindow message = new MessageWindow();
                message.message.Text = "Please select 3 different questions";
                message.ShowDialog();
            }
            else if (password != confirmPassword)
            {
                MessageWindow message = new MessageWindow();
                message.message.Text = "Confirm password do not Match";
                message.ShowDialog();
            }
            else if (password.Length < 6 || password.Length > 12)
            {
                MessageWindow msg = new MessageWindow();
                msg.message.Text = "Minimum of 6 characters and maximum of 12 characters is required for password.";
                msg.ShowDialog();
            }
            else
            {
                try
                {
                    var pwdTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
                    string ps = System.Convert.ToBase64String(pwdTextBytes);

                    saveUser(name, ps);

                    string q1 = q1CMB.Content.ToString();
                    string q2 = q2CMB.Content.ToString();
                    string q3 = q3CMB.Content.ToString();

                    var ans1HashByte = System.Text.Encoding.UTF8.GetBytes(ans1);
                    string a1 = System.Convert.ToBase64String(ans1HashByte);

                    var ans2HashByte = System.Text.Encoding.UTF8.GetBytes(ans2);
                    string a2 = System.Convert.ToBase64String(ans2HashByte);

                    var ans3HashByte = System.Text.Encoding.UTF8.GetBytes(ans3);
                    string a3 = System.Convert.ToBase64String(ans3HashByte);

                    saveQuestion(q1, q2, q3, a1, a2, a3);

                    MessageWindow message = new MessageWindow();
                    message.message.Text = "Your account has been saved. Login is required for entering the system.";
                    message.ShowDialog();
                    Login login = new Login();
                    login.Show();
                    Close();
                    
                }
                catch (Exception err)
                {
                    MessageWindow message = new MessageWindow();
                    message.message.Text = err.ToString();
                    message.ShowDialog();
                }
            }
        }

        private void saveUser(string name, string password)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = "INSERT INTO user(name, password) VALUES(@name, @password)";

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);

            cmd.Prepare();

            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void saveQuestion(string q1, string q2, string q3, string ans1, string ans2, string ans3)
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";

            using var con = new SQLiteConnection(cs);
            con.Open();

            int count = 1;

            while(count <= 3)
            {
                using var cmd = new SQLiteCommand(con);

                if (count == 1)
                {
                    cmd.CommandText = "INSERT INTO recoveryquestions(question, answer) VALUES(@question, @answer)";

                    cmd.Parameters.AddWithValue("@question", q1);
                    cmd.Parameters.AddWithValue("@answer", ans1);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                else if(count == 2)
                {
                    cmd.CommandText = "INSERT INTO recoveryquestions(question, answer) VALUES(@question, @answer)";

                    cmd.Parameters.AddWithValue("@question", q2);
                    cmd.Parameters.AddWithValue("@answer", ans2);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                else if (count == 3)
                {
                    cmd.CommandText = "INSERT INTO recoveryquestions(question, answer) VALUES(@question, @answer)";

                    cmd.Parameters.AddWithValue("@question", q3);
                    cmd.Parameters.AddWithValue("@answer", ans3);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                count += 1;
            }

            con.Close();
        }

        private void changeQuestion1(object sender, SelectionChangedEventArgs e)
        {
            answer1.Text = "";
        }

        private void changeQuestion2(object sender, SelectionChangedEventArgs e)
        {
            answer2.Text = "";
        }

        private void changeQuestion3(object sender, SelectionChangedEventArgs e)
        {
            answer3.Text = "";
        }
    }
}
