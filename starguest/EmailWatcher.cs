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
    class EmailWatcher
    {
        //FileSystemWatcher watchEmailDirectory = new FileSystemWatcher();//fix issue of switching into ideal after 
        FileSystemWatcher watchEmailDirectory;
        //int fileLogNum;
        MainForm parentForm;
        List<string> listOfAllLines = new List<string>();
        List<string> listOfTextLines = new List<string>();
        string eventID;
        string bodyOfEmail;
        string radioID;
        string returnAddress;
        string subjectLine;
        private bool toSend;
        bool isStarGuest = false;
        string savemailDir = @"C:\MMI\ALERT\savemail";
        #region Original
        //IPAddress securityRadio = IPAddress.Parse("12.156");
        //string[] radioList = { "12.70" };
        //string[] radioList = { "12.101", "12.102", "12.103", "12.104", "12.105",
        //                        "12.116", "12.117", "12.118", "12.119", "12.120",
        //                        "12.121", "12.122", "12.123", "12.127", "12.128",
        //                        "12.132", "12.133", "12.134", "12.135", "12.140",
        //                        "12.141", "12.142", "12.146", "12.149", "12.156"};
        #endregion



        public EmailWatcher(MainForm aForm)
        {
            parentForm = aForm;
            watchEmailDirectory = new FileSystemWatcher();
            watchEmailDirectory.Path = savemailDir;
            watchEmailDirectory.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.LastWrite
                                               |NotifyFilters.FileName|NotifyFilters.LastAccess;
            watchEmailDirectory.Changed += WatchEmailDirectory_Changed;
            watchEmailDirectory.EnableRaisingEvents = true;
            //setupEmailWatch();
            #region Original
            //getLastCreatedFile();
            #endregion
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
            try
            {
                watchEmailDirectory.EnableRaisingEvents = false;
                readLatestEmailLog(e.FullPath); //Line 113
            }
            finally { watchEmailDirectory.EnableRaisingEvents = true; }
            
            listOfAllLines.Clear();

            #region Original
            //if (toSend)
            //{
            //    foreach (var item in Constants.Config.radioList)
            //    {
            //        IPAddress securityRadio = IPAddress.Parse(item);
            //        parentForm.sendToRadio(securityRadio, bodyOfEmail);
            //        parentForm.logAction("Radio ID: " + item + ". Message: " + bodyOfEmail);
            //        parentForm.logAction("Sent successfully.");
            //    }
            //    #region Original
            //    //IPAddress anIP = IPAddress.Parse(radioID);                
            //    //parentForm.sendToRadio(anIP, bodyOfEmail);
            //    #endregion
            //}
            #endregion

            parentForm.logAction("End of task.");
        }

        private void SendToBMS()
        {
            parentForm.logAction("BMS request, sending to:");
            foreach (var item in Constants.Config.bmsRadioList)
            {
                IPAddress securityRadio = IPAddress.Parse(item);
                parentForm.sendToRadio(securityRadio, bodyOfEmail);
                parentForm.logAction("Radio ID: " + item + ". Message: " + bodyOfEmail);
                parentForm.logAction("BMS request sent successfully.");
            }
        }

        private void SendToStarGuest(string ip)
        {
            parentForm.logAction("StarGuest request, sending to:");
            IPAddress securityRadio = IPAddress.Parse(ip);
            parentForm.sendToRadio(securityRadio, bodyOfEmail);
            parentForm.logAction("Radio ID: " + ip + ". Message: " + bodyOfEmail);
            parentForm.logAction("StarGuest request sent successfully.");
        }

        private void readLatestEmailLog(string filePath)
        {
            watchEmailDirectory.EnableRaisingEvents = false;
            try
            {
                #region Original
                //string filePath = string.Format(@"C:\MMI\ALERT\savemail\Mail{0}.log", fileLogNum);
                #endregion

                string line;
                //var directory = new DirectoryInfo(savemailDir);

                //if (directory.Exists)
                //{
                    //parentForm.logAction(string.Format("Directory: {0} Found", savemailDir));
                    //var latestFile = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).FirstOrDefault();
                    //if (latestFile != null)
                    //{
                       // filePath = latestFile.FullName;
                        parentForm.logAction(string.Format("Search for email: {0}", filePath));

                        using (StreamReader email = new StreamReader(filePath))
                        {
                            parentForm.logAction(string.Format("{0} found", filePath));

                            while ((line = email.ReadLine()) != null)
                            {
                                listOfAllLines.Add(line);
                            }
                            
                            #region New Fix 27-06-2016 Malcolm
                            getEmailContentsV2();

                            //If this is a star guest email then forward
                            if (isStarGuest)
                            {
                                SendToStarGuest(radioID);
                                parentForm.replyStarGuest(eventID, returnAddress, radioID, subjectLine, bodyOfEmail);
                            }
                            //otherwise this is BMS, need to handle differently, broadcasting                            
                            else
                            {
                                SendToBMS();
                            }
                            
                            #endregion

                            #region Original 
                            //if (containsRadioID())
                            //{
                            //    #region Original
                            //    //fileLogNum++;
                            //    #endregion
                            //    getEmailContentsV2(); //Line 105
                            //    toSend = true;
                            //    parentForm.replyStarGuest(eventID, returnAddress, radioID, subjectLine, bodyOfEmail);
                            //    watchEmailDirectory.EnableRaisingEvents = true;
                            //    return;
                            //}
                            //else
                            //{
                            //    #region Original
                            //    //fileLogNum++;
                            //    #endregion
                            //    toSend = false;
                            //    parentForm.logAction("Email not processed: Not from StarGuest");
                            //    watchEmailDirectory.EnableRaisingEvents = true;
                            //    return;
                            //}
                            #endregion
                        }
                   // }
                //}
            }
            catch (Exception ex)
            {
                parentForm.logAction("Unable to process email");
                parentForm.logAction("Exception occurred");
                parentForm.logAction(ex.Message);
                parentForm.logAction(ex.StackTrace);
            }
        }

        #region Original
        //private bool containsRadioID()
        //{
        //    if (1 == 1)
        //    {
        //        //return listOfLines.ElementAt(11).Contains("rid");
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        #endregion


        private void getEmailContentsV2()
        {
            parentForm.logAction(string.Format("Line Count: {0}", listOfAllLines.Count));
            isStarGuest = false;

            int bodyLine = 7;
            #region origin
            //if (listOfAllLines.Count >= bodyLine)
            //{
            //    var lastIdx = listOfAllLines.Count - bodyLine;
            //    bodyOfEmail = string.Join(Environment.NewLine, listOfAllLines.GetRange(bodyLine, lastIdx));
            //    parentForm.logAction(string.Format("Body Of Email: {0}", bodyOfEmail));
            //}
            //else
            //{
            //    bodyOfEmail = listOfAllLines.ElementAt(bodyLine-1);
            //    parentForm.logAction(string.Format("Body Of Email: {0}", bodyOfEmail));
            //}
            #endregion origin
            if (listOfAllLines.Count > bodyLine)
            {
                var lastIdx = listOfAllLines.Count - bodyLine;
                bodyOfEmail = string.Join(Environment.NewLine, listOfAllLines.GetRange(bodyLine-1, lastIdx));
                parentForm.logAction(string.Format("Body Of Email: {0}", bodyOfEmail));
            }
            else
            {
                bodyOfEmail = listOfAllLines.ElementAt(bodyLine - 1);
                parentForm.logAction(string.Format("Body Of Email: {0}", bodyOfEmail));
            }
            #region fix issue of bodyofEmail is null

            #endregion fix issue of bodyofEmail is null
            returnAddress = removeWord(listOfAllLines.ElementAt(0), 6);
            subjectLine = removeWord(listOfAllLines.ElementAt(3), 9);
            eventID = getEventID(subjectLine);
            radioID = listOfAllLines.ElementAt(1);
            radioID = Regex.Replace(radioID, "[^0-9.]", "");
            radioID = radioID.Remove(radioID.Length - 1);

            try
            {
                bool starGuestEvent =
                    listOfAllLines.ElementAt(1).Replace("<TO>", "").StartsWith("sgm") ||
                    listOfAllLines.ElementAt(3).Replace("<SUBJECT>", "").StartsWith("SG Event");

                isStarGuest = starGuestEvent;
                parentForm.logAction(string.Format("isStartGuest: {0}", starGuestEvent));
            }
            catch
            {
                parentForm.logAction("Unable to parse startguest format, isStarGuest = 'false'");
                isStarGuest = false;
            }
        }

        public StarGuestRequest addNewRequest()
        {
            StarGuestRequest aRequest = new StarGuestRequest();
            aRequest.eventID = eventID;
            aRequest.returnAddress = returnAddress;
            aRequest.radioAddress = radioID;
            aRequest.subjectLine = subjectLine;
            aRequest.request = bodyOfEmail;

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
            foreach (string s in listOfAllLines)
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

        #region Original
        //private void originalProcess(StreamReader email)
        //{
        //    if (!containsRadioID())
        //    {
        //        fileLogNum++;
        //        toSend = false;
        //        parentForm.logAction("Email not processed: Not from StarGuest");
        //        watchEmailDirectory.EnableRaisingEvents = true;
        //        return;
        //    }
        //    else
        //    {
        //        getEmailContents(email);
        //        fileLogNum++;
        //        toSend = true;
        //        watchEmailDirectory.EnableRaisingEvents = true;
        //        return;
        //    }
        //}

        private void getLastCreatedFile()
        {
            //bool isEmpty = !Directory.EnumerateFiles(savemailDir).Any();
            //if (isEmpty)
            //{
            //    fileLogNum = 1;
            //}
            //else
            //{
            //    var directory = new DirectoryInfo(savemailDir);
            //    var myFile = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
            //    string str = myFile.ToString();
            //    str = Regex.Replace(str, @"\D", "");
            //    fileLogNum = Int32.Parse(str);
            //    fileLogNum++;
            //}
        }
        #endregion
    }
}
