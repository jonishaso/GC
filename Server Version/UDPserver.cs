using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Data;

namespace SmartPTT_API
{
    class UDPserver
    {
        private const int receivePort = 11000;
        private const int sendPort = 9999;
        private const string ipString = "192.168.1.219";
        private static MainForm form;
        public static UdpClient udpSend { get; private set; }
        public static UdpClient udpReceive { get; private set; }

        public UDPserver(MainForm f)
        {
            form = f;
        }

        public bool startReceive()
        {
            try
            {             
                udpReceive = new UdpClient(new IPEndPoint(IPAddress.Parse(ipString), receivePort));
                udpReceive.BeginReceive(new AsyncCallback(receiveCallBack), null);
                udpSend = new UdpClient(new IPEndPoint(IPAddress.Parse(ipString),sendPort));
                //IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
              
               
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("unable to establish UDP server : {0}", e.ToString()));
                return false;
            }
            form.consoleBox.AppendText("UDP server start to receive message \n");
            return true;
        }

        private void receiveCallBack(IAsyncResult obj)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any,0);//just initial a new endpoint, will be override later;
            byte[] udpDatagram = udpReceive.EndReceive(obj, ref ep);// client side IP address is stored in ep
            // the received message format should be like this
            //1) init>                            (client side start up and ask for user inform list)
            //2) radio>to:****;msg:******         (client side send request for sending a message to someone by radio)
            //3) mobile>to:***;msg:******         (client side send request for sending a message to someone by mobile)
            string content = Encoding.ASCII.GetString(udpDatagram, 0, udpDatagram.Length);
            char[] seperator = { '>', ':', ';' };
            string[] splitedContent = content.Split(seperator);
            // so the first element of splitedContent should be init, radio,or mobile.
            //the third element should be destination address and the fifth is message content.

            if (splitedContent[0] == "init")
            {
                //UdpClient sender = new UdpClient();
                byte[] bytes = dataTableConvertToByte(form.dbConn.selectRow().Tables["users"]);
                udpSend.BeginSend(bytes, bytes.Length, new IPEndPoint(IPAddress.Parse("192.168.1.219"), 11001),new AsyncCallback(sendCallback), null);
                //udpSend.Send(bytes, bytes.Length);
            }
            else if (splitedContent[0] == "radio")
            {
                form.sendRadio(splitedContent[2], splitedContent[4]);
                string info = string.Format("{0} send radio to {1} \n", ep.ToString(), splitedContent[2]);
                form.consoleBox.AppendText(info);
            }
            else if (splitedContent[0] == "mobile")
            {
                form.sendSMS(splitedContent[2], splitedContent[4]);
                string info = string.Format("{0} send radio to {1} \n", ep.ToString(), splitedContent[2]);
                form.consoleBox.AppendText(info);

            }
            else
            {
                udpReceive.BeginReceive(new AsyncCallback(receiveCallBack), null);
                form.consoleBox.AppendText(string.Format("receive an exception from {0} silde \n",ep.ToString()));
                return;
            }
            udpReceive.BeginReceive(new AsyncCallback(receiveCallBack), null);
        }

        private void sendCallback(IAsyncResult obj)
        {
            form.consoleBox.AppendText("a new client_side joint" + "\n");
        }

        private byte[] dataTableConvertToByte(DataTable dbtable)
        {
            string str = JsonConvert.SerializeObject(dbtable);
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
