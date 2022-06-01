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

namespace EMS
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private string cs = "Data Source=.\\EmsDB.db;Version=3";

        public Dashboard()
        {
            InitializeComponent();
            count1stYr.Text = getYrCount("1st Year").ToString();
            count2ndYr.Text = getYrCount("2nd Year").ToString();
            count3rdYr.Text = getYrCount("3rd Year").ToString();
            count4thYr.Text = getYrCount("4th Year").ToString();

            getPrograms();
        }

        private int getYrCount(string year)
        {
            using var con = new SQLiteConnection(this.cs);
            con.Open();

            string stm = "SELECT count(id) FROM students WHERE yrLevel = @year";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Prepare();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;
        }

        private int countPrograms()
        {

            using var con = new SQLiteConnection(this.cs);
            con.Open();

            string stm = "SELECT program FROM students";
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            string progIden = "";
            int countProgram = 0;

            while (rdr.Read())
            {
                if (progIden != rdr.GetString(0))
                {
                    progIden = rdr.GetString(0);
                    countProgram += 1;
                }
            }
            con.Close();
            return countProgram;
        }

        private void getPrograms()
        {
            string[] programs = new string[countPrograms()];

            using var con = new SQLiteConnection(this.cs);
            con.Open();

            string stm = "SELECT program FROM students";
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            string progIden = "";
            int count = 0;

            while (rdr.Read())
            {
                if (progIden != rdr.GetString(0))
                {
                    progIden = rdr.GetString(0);
                    programs[count] = rdr.GetString(0);
                    count += 1;
                }
            }
            con.Close();
            programsList.Items.Clear();
            foreach (string program in programs)
            {
                ProgramDashboard prg = new ProgramDashboard();

                prg.program = program;
                prg.count = programCount(program).ToString();

                programsList.Items.Add(prg);
            }
        }

        private int programCount(string program)
        {
            using var con = new SQLiteConnection(this.cs);
            con.Open();

            string stm = "SELECT count(id) FROM students WHERE program = @program";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@program", program);
            cmd.Prepare();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return count;
        }

    }

    public class ProgramDashboard
    {
        public string program { get; set; }
        public string count { get; set; }
    }
}
