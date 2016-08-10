using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
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
            DateTime expiration = new DateTime(2016, 7, 22);    
            // Once the function is expired, it will show the message
            if (DateTime.Compare(today, expiration) > 0)
            {
                MessageBox.Show("The application has expired.");
            }
            else
            {
                StreamReader r = new StreamReader(string.Format("{0}/serverConfig.json", Path.GetDirectoryName(Application.ExecutablePath)));
                string json = r.ReadToEnd();
                config jsonInfo = JsonConvert.DeserializeObject<config>(json);
                string sqlConn = jsonInfo.sqlConnString.Replace("/", @"\");
                Application.Run(new MainForm(new sql(sqlConn),jsonInfo));
            }
        }
    }
    public class config
    {
        public string sqlConnString { get; set; }
        public string radioServerIPString { get; set; }
        public int contralStationID { get; set; }
        public string GSMPort { get; set; }
    }
}
