using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;


namespace SmartPTT_API
{
    public class StarGuestRequest
    {
        public string returnAddress { get; private set; }
        public string radioAddress { get; private set; }
        public string request { get; private set; }
        public string subjectLine { get; private set; }
        public string eventID { get; private set; }

        MainForm ParentForm;
        public StarGuestRequest(EmailWatcher e, MainForm f )
        {
            ParentForm = f;                      
            this.returnAddress = e.returnAddress;
            this.radioAddress = e.radioID;
            this.request = e.bodyOfEmail;
            this.subjectLine = e.subjectLine;
            this.eventID = e.eventID;                
        }

        public void OnRequestChang()
        {
            Thread.Sleep(1000);
            //processTxtFile(newCopyPath);           
            System.Net.IPAddress RadioAddress = System.Net.IPAddress.Parse(radioAddress);               
            ParentForm.sendToRadio(RadioAddress, request);
            //finalList.Clear();
            Thread.Sleep(1000);
            //RefreshDirectory(@"C:\MMI\Alert\ComLog");
        }
    }
}
