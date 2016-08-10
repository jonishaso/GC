using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SmartPTT_API
{
    public partial class ConfigureApp : Form
    {
        #region public properties
        public bool SecurityPanel;
        public bool FirePanel;
        public bool StarGuest;
        public bool expiration;
        public string controlStation;
        public string radioServerIP;
        public string DD;
        public string MM;
        public string YY;
        public string testRadioIP;
        #endregion

        EncryptDecryptString encryptDecrypt = new EncryptDecryptString();
        private string encryptPassword = "qweasdzxc";

        public ConfigureApp(bool load)
        {
            InitializeComponent();
            if (load)
            {
                loadConfig(loadTextFile());
            }
        }

        private void ConfigureApp_load(object sender, EventArgs e)
        {

        }

        private List<string> loadTextFile()
        {
            List<string> listOfAllLines = new List<string>();
            string line;
            string wholeString = "";
            if (File.Exists(@"C:\WWSI\config\config.txt"))
            {
                using (StreamReader configLine = new StreamReader(@"C:\WWSI\config\config.txt"))
                {
                    while ((line = configLine.ReadLine()) != null)
                    {
                        wholeString = encryptDecrypt.Decrypt(line, encryptPassword);
                    }
                }
            }
            string[] lineSplit = wholeString.Split('\n');
            foreach(string s in lineSplit)
            {
                listOfAllLines.Add(s);
            }
            return listOfAllLines;
        }

        private void loadConfig(List<string> aList)
        {
            if (aList.ElementAt(0).Contains("true"))
            {
                SPCheckbox.Checked = SecurityPanel = true;
            }
            if (aList.ElementAt(1).Contains("true"))
            {
                FPCheckbox.Checked = FirePanel = true;
            }
            if (aList.ElementAt(2).Contains("true"))
            {
                SGCheckbox.Checked = StarGuest = true;
            }
            if (aList.ElementAt(3).Contains("true"))
            {
                expirationCheckbox.Checked = expiration = true;
            }
            csIDTextBox.Text = controlStation = aList.ElementAt(4);
            rsIPTextBox.Text = radioServerIP = aList.ElementAt(5);
            dateTextbox.Text = DD = aList.ElementAt(6);
            monthTextBox.Text = MM = aList.ElementAt(7);
            yearTextBox.Text = YY = aList.ElementAt(8);
            radioIPTextBox.Text = testRadioIP = aList.ElementAt(9);
        }
        
        private string[] configApplication()
        {
            List<string> listOfConfig = new List<string>();
            StringBuilder aBuilder = new StringBuilder();
            if (SPCheckbox.Checked == true)
            {
                listOfConfig.Add("true");
            }
            else
            {
                listOfConfig.Add("false");
            }
            if (FPCheckbox.Checked == true)
            {
                listOfConfig.Add("true");
            }
            else
            {
                listOfConfig.Add("false");
            }
            if (SGCheckbox.Checked == true)
            {
                listOfConfig.Add("true");
            }
            else
            {
                listOfConfig.Add("false");
            }
            if (expirationCheckbox.Checked == true)
            {
                listOfConfig.Add("true");
            }
            else
            {
                listOfConfig.Add("false");
            }

            listOfConfig.Add(csIDTextBox.Text);
            listOfConfig.Add(rsIPTextBox.Text);
            listOfConfig.Add(dateTextbox.Text);
            listOfConfig.Add(monthTextBox.Text);
            listOfConfig.Add(yearTextBox.Text);
            listOfConfig.Add(radioIPTextBox.Text);

            return listOfConfig.ToArray();
        }

        private string encryptConfig()
        {
            StringBuilder aBuilder = new StringBuilder();
            foreach(string s in configApplication())
            {
                aBuilder.Append(s + "\n");
            }
            string textToEncrypt = aBuilder.ToString();
            return encryptDecrypt.Encrypt(textToEncrypt, encryptPassword);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\WWSI\config\config.txt", encryptConfig());
            MessageBox.Show("Please restart the Application.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
