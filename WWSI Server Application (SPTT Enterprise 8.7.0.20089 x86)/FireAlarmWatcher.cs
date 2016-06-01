using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace SmartPTT_API
{
    class FireAlarmWatcher
    {
        string txtFilePath = @"C:\MMI\Alert\ComLog\FireAlarm.txt";
        //string newCopyPath = @"C:\Users\00370alert\Desktop\Alert Log Backup\DupeFireLog.txt";
        string newCopyPath = @"C:\WWSI\Logs\FireEventsData.txt";
        List<string> tempList = new List<string>();
        List<string> copiedList = new List<string>();
        List<string> finalList = new List<string>();
        IPAddress securityRadio = IPAddress.Parse("12.156");
        string[] radioList = { "12.101", "12.102", "12.103", "12.104", "12.105",
                                "12.116", "12.117", "12.118", "12.119", "12.120",
                                "12.121", "12.122", "12.123", "12.127", "12.128",
                                "12.132", "12.133", "12.134", "12.135", "12.140",
                                "12.141", "12.142", "12.146", "12.149", "12.156"};
        FileSystemWatcher watchFireLog = new FileSystemWatcher();
        FileSystemWatcher watchDupeFireLog = new FileSystemWatcher();
        MainForm parentForm;
        private int listCounter = 0;

        public FireAlarmWatcher(MainForm form)
        {
            parentForm = form;
            RefreshDirectory(@"C:\MMI\Alert\ComLog");
            fileWatchFireAlarm();
            fileWatchFireLog();
        }

        private void fileWatchFireAlarm()
        {
            watchFireLog.Path = @"C:\MMI\ALERT\ComLog";
            watchFireLog.Filter = "FireAlarm.txt";
            watchFireLog.NotifyFilter = NotifyFilters.Size;
            watchFireLog.Changed += new FileSystemEventHandler(OnChanged);
            watchFireLog.EnableRaisingEvents = true;
        }

        private void fileWatchFireLog()
        {
            //watchDupeFireLog.Path = @"C:\Users\00370alert\Desktop\Alert Log Backup";
            watchDupeFireLog.Path = @"C:\WWSI\Logs";
            watchDupeFireLog.Filter = "FireEventsData.txt";
            watchDupeFireLog.NotifyFilter = NotifyFilters.Size;
            watchDupeFireLog.Changed += new FileSystemEventHandler(OnLineChange);
            watchDupeFireLog.EnableRaisingEvents = true;
        }

        private void OnLineChange(object sender, FileSystemEventArgs e)
        {
            //processTxtFile(copyTxtPath);
            //string line = getLastLine(newCopyPath);
            Thread.Sleep(1000);
            processTxtFile(newCopyPath);
            foreach (var item in radioList)
            {
                IPAddress securityRadio = IPAddress.Parse(item);
                foreach (string str in finalList)
                {
                    parentForm.sendToRadio(securityRadio, str);
                }
            }
            
            finalList.Clear();
            Thread.Sleep(1000);
            RefreshDirectory(@"C:\MMI\Alert\ComLog");
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {            
            Thread.Sleep(1000);
            copyLogFile();
        }

        private string getLastLine(string filePath)
        {
            return File.ReadLines(filePath).Last();
        }

        private void copyLogFile()
        {
            File.Copy(txtFilePath, newCopyPath, true);
        }

        private void processTxtFile(string filePath)
        {
            watchFireLog.EnableRaisingEvents = false;
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
                parentForm.logAction("[Processed Fire Alarm Text File.]");
            }
            catch
            {
                parentForm.logAction("[Fire Alarm Text File Error]");
            }

            if (tempList.Count > 0)
            {
                for (int i = listCounter; i < counter; i++)
                {
                    finalList.Add(tempList.ElementAt(i));
                }
                listCounter = tempList.Count;
            }

            watchFireLog.EnableRaisingEvents = true;
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
