using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ClientApi;
using ClientApi.Code;
using ClientApi.Server;
using Common;
using Common.Calls;
using System.Data;
using System.Net;
using NetworkCommsDotNet;
using System.Text.RegularExpressions;




namespace SmartPTT_API
{
    public partial class MainForm : Form
    {
        #region Properties
       
        private Dictionary<int, Msu> msuList;
        private BaseRsProxy rsProxy;// Very Important, this if the readio server, cne be used directlly;

        sql dbConn;
        private SerialPort _serialPort;
        private delegate void SetTextCallBack(string text);
       
        
        string tempPort = null;
        private bool isBusy = false;
        private string connectingRs = @"192.168.1.10:8888"; //Server IP 
        private int controlStationID = 17475776; //Gold Coast: 18874592 WWSI: 17475776 
        private string GSM_Port = "COM6"; // GSM port setting; WWSI: "COM4", Gold Coast: "COM1", com6 at gc com5

        #endregion Properties
        
        public MainForm(sql conn)
        {
            dbConn = conn;
            InitializeComponent();                                       
        }       
        #region Form events
        private void Form1_Load(object sender, EventArgs e)
        {
            msuList = new Dictionary<int, Msu>();                                      
            ClientDispatcher.Start(this.Handle);
            BaseRsProxy.Connected += BaseRsProxy_Connected;
            BaseRsProxy.Disconnected += BaseRsProxy_Disconnected;
            BaseRsProxy.McsConnected += BaseRsProxyOnMcsConnected;
            BaseRsProxy.McsDisconnected += BaseRsProxyOnMcsDisconnected;
            dataGridView.DataSource = dbConn.selectRow().Tables["users"];
            connectRadioServer();          
            sqlMonitor monitor = new sqlMonitor(this);// enable to watch changes occuring on db for communicatation popurse
        }        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClientDispatcher.Stop();
        }
        #endregion Form events
        #region Interface element events

