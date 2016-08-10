using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;

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

            //Application.ThreadException += applicationThreadException;

            //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //AppDomain.CurrentDomain.UnhandledException += unhandledException;

        }

        private static void applicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            handleException(e.Exception);
        }

        private static void unhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            handleException(e.ExceptionObject as Exception);
        }

        private static void handleException(Exception ex)
        {
            logAction(ex.Message);
            logAction(ex.StackTrace);

            if (ex.InnerException != null)
            {
                logAction(ex.InnerException.Message);
                logAction(ex.InnerException.StackTrace);
            }               
        }

        public static void logAction(string msg)
        {
            try
            {
                Thread.Sleep(1000);
                string logPath = @"C:\WWSI\Logs\WWSI Application Log.txt";
                //WWSI - LAPTOP
                //string logPath = @"C:\Alert Log Backup\EmailLog.txt";
                using (StreamWriter writer = File.AppendText(logPath))
                {
                    writer.WriteLine("Application Crash Exception Occurred: [" + DateTime.Now.ToString() + "]: " + msg);
                }
            }
            catch
            {

            }            
        }
    }
}
