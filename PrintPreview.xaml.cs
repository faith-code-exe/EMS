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

using System.Printing;

namespace EMS
{
    /// <summary>
    /// Interaction logic for PrintPreview.xaml
    /// </summary>
    public partial class PrintPreview : Window
    {
        public PrintPreview()
        {
            InitializeComponent();
            fetchAdministrators();
        }

        //Top bar functions
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
        //end of Top bar functions


        private void printBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageWindow msg = new MessageWindow();
            msg.message.Text = "Before clicking print make sure that the document size in preferences is set to long or 8.5 x 13 inches";
            msg.ShowDialog();

            Thickness printPageMargin = printPage.Margin;
            if (printPageMargin.Top == 20)
            {
                printPage.Margin = new Thickness(20, -150, 20, 20);
            }

            copyS.Text = "Student's Copy";
            copyD.Text = "Dean's Copy";
            PrintDialog printDlg = new PrintDialog();
           if (printDlg.ShowDialog() == true)
           {
                printDlg.PrintVisual(printPage, "Grid Printing.");
           }

            copyS.Text = "Registrar's Copy";
            copyD.Text = "Accounting's Copy";
            if (printDlg.ShowDialog() == true)
            {
                printDlg.PrintVisual(printPage, "Grid Printing.");
            }

            copyS.Text = "";
            copyD.Text = "";
            printPage.Margin = new Thickness(20, 20, 20, 20);
        }

        private void fetchAdministrators()
        {
            string cs = "Data Source=.\\EmsDB.db;Version=3";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM 'administrators'";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();

            int count = 1;

            while(rdr.Read())
            {
                if (count == 1)
                {
                    deanNameS.Text = rdr.GetString(2).ToUpper();
                    deanPositionS.Text = rdr.GetString(1);

                    deanNameD.Text = rdr.GetString(2).ToUpper();
                    deanPositionD.Text = rdr.GetString(1);

                    //new here
                    deanNameSN.Text = rdr.GetString(2).ToUpper();
                    deanPositionSN.Text = rdr.GetString(1);

                    deanNameDN.Text = rdr.GetString(2).ToUpper();
                    deanPositionDN.Text = rdr.GetString(1);
                } 
                else if (count == 2)
                {
                    vpaNameS.Text = rdr.GetString(2).ToUpper();
                    vpaPositionS.Text = rdr.GetString(1);

                    vpaNameD.Text = rdr.GetString(2).ToUpper();
                    vpaPositionD.Text = rdr.GetString(1);

                    //new here
                    vpaNameSN.Text = rdr.GetString(2).ToUpper();
                    vpaPositionSN.Text = rdr.GetString(1);

                    vpaNameDN.Text = rdr.GetString(2).ToUpper();
                    vpaPositionDN.Text = rdr.GetString(1);
                }
                else if (count == 3)
                {
                    cashierNameS.Text = rdr.GetString(2).ToUpper();
                    cashierPositionS.Text = rdr.GetString(1);

                    cashierNameD.Text = rdr.GetString(2).ToUpper();
                    cashierPositionD.Text = rdr.GetString(1);

                    //new here
                    cashierNameSN.Text = rdr.GetString(2).ToUpper();
                    cashierPositionSN.Text = rdr.GetString(1);

                    cashierNameDN.Text = rdr.GetString(2).ToUpper();
                    cashierPositionDN.Text = rdr.GetString(1);
                }
                else if (count == 4)
                {
                    srNameS.Text = rdr.GetString(2).ToUpper();
                    srPositionS.Text = rdr.GetString(1);

                    srNameD.Text = rdr.GetString(2).ToUpper();
                    srPositionD.Text = rdr.GetString(1);

                    //new here

                    srNameSN.Text = rdr.GetString(2).ToUpper();
                    srPositionSN.Text = rdr.GetString(1);

                    srNameDN.Text = rdr.GetString(2).ToUpper();
                    srPositionDN.Text = rdr.GetString(1);
                } 
                else if (count == 5)
                {
                    gcNameDN.Text = rdr.GetString(2).ToUpper();
                    gcPositionDN.Text = rdr.GetString(1);

                    gcNameSN.Text = rdr.GetString(2).ToUpper();
                    gcPositionSN.Text = rdr.GetString(1);
                }
                count += 1;
            }

            consentD.Text = "I declare that I am fully aware that the above data shall be used for enrollment and other academic purposes. I trust that the above data shall remain confidential, hence I \ngive my consent that the same data be secured and accessed for subsequent validation. I further affirm that all statements/data, which appear in this enrollment slip form \nand made by me are true, correct and complete to the best of my knowledge and belief.";
            consentS.Text = "I declare that I am fully aware that the above data shall be used for enrollment and other academic purposes. I trust that the above data shall remain confidential, hence I \ngive my consent that the same data be secured and accessed for subsequent validation. I further affirm that all statements/data, which appear in this enrollment slip form \nand made by me are true, correct and complete to the best of my knowledge and belief.";
        }      

    }
}
