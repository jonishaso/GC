using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace SmartPTT_API
{
    class StarGuestReply : IDisposable
    {

        SmtpClient client = new SmtpClient();

        MainForm parentForm;
        public void Dispose()
        {

        }

        public StarGuestReply(MainForm aForm)
        {
            parentForm = aForm;
        }

        private void setupSMTP()
        {
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("372Starres@starwoodhotels.com", "Starwood2!");
            //client.UseDefaultCredentials = false;
            client.Port = 25; //port 25: unencrypted, port 587: SSL
            client.Host = "standardrelay.starwoodhotels.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = false;
        }

        public void replyToStarGuest(string toAddress, string subjectLine, string bodyOfEmail, string returnAddress)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(returnAddress));
            msg.From = new MailAddress("372Starres@starwoodhotels.com");
            msg.Subject = subjectLine;
            msg.Body = bodyOfEmail + "\n" + "<" + toAddress + ">";
            msg.IsBodyHtml = false;

            parentForm.logAction("Sending to: " + toAddress);
            parentForm.logAction("Subject Line: " + "Re: " + subjectLine);
            parentForm.logAction("Contents of Email: " + bodyOfEmail);

            try
            {
                client.Send(msg);
                parentForm.logAction("Message successfully emailed to " + toAddress);      
            }
            catch (Exception ex)
            {
                parentForm.logAction("Message failed.");
            }
        }
    }
}
