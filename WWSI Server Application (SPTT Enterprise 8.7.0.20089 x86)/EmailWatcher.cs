using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SmartPTT_API
{
    public class EmailWatcher
    {
        FileSystemWatcher watchEmailDirectory = new FileSystemWatcher();
        int fileLogNum;
        MainForm parentForm;
        List<string> listOfAllLines = new List<string>();
        List<string> listOfTextLines = new List<string>();
        public string eventID { get; private set; }
        public string bodyOfEmail { get; private set; }
        public string radioID { get; private set; }
        public string returnAddress { get; private set; }
        public string subjectLine { get; private set; }
        private bool toSend;
        string savemailDir = @"C:\MMI\ALERT\savemail";

        public EmailWatcher(MainForm aForm)
        {
            parentForm = aForm;
            setupEmailWatch();
            getLastCreatedFile();
            parentForm.logAction("Initialising Email Watcher...");
        }

        //Setup File System Watcher
        private void setupEmailWatch()
        {
            watchEmailDirectory.Path = savemailDir;
            watchEmailDirectory.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.LastWrite;
            watchEmailDirectory.Changed += WatchEmailDirectory_Changed;
            watchEmailDirectory.EnableRaisingEvents = true;
        }

        //Event fired when file change is detected
        private void WatchEmailDirectory_Changed(object sender, FileSystemEventArgs e)
        {
            parentForm.logAction("Email Detected.");
            readLatestEmailLog(); //Line 60
            listOfAllLines.Clear();
            if (toSend)
            {
                IPAddress anIP = IPAddress.Parse(radioID);
                parentForm.sendToRadio(anIP, bodyOfEmail);
                parentForm.logAction("Radio ID: " + radioID + ". Message: " + bodyOfEmail);
                parentForm.logAction("Sent successfully.");
            }
            parentForm.logAction("End of task.");
        }

        private void readLatestEmailLog()
        {
            watchEmailDirectory.EnableRaisingEvents = false;
            string line;
            string filePath = string.Format(@"C:\MMI\ALERT\savemail\Mail{0}.log", fileLogNum);
            using (StreamReader email = new StreamReader(filePath))
            {
                while ((line = email.ReadLine()) != null)
                {
                    listOfAllLines.Add(line);
                }
                if (containsRadioID())
                {     
                    fileLogNum++;
                    getEmailContentsV2(); //Line 105
                    toSend = true;
                    parentForm.replyStarGuest();
                    watchEmailDirectory.EnableRaisingEvents = true;
                    return;
                }
                else
                {
                    fileLogNum++;
                    toSend = false;
                    parentForm.logAction("Email not processed: Not from StarGuest");
                    watchEmailDirectory.EnableRaisingEvents = true;
                    return;
                }
            }
        }

        private bool containsRadioID()
        {
            if(1 == 1)
            {
                //return listOfLines.ElementAt(11).Contains("rid");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void getEmailContentsV2()
        {
            bodyOfEmail = listOfAllLines.ElementAt(6);
            returnAddress = removeWord(listOfAllLines.ElementAt(0), 6);
            subjectLine = removeWord(listOfAllLines.ElementAt(3), 9);
            eventID = getEventID(subjectLine);

            radioID = listOfAllLines.ElementAt(1);
            radioID = Regex.Replace(radioID, "[^0-9.]", "");
            radioID = radioID.Remove(radioID.Length - 1);
        }

        public StarGuestRequest addNewRequest()
        {
            StarGuestRequest aRequest = new StarGuestRequest(this,parentForm);
            return aRequest;
        }

        private string removeWord(string s, int x)
        {
            return s.Remove(0, x);
        }

        private string getEventID(string subject)
        {
            int index = subject.IndexOf(";");
            if (index > 0)
                subject = subject.Substring(0, index);
            subject = Regex.Match(subject, @"\d+").Value;
            return subject;
        }

        private List<string> removeNullOrEmp()
        {
            List<string> tempList = new List<string>();
            foreach(string s in listOfAllLines)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    tempList.Add(s);
                }
            }
            return tempList;
        }

        private string stringToIP(string stringIP)
        {
            string input = stringIP;
            Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            MatchCollection result = ip.Matches(input);
            return result[0].ToString();
        }

        private void getEmailContents(StreamReader email)
        {
            string line;
            while ((line = email.ReadLine()) != null)
            {
                listOfAllLines.Add(line);
            }

            bodyOfEmail = listOfAllLines.ElementAt(13);
            radioID = listOfAllLines.ElementAt(0);
            radioID = Regex.Replace(radioID, "[^0-9.]", "");
            radioID = radioID.Remove(radioID.Length - 1);
        }



        private bool lineContainsSGR(string line)
        {
            return line.Contains("sgr") || line.Contains("starguest");
        }

        private void originalProcess(StreamReader email)
        {
            if (!containsRadioID())
            {
                fileLogNum++;
                toSend = false;
                parentForm.logAction("Email not processed: Not from StarGuest");
                watchEmailDirectory.EnableRaisingEvents = true;
                return;
            }
            else
            {
                getEmailContents(email);
                fileLogNum++;
                toSend = true;
                watchEmailDirectory.EnableRaisingEvents = true;
                return;
            }
        }

        private void getLastCreatedFile()
        {
            bool isEmpty = !Directory.EnumerateFiles(savemailDir).Any();
            if (isEmpty)
            {
                fileLogNum = 1;
            }
            else
            {
                var directory = new DirectoryInfo(savemailDir);
                var myFile = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
                string str = myFile.ToString();
                str = Regex.Replace(str, @"\D", "");
                fileLogNum = Int32.Parse(str);
                fileLogNum++;
            }
        }
    }
}
