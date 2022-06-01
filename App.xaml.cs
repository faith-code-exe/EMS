using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using System.Data.SQLite;

namespace EMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    

    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            isUserExist();
        }

        private void isUserExist()
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'user'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            if (!rdr.HasRows)
            {
                StartupUri = new Uri("FirstTImeUse.xaml", UriKind.Relative);
            } 
            else
            {
                StartupUri = new Uri("Login.xaml", UriKind.Relative);
            }
            con.Close();
        }
        
    }

    
}
