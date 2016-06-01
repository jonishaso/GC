using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SmartPTT_API
{
    public partial class AlertLogWatcher : Form
    {
        string txtFilePath = @"C:\MMI\Alert\ComLog\Motorola.txt";
        //string newCopyPath = @"C:\Users\00370alert\Desktop\Alert Log Backup\DupeLog.txt";
        string newCopyPath = @"C:\WWSI\Logs\EventsData.txt";
        List<string> tempList = new List<string>();
        List<string> finalList = new List<string>();
        IPAddress securityRadio = IPAddress.Parse("12.104");
        FileSystemWatcher watchAlertLog = new FileSystemWatcher();
        FileSystemWatcher watchDupeLog = new FileSystemWatcher();
        MainForm parentForm;
        private int listCounter = 0;

        public AlertLogWatcher(MainForm form)
        {
            parentForm = form;
            InitializeComponent();
            RefreshDirectory(@"C:\MMI\Alert\ComLog");
            fileWatchMotorola();
            fileWatchLog();
        }

        private void fileWatchMotorola()
        {
            watchAlertLog.Path = @"C:\MMI\ALERT\ComLog";
            watchAlertLog.Filter = "Motorola.txt";
            watchAlertLog.NotifyFilter = NotifyFilters.Size;
            watchAlertLog.Changed += new FileSystemEventHandler(OnChanged);
            watchAlertLog.EnableRaisingEvents = true;
        }

        private void fileWatchLog()
        {
            //watchDupeLog.Path = @"C:\Users\00370alert\Desktop\Alert Log Backup";
            watchDupeLog.Path = @"C:\WWSI\Logs";
            watchDupeLog.Filter = "EventsData.txt";
            watchDupeLog.NotifyFilter = NotifyFilters.Size;
            watchDupeLog.Changed += new FileSystemEventHandler(OnLineChange);
            watchDupeLog.EnableRaisingEvents = true;
        }

        private void OnLineChange(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(1000);
            parentForm.logAction("Processing Message...");
            processTxtFile(newCopyPath);
            sendMsgToRadio();
            Thread.Sleep(1000);
            RefreshDirectory(@"C:\MMI\Alert\ComLog");
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(1000);
            parentForm.logAction("Detected file change.");
            write("");
            copyLogFile();
            parentForm.logAction("Copied file to EventsData.txt");
        }

        private void copyLogFile()
        {
            File.Copy(txtFilePath, newCopyPath, true);
        }

        private void processTxtFile(string filePath)
        {
            watchAlertLog.EnableRaisingEvents = false;
            string line;
            int counter = 0;
            tempList.Clear();

            try
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        tempList.Add(line);
                        counter++;
                    }
                }
                parentForm.logAction("[Processed Security text file.]");
            }
            catch
            {
                parentForm.logAction("[Secutiry Alarm Text file Error]");
            }

            if (tempList.Count > 0)
            {
                for (int i = listCounter; i < counter; i++)
                {
                    if (tempList.ElementAt(i).Contains(@"????"))
                    {
                        finalList.Add(tempList.ElementAt(i));
                    }
                }
                listCounter = tempList.Count;
            }

            watchAlertLog.EnableRaisingEvents = true;
        }

        private void processList(List<string> aList, int lineCount)
        {
            if (lineCount != 0)
            {
                aList.RemoveRange(0, lineCount);
            }
        }

        public bool thisIsSomething()
        {
            if (thisIsSomething() == true)
            {
                return false;
            }
            return true;
        }

        private void sendMsgToRadio()
        {
            if (finalList.Count > 0)
            {
                foreach (string str in finalList)
                {
                    parentForm.sendToRadio(securityRadio, str);
                }
                finalList.Clear();
                parentForm.logAction("Successfully sent Message.");
            }
            else
            {
                parentForm.logAction("Message failed to send.");
            }

        }

        private void write(string s)
        {
            DateTime now = DateTime.Now;
            AlertLog.AppendText("[" + now + "]: " + s);
        }

        #region Refresh
        public void RefreshDirectory(string fullPath)
        {
            SHChangeNotify(
                SHChangeNotifyEvents.UpdateItem,
                SHChangeNotifyFlags.PathW | SHChangeNotifyFlags.NotifyRecursive,
                fullPath,
                null);
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        public static extern void SHChangeNotify(SHChangeNotifyEvents eventID, SHChangeNotifyFlags flags, string path, string path2);

        [Flags]
        public enum SHChangeNotifyEvents : uint
        {
            RenameItem = 0x00000001,
            Create = 0x00000002,
            Delete = 0x00000004,
            MkDir = 0x00000008,
            RmDir = 0x00000010,
            MediaInserted = 0x00000020,
            MediaRemoved = 0x00000040,
            DriveRemoved = 0x00000080,
            DriveAdd = 0x00000100,
            NetShare = 0x00000200,
            NetUnshare = 0x00000400,
            Attributes = 0x00000800,
            UpdateDir = 0x00001000,
            UpdateItem = 0x00002000,
            ServerDisconnect = 0x00004000,
            UpdateImage = 0x00008000,
            DriveAddGui = 0x00010000,
            RenameFolder = 0x00020000,
            FreeSpace = 0x00040000,
            ExtendedEvent = 0x04000000,
            AssocChanged = 0x08000000,
            DiskEvents = 0x0002381F,
            GlobalEvents = 0x0C0581E0,
            AllEvents = 0x7FFFFFFF,
            Interrupt = 0x80000000
        }

        public enum SHChangeNotifyFlags : uint
        {
            IdList = 0x0000,
            PathA = 0x0001,
            PrinterA = 0x0002,
            Dword = 0x0003,
            PathW = 0x0005,
            PrinterW = 0x0006,
            Type = 0x00FF,
            Flush = 0x1000,
            FlushNoWait = 0x3000,
            NotifyRecursive = 0x10000
        }
        #endregion
    }
}
