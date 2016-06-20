using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;


namespace MessageClientSide
{
    public partial class mainForm : Form
    {
        //private DataTable db;
        private UdpClient udpReceiver;
        private UdpClient udpSender;
        private int receivePort = 11001;
        private const int sendPort = 11002;
        private const int serverListenPort = 11000;
        private const string localIPString = "192.168.1.219";
        private const string serverIPString = "192.168.1.219";      
        private IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIPString), serverListenPort);
        public mainForm()
        {
            udpReceiver = new UdpClient(new IPEndPoint(IPAddress.Parse(localIPString),receivePort));
            udpSender = new UdpClient(new IPEndPoint(IPAddress.Parse(localIPString),sendPort));
            InitializeComponent();
        }
        private void mainForm_Load(object sender, EventArgs e)
        {          
            byte[] bytes = Encoding.ASCII.GetBytes("init>");
            udpSender.Send(bytes, bytes.Length,serverAddress);
            udpReceiver.BeginReceive(new AsyncCallback(receiveCallBack), null);
        }
        private void receiveCallBack(IAsyncResult obj)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any,0);
            byte[] data = udpReceiver.EndReceive(obj, ref ep);
            string jsonstring = Encoding.ASCII.GetString(data, 0, data.Length);
            messageRichBox.Text = jsonstring;
            this.dataGridView.DataSource = (DataTable)JsonConvert.DeserializeObject<DataTable>(jsonstring);
            consoleTextbox.Text = "recieving table";
           
        }

        private void sendBtt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                string udpPack = string.Format("radio>to:{0};msg:{1};",row.Cells[3],messageRichBox.Text);
                byte[] bytes = Encoding.ASCII.GetBytes(udpPack);
                udpSender.BeginSend(bytes, bytes.Length, serverAddress,new AsyncCallback(sendCallBack),null);
            }        
        }

       

        private void hibBtt_Click(object sender, EventArgs e)
        {
        
           foreach (DataGridViewRow i in dataGridView.Rows)
           {
                if (i.Cells[4].ToString() == "1")
                {
                    string udpPack = string.Format("radio>to:{0};msg:{1};", i.Cells[3], messageRichBox.Text);
                    byte[] bytes = Encoding.ASCII.GetBytes(udpPack);
                    //udpSender.BeginSend(bytes, bytes.Length, serverAddress, new AsyncCallback(sendCallBack), null);
                    messageRichBox.AppendText(i.Cells[4].ToString() + "\n");

                }
               
           }
        }

        private void sendCallBack(IAsyncResult iar)
        {
            if (udpSender.EndSend(iar) > 0)
                MessageBox.Show("message send");
        }
    }

}
