using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Data;
using System.Threading.Tasks;

namespace SmartPTT_API
{
    class UDPserver
    {
        private const int receivePort = 11000;
        private const int sendPort = 9999;
        private string ipString; //192.168.1.212//10.108.96.44
        private static MainForm form;
        private byte[] dbBytes;
        public static UdpClient udpSend { get; private set; }
        public static UdpClient udpReceive { get; private set; }
        private event Action<string> writeConsole;     

        public UDPserver(MainForm f)
        {
            form = f;
            writeConsole += f.setTex;
        }

        public bool startReceive()
        {
            try
            {   
                ipString = Array.FindAll(Dns.GetHostEntry(Dns.GetHostName()).AddressList,a => a.AddressFamily == AddressFamily.InterNetwork)[0].ToString();
                udpReceive = new UdpClient(new IPEndPoint(IPAddress.Parse(ipString), receivePort));
                udpReceive.BeginReceive(new AsyncCallback(receiveCallBack), null);
                udpSend = new UdpClient(new IPEndPoint(IPAddress.Parse(ipString),sendPort));            
                dbBytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(form.dbConn.selectRow().Tables["users"]));              
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
            char[] seperator_0 = { ':' };
            string clientIP = ep.Address.ToString().Split(seperator_0)[0];
            //writeConsole(clientIP);

            // the received message format should be like this
            //1) init>                            (client side start up and ask for user inform list)
            //2) him>to:;msg:*******              (client side send message to all HIM group persons)
            //3) radio>to:****;msg:******         (client side send request for sending a message to someone by radio)
            //4) mobile>to:***;msg:******         (client side send request for sending a message to someone by mobile)

            string content = Encoding.ASCII.GetString(udpDatagram, 0, udpDatagram.Length);
            char[] seperator_1 = { '>', ':', ';' };
            string[] splitedContent = content.Split(seperator_1);
            // so the first element of splitedContent should be init, radio,or mobile.
            //the third element should be destination address and the fifth is message content.

            if (splitedContent[0] == "init")
            {
                //form.consoleBox.AppendText(Encoding.ASCII.GetString(dbBytes) + "\n");
                udpSend.BeginSend(dbBytes, dbBytes.Length,
                                  new IPEndPoint(IPAddress.Parse(clientIP), 11001),
                                  new AsyncCallback(sendCallback), clientIP);
            }
            else if (splitedContent[0] == "him")
            {
                writeConsole(string.Format("HIM group BroadCasting from {0}",clientIP ));
                DataTable HIM = form.dbConn.selectHIB().Tables["users"];
                string message = splitedContent[4];
                string[] phones = HIM.AsEnumerable().Select(r => r.Field<string>("phone")).ToArray<string>();
                string[] radio = HIM.AsEnumerable().Select(r => r.Field<string>("radio")).ToArray<string>();
                form.sendThroughRadio(radio, message);
                form.sendSMSwithThread(phones, message);
                byte[] feedBackToClient = Encoding.ASCII.GetBytes("HIMSending");
                udpSend.Send(feedBackToClient, feedBackToClient.Length, new IPEndPoint(IPAddress.Parse(clientIP), 11001));
            }
            else if (splitedContent[0] == "radio")
            {
                form.sendRadio(splitedContent[2], splitedContent[4]);
                string info = string.Format("{0} send radio to {1} \n", ep.ToString(), splitedContent[2]);
                writeConsole(info);
            }
            else if (splitedContent[0] == "mobile")
            {
                form.sendSMS(splitedContent[2], splitedContent[4]);
                string info = string.Format("{0} send mobile to {1} \n", ep.ToString(), splitedContent[2]);
                writeConsole(info);
            }
            else
            {
                udpReceive.BeginReceive(new AsyncCallback(receiveCallBack), null);
                form.consoleBox.AppendText(string.Format("receive an exception from {0} silde \n", ep.ToString()));
                return;
            }
            udpReceive.BeginReceive(new AsyncCallback(receiveCallBack), null);
        }

        private void sendCallback(IAsyncResult obj)
        {
            writeConsole("a new client_side joint" + "\n");
        }

        public void reshDBbyte()
        {
            dbBytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(form.dbConn.selectRow().Tables["users"]));
 
        }

        private byte[] dataTableConvertToByte(DataTable dbtable)
        {
            string str = JsonConvert.SerializeObject(dbtable);
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            return bytes;
        }
    }
}
