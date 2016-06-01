using System;
using System.Windows.Forms;
using System.IO;

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

            DateTime expiration = new DateTime(2016, 2, 17);
            bool setExpiration = false;

            if (setExpiration)
            {
                if (DateTime.Compare(today, expiration) > 0)
                {
                    MessageBox.Show("The application has expired.");
                }
                else
                {
                    if (File.Exists(""))
                    {
                        Application.Run(new MainForm());
                    }
                    else
                    {
                        Application.Run(new ConfigureApp(false));
                    }
                }
            }
            else
            {
                if (File.Exists(@"C:\WWSI\config\config.txt"))
                {
                    Application.Run(new MainForm());
                }
                else
                {
                    Application.Run(new ConfigureApp(false));
                }
            }
        }
    }
}
