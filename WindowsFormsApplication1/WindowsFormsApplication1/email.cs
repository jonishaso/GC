using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// public string directoryPath = "";
namespace WindowsFormsApplication1
{
    public class email
    {
        public string fromAddress;
        public string toAddress;
        public string subjectLine;
        public string eventID;
        public string content;

        public email(){ }

    }
    public class emailWatcher
    {
        public email lastEmail { get; private set; }
        private string lastEmailFullName;
        public List<email> lastTenEmail {get; private set;}
        private FileSystemWatcher directoryWatcher;
        private string Path;

       
        public emailWatcher(string directoryPath)
        {
            if (System.IO.Directory.Exists(directoryPath))
            {
                Path = directoryPath;
                lastEmailFullName = new DirectoryInfo(Path)
                                .GetFiles("*.txt")
                                .OrderByDescending(f => f.LastWriteTime)
                                .First().FullName;
                directoryWatcher = new FileSystemWatcher();
                directoryWatcher.Path = directoryPath;
                directoryWatcher.Filter = "*.txt";
                directoryWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite;
                directoryWatcher.Created += AddNewEnmailToList;
            }

        }

        public email FreshEmail()
        {
            string pathfullname = new DirectoryInfo(Path)
                                .GetFiles("*.txt")
                                .OrderByDescending(f => f.LastWriteTime)
                                .First().FullName;
            if (pathfullname != lastEmailFullName)
            {
                IEnumerable<string> EmailInLine = File.ReadLines(pathfullname);
                string[] EmailInArray = EmailInLine
                                        .Cast<string>()
                                        .Where(val => val != "")
                                        .ToArray<string>();
                // 0 => fromaddress, 1=> to_address, 3=>subject, 4~end=>content

                lastEmail.fromAddress = EmailInArray[0].Substring(EmailInArray[0].IndexOf(">") + 3);
                lastEmail.toAddress = EmailInArray[1].Substring(EmailInArray[1].IndexOf(">") + 2); ;
                lastEmail.subjectLine = EmailInArray[2].Substring(EmailInArray[3].IndexOf(">") + 2); ;
                //for (int i = 3; i < (EmailInArray.Length - 1); i++)
                //{
                //   content += string.Format("{0} ", EmailInArray[i]);
                //}
                //eventID = subjectLine;
                return lastEmail;
            }
            else
                return lastEmail;
            
        }

        private void AddNewEnmailToList(object sender, EventArgs e)
        {
            lastTenEmail.Add(FreshEmail());
        }
       
    }
}
