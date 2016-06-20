using System;
using System.Windows.Forms;
using System.IO;
using System.IO.IsolatedStorage;

namespace SmartPTT_API
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DateTime today = DateTime.Now;

            // The function is to set expiration date for the program
            // Note: whenever you modify the expiration, don't forget modify another one in
            // MainForm class, that one is showing the message how many days left in the form
            DateTime expiration = new DateTime(2016, 7, 10);    

            // Once the function is expired, it will show the message
            if (DateTime.Compare(today, expiration) > 0)
            {
                MessageBox.Show("The application has expired.");
            }
            else
            {

                Application.Run(new MainForm(new sql()));
                //Application.Run(new MainForm());
            }


        }
    }
}
