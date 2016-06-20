using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.Data;

namespace UDPserver
{
    
   

    public class udpStatus
    {
        public UdpClient udpClient;
        public IPEndPoint ipEndPoint;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
        public const int counter = 0;

    }
    public class UDP
    {
        private IPEndPoint ipEndPoint = null;
        private IPEndPoint remotePoint = null;

        private UdpClient udpSend = null;
        private UdpClient udpReceive = null;

        private const int listenPort = 1100;
        private const int remotePort = 1101;

        private udpStatus receiveStatus = null;
        private udpStatus sendStatus = null;

        private ManualResetEvent sendDone = new ManualResetEvent(false);
        private ManualResetEvent receiveDone = new ManualResetEvent(false);

        public UDP()
        {
            ipEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
            remotePoint = new IPEndPoint(Dns.GetHostAddresses(Dns.GetHostName())[0],remotePort);
            udpReceive = new UdpClient(ipEndPoint);
            udpSend = new UdpClient();

            receiveStatus = new udpStatus();
            receiveStatus.udpClient = udpReceive;
            receiveStatus.ipEndPoint = ipEndPoint;

            sendStatus = new udpStatus();
            sendStatus.udpClient = udpSend;
            sendStatus.ipEndPoint = remotePoint;
        }

        public void ReceiveMsg()
        {
            while (true)
            {
                lock (this)
                {
                    IAsyncResult iar = udpReceive.BeginReceive(new AsyncCallback(receiveMsgCallBack), receiveStatus);
                    receiveDone.WaitOne();
                    Thread.Sleep(100);
                }
            }
        }

        private void receiveMsgCallBack(IAsyncResult iar)
        {
            udpStatus receiveStatus = iar.AsyncState as udpStatus;
            if (iar.IsCompleted)
            {

            }
        }
    }

    public class UDPListener
    {
        private const int listenPort = 11000;
        public UdpClient client;
        public UdpClient client_sender;
        
        //public static void StartListener()
        //{
        //    bool done = false;

        //    UdpClient listener = new UdpClient(listenPort);
        //    IPEndPoint groupEP = new IPEndPoint(192168123, 45000);

        //    try
        //    {
        //        while (!done)
        //        {
        //            Console.WriteLine("Waiting for broadcast");
        //            byte[] bytes = listener.Receive(ref groupEP);

        //            Console.WriteLine("Received broadcast from {0} :\n {1}\n",
        //                groupEP.ToString(),
        //                Encoding.ASCII.GetString(bytes, 0, bytes.Length));
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.ToString());
        //    }
        //    finally
        //    {
        //        listener.Close();
        //    }
        //}

        public UDPListener()
        {
            //client = new UdpClient(11100);
            client_sender = new UdpClient();
            Console.WriteLine("star to listen MSG");
            //client.BeginReceive(new AsyncCallback(func), null);
            string str = JsonConvert.SerializeObject(this.getData());
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            client_sender.BeginSend(bytes,bytes.Length,new IPEndPoint(IPAddress.Parse("192.168.1.219"),11000),new AsyncCallback(func_1),null);
            while (true)
            {
                
            }
        }
        private void func_1(IAsyncResult obj)
        {
            Console.WriteLine("this is sending section {0}", client_sender.EndSend(obj));
        }
        private void func(IAsyncResult obj)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any,0);
            byte[] data = client.EndReceive(obj,ref ep);
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));
            Console.WriteLine(ep.ToString());
            client.BeginReceive(new AsyncCallback(func), null);
        }
        public DataTable getData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserId", typeof(Int32));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Education", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            dt.Rows.Add(1, "Satinder Singh", "Bsc Com Sci", "Mumbai");
            dt.Rows.Add(2, "Amit Sarna", "Mstr Com Sci", "Mumbai");
            dt.Rows.Add(3, "Andrea Ely", "Bsc Bio-Chemistry", "Queensland");
            dt.Rows.Add(4, "Leslie Mac", "MSC", "Town-ville");
            dt.Rows.Add(5, "Vaibhav Adhyapak", "MBA", "New Delhi");
            dt.Rows.Add(6, "Johny Dave", "MCA", "Texas");
            return dt;
        }

        public static int Main()
        {
            //Console.WriteLine(Dns.GetHostName().ToString());
            //foreach (IPAddress ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            //    Console.WriteLine(ip);
            UDPListener udpl = new UDPListener();

            return 0;
        }

    }
}