        private void treeRadioObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //labelSelectInfo.Text = e.Node == null ? "" : e.Node.Text;
        }
        private void checkServer()
        {
            BaseRsProxy ourRadioserver = ClientDispatcher.ServerManager[1];
            if (ourRadioserver != null)
            {
                MessageBox.Show("Found a server");
            }
            if (ourRadioserver.IsConnected)
            {
                MessageBox.Show(string.Format("{0}",ourRadioserver.Address));
            }
        }
        
        #endregion Interface element events
        #region API events
        private delegate void DelegateSetMcsList(BaseRsProxy rsProxy, RsConnectEventArgs e);
        private delegate void DelegateClearMcsList(BaseRsProxy rsProxy);
        private delegate void DelegateSetMcsState(BaseMcsProxy mcsProxy);
        private delegate void DelegateMcsConnect(BaseRsProxy rsProxy, McsConnectedEventArgs e);
        private delegate void DelegateMcsDisonnect(BaseRsProxy rsProxy, McsEventArgs e);
        private delegate void DelegateMsuPresenceChange(BaseRsProxy rsProxy, MsuPresenceChangeEventArgs e);
        private delegate void DelegateSetCallState(BaseMcsProxy mcsProxy, CallEventArgs e);
        //private delegate void DelegateReceiveText(BaseRsProxy rsProxy, ReceiveTextMessageEventArgs e);

        private void BaseRsProxy_Connected(object sender, RsConnectEventArgs e)
        {
            BaseRsProxy rsProxy = sender as BaseRsProxy;
            if (rsProxy == null)
                return;
            connectingRs = "";
            if (treeRadioObjects.InvokeRequired)
                treeRadioObjects.Invoke(new DelegateSetMcsList(SetMcsList), rsProxy, e);
            else
                SetMcsList(rsProxy, e);
        }

        private void BaseRsProxy_Disconnected(object sender, EventArgs e)
        {
            BaseRsProxy rsProxy = sender as BaseRsProxy;
            if (rsProxy == null)
                return;
            if (treeRadioObjects.InvokeRequired)
                treeRadioObjects.Invoke(new DelegateClearMcsList(ClearMcsList), rsProxy);
            else
                ClearMcsList(rsProxy);
        }

        private void BaseRsProxyOnMcsConnected(object sender, McsConnectedEventArgs e)
        {
            BaseRsProxy rsProxy = sender as BaseRsProxy;
            if (rsProxy == null)
                return;
            if (treeRadioObjects.InvokeRequired)
                treeRadioObjects.Invoke(new DelegateMcsConnect(McsConnect), rsProxy, e);
            else
                McsConnect(rsProxy, e);
        }

        private void BaseRsProxyOnMcsDisconnected(object sender, McsEventArgs e)
        {
            BaseRsProxy rsProxy = sender as BaseRsProxy;
            if (rsProxy == null)
                return;
            if (treeRadioObjects.InvokeRequired)
                treeRadioObjects.Invoke(new DelegateMcsDisonnect(McsDisconnect), rsProxy, e);
            else
                McsDisconnect(rsProxy, e);
        }

        private void BaseRsProxyOnMsuPresenceChange(object sender, MsuPresenceChangeEventArgs e)
        {
            BaseRsProxy rsProxy = sender as BaseRsProxy;
            if (rsProxy == null)
                return;
            if (treeRadioObjects.InvokeRequired)
                treeRadioObjects.Invoke(new DelegateMsuPresenceChange(MsuPresenceChange), rsProxy, e);
            else
                MsuPresenceChange(rsProxy, e);

            
        }

        private void SetMcsList(BaseRsProxy rsProxy, RsConnectEventArgs e)
        {
            ClearMcsList(rsProxy);
            consoleBox.AppendText("Active SQL listening \n");
            consoleBox.AppendText(rsProxy.Name + @" is connected"+'\n');
            foreach (BaseMcsProxy mcsProxy in rsProxy.BaseMcsList.Values.Where(mcsProxy => mcsProxy.IsConnected))
            {
                TreeNode mcsNode = new TreeNode { Name = mcsProxy.RsId + "_" + mcsProxy.Id, Text = mcsProxy.Name, Tag = mcsProxy };
                treeRadioObjects.Nodes.Add(mcsNode);
                //mcsProxy.Call += McsProxyOnCall;
                mcsProxy.GroupInfoList.ForEach(group => mcsNode.Nodes.Add(new TreeNode { Text = @group.Name, Tag = @group }));
            }
            foreach (Msu msu in e.Subscribers)
            {
                if (!msuList.ContainsKey(msu.Id))
                    msuList.Add(msu.Id, msu);
                BaseMcsProxy mcs = ClientDispatcher.GetMcs(msu);
                if (!msu.IsOnline)
                    continue;
                if (mcs == null || !mcs.IsConnected)
                    msu.Presence.State = MsuPresenceState.Offline;
                else
                {
                    TreeNode[] nodes = treeRadioObjects.Nodes.Find(mcs.RsId + "_" + mcs.Id, false);
                    if (nodes.Length > 0)
                        nodes[0].Nodes.Add(new TreeNode { Name = msu.Id.ToString(CultureInfo.InvariantCulture), Text = msu.ToString(), Tag = msu, ForeColor = Color.Blue });
                }
            }
            treeRadioObjects.ExpandAll();
        }
        

        private void ClearMcsList(BaseRsProxy rsProxy)
        {            
            consoleBox.AppendText(rsProxy.Name + @" is disconnected"+'\n');
            string rsId = rsProxy.Id.ToString(CultureInfo.InvariantCulture) + "_";
            List<TreeNode> nodes = treeRadioObjects.Nodes.Cast<TreeNode>().Where(treeNode => treeNode.Name.StartsWith(rsId)).ToList();
            foreach (TreeNode treeNode in nodes)
                treeRadioObjects.Nodes.Remove(treeNode);
            
        }


        private void McsConnect(BaseRsProxy rsProxy, McsConnectedEventArgs e)
        {
            TreeNode mcsNode = new TreeNode { Name = e.mcs.RsId + "_" + e.mcs.Id, Text = e.mcs.Name, Tag = e.mcs };
            treeRadioObjects.Nodes.Add(mcsNode);
            e.mcs.GroupInfoList.ForEach(group => mcsNode.Nodes.Add(new TreeNode { Text = group.Name, Tag = group }));

            foreach (Msu msu in e.msuList)
            {
                if (!msuList.ContainsKey(msu.Id))
                    msuList.Add(msu.Id, msu);
                BaseMcsProxy mcs = ClientDispatcher.GetMcs(msu);
                if (!msu.IsOnline)
                    continue;
                if (mcs == null || !mcs.IsConnected)
                    msu.Presence.State = MsuPresenceState.Offline;
                else
                {
                    TreeNode[] nodes = treeRadioObjects.Nodes.Find(mcs.RsId + "_" + mcs.Id, false);
                    if (nodes.Length > 0)
                        nodes[0].Nodes.Add(new TreeNode { Name = msu.Id.ToString(CultureInfo.InvariantCulture), Text = msu.ToString(), Tag = msu, ForeColor = Color.Blue });
                }
            }
            mcsNode.ExpandAll();
        }

        private void McsDisconnect(BaseRsProxy rsProxy, McsEventArgs e)
        {
            if (consoleBox.Text.Contains(" connected"))
                consoleBox.Text = string.Empty;
            consoleBox.Text += rsProxy.Name + e.mcs.Name + @" is disconnected" + "\n";
            TreeNode[] nodes = treeRadioObjects.Nodes.Find(e.mcs.RsId + "_" + e.mcs.Id, false);
            if (nodes.Length > 0)
                treeRadioObjects.Nodes.Remove(nodes[0]);
        }

        private void MsuPresenceChange(BaseRsProxy rsProxy, MsuPresenceChangeEventArgs e)
        {
            Msu msu;
            BaseMcsProxy oldMcs = null;
            BaseMcsProxy newMcs = rsProxy.BaseMcsList[e.McsId];
            MsuPresence presence = new MsuPresence();
            if (msuList.ContainsKey(e.SrcMsuId))
            {
                msu = msuList[e.SrcMsuId];
                oldMcs = ClientDispatcher.GetMcs(msu.Presence.Site.RsId, msu.Presence.Site.McsId);
                presence.Site = newMcs == null
                    ? presence.Site = new MsuPresenceSite(rsProxy.Id, msu.Presence.Site.McsId, msu.Presence.Site.McsChannel)
                    : new MsuPresenceSite(rsProxy.Id, newMcs.Id, newMcs.Channel.Clone());
                msu.Presence = presence;
            }
            else
            {
                if (newMcs == null)
                    return;
                presence.Site = new MsuPresenceSite(rsProxy.Id, newMcs.Id, newMcs.Channel.Clone());
                msu = new Msu(e.SrcMsuId) { Presence = presence };
                msuList.Add(msu.Id, msu);
            }

            msu.Presence.State = newMcs == null || !newMcs.IsConnected ? MsuPresenceState.Offline : e.MsuState;

            if (!Equals(oldMcs, newMcs))
            {
                if (oldMcs != null)
                {
                    TreeNode[] nodes = treeRadioObjects.Nodes.Find(oldMcs.RsId + "_" + oldMcs.Id, false);
                    if (nodes.Length > 0)
                    {
                        TreeNode[] msuNodes = nodes[0].Nodes.Find(msu.Id.ToString(CultureInfo.InvariantCulture), false);
                        if (msuNodes.Length > 0)
                            nodes[0].Nodes.Remove(msuNodes[0]);
                    }
                }
                if (newMcs != null && msu.IsOnline)
                {
                    TreeNode[] nodes = treeRadioObjects.Nodes.Find(newMcs.RsId + "_" + newMcs.Id, false);
                    if (nodes.Length > 0)
                        nodes[0].Nodes.Add(new TreeNode { Name = msu.Id.ToString(CultureInfo.InvariantCulture), Text = msu.ToString(), Tag = msu, ForeColor = Color.Blue });
                }
            }
            else if (oldMcs != null)
            {
                TreeNode[] nodes = treeRadioObjects.Nodes.Find(oldMcs.RsId + "_" + oldMcs.Id, false);
                if (nodes.Length > 0)
                {
                    TreeNode[] msuNodes = nodes[0].Nodes.Find(msu.Id.ToString(CultureInfo.InvariantCulture), false);
                    if (msu.IsOnline && msuNodes.Length == 0)
                        nodes[0].Nodes.Add(new TreeNode { Name = msu.Id.ToString(CultureInfo.InvariantCulture), Text = msu.ToString(), Tag = msu, ForeColor = Color.Blue });
                    else if (!msu.IsOnline && msuNodes.Length > 0)
                        nodes[0].Nodes.Remove(msuNodes[0]);
                }
            }
        }
        #endregion API events
      
        //Active a function to connect Radio Server
        private void connectRadioServer()
        {
            try
            {
                BaseRsProxy[] rsList = ClientDispatcher.ServerManager.GetRoList();
                if (rsList.Length > 0)
                {
                    for (int i = 0; i < rsList.Length; i++)
                    {
                        rsList[i].MsuPresenceChange -= BaseRsProxyOnMsuPresenceChange;
                    }
                    ClientDispatcher.ServerManager.RemoveAll();
                }
                const int RS_ID = 1;
                rsProxy = new BaseRsProxy(RS_ID, "Radioserver", connectingRs, "", "", "", "", "");
                rsProxy.MsuPresenceChange += BaseRsProxyOnMsuPresenceChange;
                ClientDispatcher.ServerManager.AddServer(rsProxy);
            }
            catch (Exception ex)
            {
                connectingRs = "";
                consoleBox.AppendText(ex.Message);
                return;
            }
            consoleBox.AppendText(@"Connecting..." + '\n');
        }
        //Sending message through GSM - you have to use AT command to control GSM
        //Note: You have to make sure you have a correct COM port and Bauld Rate.
        public void sendSMS(string message, string number)
        {
            _serialPort = new SerialPort(GSM_Port, 115200);
            Thread.Sleep(100);
            _serialPort.Open();
            Thread.Sleep(100);
            _serialPort.Write("AT+CMGF=1\r");
            Thread.Sleep(100);
            _serialPort.Write("AT+CMGS=\"" + number + "\"\r\n");
            Thread.Sleep(100);
            _serialPort.Write(message + "\x1A");
            Thread.Sleep(300);
            //MessageBox.Show("Sent: \"" + message + "\" to mobile number: " + number);
            //consoleBox.AppendText("Sent: \"" + message + "\" to mobile number: " + number + '\n');
            setTex("Sent: \"" + message + "\" to mobile number: " + number + '\n');
            Thread.Sleep(100);
            //_serialPort.DiscardInBuffer();
            //Thread.Sleep(100);
            //_serialPort.DiscardOutBuffer();
            //Thread.Sleep(100);
            _serialPort.Dispose();
            Thread.Sleep(100);
            _serialPort.Close();
            Thread.Sleep(100);            

        }
        public void sendRadio(string radio, string message)
        {
            IPAddress anIPAddress = IPAddress.Parse(radio);
            rsProxy.SendTextMessage(controlStationID, anIPAddress, SUDisplayType.Internal, message);
            setTex("Sending message to " + radio);
        }
        //An important function to handle messages come from different thread
        //To know deep, check MSDN InvokeRequired function
        public void setTex(string text)
        {
            if (this.consoleBox.InvokeRequired)
            {
                SetTextCallBack d = new SetTextCallBack(setTex);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.consoleBox.AppendText(text + '\n');
            }
        }
        //If Check boxes in user list are checked, send message to those users through mobile

        // send message by mobile, this func will be call when sendAndHib.form.senBtt_clicked
        private void sendThroughMobile(string[] contactInfo, string Message)
        {           
            foreach (string number in contactInfo)
            {
                sendSMS(Message, number);
                Thread.Sleep(1500);                  //The idle time can be set 620ms by using FX100
            }
        }
        // send message by radio, this func will be called when sendAndHib.form.sendBtt_clicked 
        private void sendThroughRadio(string[] contactInfo, string Message)
        {

            if (rsProxy != null && rsProxy.IsConnected)
            {
                foreach (String radio in contactInfo)                
                    sendRadio(radio, Message);                                
            }
            else
            {
                MessageBox.Show("Failed to connect or send! Check radio server");
            }
        }

        private void sendThroughBoth(string[] radio, string[] phone, string Message)
        {
            sendThroughMobile(phone, Message);
            sendThroughRadio(radio, Message);
        }

        private void addBtt_Click(object sender, EventArgs e)
        {
            addAndEditUserForm f2 = new addAndEditUserForm();
            f2.transEventAdding += dbConn.insertRow;
            f2.Show();
        }

        private void deleteBtt_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dataGridView.SelectedRows)
            {
                dbConn.deleteRow(Int32.Parse(i.Cells[0].Value.ToString()));
            }
            dataGridView.DataSource = dbConn.selectRow().Tables["users"];
        }

        private void freshBtt_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = dbConn.selectRow().Tables["users"];
        }

        private void editBtt_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int ID = Int32.Parse(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
                string username = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                string userphone = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                string userradio = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
                bool userhib = Int32.Parse(dataGridView.SelectedRows[0].Cells[4].Value.ToString()) == 1 ? true : false;
                addAndEditUserForm f2 = new addAndEditUserForm(new userDetial(username, userphone, userradio, userhib), ID);
                f2.transEventEditing += dbConn.updateRow;
                f2.Show();
            }
            else
            {
                MessageBox.Show("only one user's information can be edited eachtime");
            }
        }

        private void hibBtt_Click(object sender, EventArgs e)
        {
            sendAndHibForm f3 = new sendAndHibForm(dbConn.selectHIB().Tables["users"]);
            f3.Show();
        }

        private void MessageBtt_Click(object sender, EventArgs e)
        {
            DataTable newTable = new DataTable();     
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                newTable.Columns.Add(col.HeaderText);
            }
            for(int i= 0; i < dataGridView.SelectedRows.Count; i++)
            {
                newTable.Rows.Add();
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                    newTable.Rows[i][j] = dataGridView.SelectedRows[i].Cells[j].Value;
            }
            sendAndHibForm f3 = new sendAndHibForm(newTable);
            f3.SendByRadioEvent += sendThroughRadio;
            f3.SendByMobileEvent += sendThroughMobile;
            f3.sendByBothEvent += sendThroughBoth;
            f3.Show();
        }
    }
}
