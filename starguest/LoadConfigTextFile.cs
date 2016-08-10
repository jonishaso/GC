using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SmartPTT_API
{
    class LoadConfigTextFile
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

        public LoadConfigTextFile()
        {

        }

        public bool enableSecurityPanel()
        {
            return SecurityPanel;
        }
        public bool enableFirePanel()
        {
            return FirePanel;
        }
        public bool enableStarGuest()
        {
            return StarGuest;
        }
        public bool enableExpiration()
        {
            return expiration;
        }
        public string getControlStation()
        {
            return controlStation;
        }
        public string getRadioServerIP()
        {
            return radioServerIP;
        }
        public string getDay()
        {
            return DD;
        }
        public string getMonth()
        {
            return MM;
        }
        public string getYear()
        {
            return YY;
        }
        public string getTestRadioIP()
        {
            return testRadioIP;
        }


        private List<string> loadTextFile()
        {
            List<string> listOfAllLines = new List<string>();
            string line;
            if (File.Exists(@"C:\WWSI\config\config.txt"))
            {
                using (StreamReader configLine = new StreamReader(@"C:\WWSI\config\config.txt"))
                {
                    while ((line = configLine.ReadLine()) != null)
                    {
                        listOfAllLines.Add(line);
                    }
                }
            }
            return listOfAllLines;
        }

        private void loadConfig(List<string> aList)
        {
            if (aList.ElementAt(0).Contains("true"))
            {
                SecurityPanel = true;
            }
            if (aList.ElementAt(1).Contains("true"))
            {
                FirePanel = true;
            }
            if (aList.ElementAt(2).Contains("true"))
            {
                StarGuest = true;
            }
            if (aList.ElementAt(3).Contains("true"))
            {
                expiration = true;
            }
            controlStation = aList.ElementAt(4);
            radioServerIP = aList.ElementAt(5);
            DD = aList.ElementAt(6);
            MM = aList.ElementAt(7);
            YY = aList.ElementAt(8);
            testRadioIP = aList.ElementAt(9);
        }


    }
}
