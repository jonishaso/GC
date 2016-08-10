using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ClientApi;
using ClientApi.Code;
using ClientApi.Server;
using Common;
using Common.Calls;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;

namespace SmartPTT_API
{
    public partial class MainForm : Form
    {
        #region Properties

        DateTime expiration = new DateTime(2016, 2, 17);

        private Dictionary<int, Msu> msuList;
        private BaseMcsProxy callMcs;
        private BaseRsProxy rsProxy;

        private EmailWatcher emailWatcher;
        private FireAlarmWatcher fireWatcher;
        private AlertLogWatcher securityWatcher;

        private bool pttIsOn;
        private string receiveMsg = "No Message Received!";
        public StarGuestRequest aRequest = new StarGuestRequest();
        private StarGuestRequest Requested = new StarGuestRequest();
        private List<StarGuestRequest> collectionOfRequests = new List<StarGuestRequest>();
        private int controlStationID = 18874592; //Gold Coast: 18874592 WWSI: 17475776 

        public string returnAddress;
        public string radioAddress;
        public string subjectLine;
        public string requestText;
        //int controlStationId;

        #endregion Properties

        public MainForm()
        {
            InitializeComponent();
        }

        #region Form events
        private void Form1_Load(object sender, EventArgs e)
        {
            msuList = new Dictionary<int, Msu>();
            tbServerAddress.Text = Constants.Config.ServerIP;
            #region Original
            //tbServerAddress.Text = @"10.108.96.44:8888";
            //tbServerAddress.Text = @"192.168.1.10:8888";
            #endregion
            pttButton.BackColor = SystemColors.Control;
            labelInfo.Text = "";

            ClientDispatcher.Start(this.Handle);

            BaseRsProxy.Connected += BaseRsProxy_Connected;
            BaseRsProxy.Disconnected += BaseRsProxy_Disconnected;
            BaseRsProxy.McsConnected += BaseRsProxyOnMcsConnected;
            BaseRsProxy.McsDisconnected += BaseRsProxyOnMcsDisconnected;
            BaseRsProxy.McsCall += BaseRsProxyOnMcsCall;
            BaseRsProxy.ReceiveTextMessage += BaseRsProxy_ReceiveTextMessage;

            openWatcher.Text = daysLeft();
            connectToRS();
            initializeWatchers();
        }

        //NOTE: Master Repeater ARS ID: 8001
        private void BaseRsProxy_ReceiveTextMessage(object sender, ReceiveTextMessageEventArgs e)
        {
            bool toDelete = false;
            string instruction = e.message;
            string eventID = getEventCode(instruction);

            string requestCmd = getRequestCode(instruction);
            string radioID = e.sourceIP.ToString();
            int itemToDelete = 0;

            logAction("Message deteced from radio: " + radioID + "." + " Message: " + instruction);


            foreach (var request in collectionOfRequests)
            {
                if (requestCmd.Contains("2"))
                {
                    toDelete = true;
                }

                logAction(string.Format("[DEBUG] radioID :{0}, requestRadioID: {1}, eventID: {2}, requestEventID: {3}",
                    radioID,
                    request.radioAddress,
                    eventID,
                    request.eventID));

                if (radioID.Contains(request.radioAddress) && eventID.Contains(request.eventID))
                {
                    using (var send = new StarGuestReply(this))
                    {
                        send.replyToStarGuest
                            (request.returnAddress,
                            request.subjectLine,
                            requestCmd + " " +
                            request.request,
                            "alertwwsi@gmail.com");
                    }
                    logAction("Sent to: " + request.returnAddress + ". Subject Line: " + request.subjectLine + ". Contents of Email: " + requestCmd + " " + request.request);
                }
                itemToDelete++;
            }

            if (toDelete)
            {
                collectionOfRequests.RemoveAt(itemToDelete);
            }

        }

        private string getRequestCode(string s)
        {
            #region Original
            //return s.Substring(0, 1);
            #endregion
            return s[s.Length - 1].ToString();
        }

        private string getEventCode(string s)
        {

            #region Original
            //return s.Substring(1);
            #endregion

            string result = string.Empty;

            #region wrong translation 30-06
            //Assuming the reply format is always similiar to 
            //"Event-81; LOC-Reception Desk; Work Order; Magnetic Door Holder; Test message from jeff;"

            //
            //if (s.IndexOf(';') > 0)
            //{
            //    result = s.Substring(0, s.IndexOf(';'));
            //    result = result.Replace("Event-", "");
            //}
            #endregion

            #region New Trasnlation 02-07
            //Assuming the reply format is always similiar to "812", 
            //first "n" character is the event id, the last one is the responses
            //Example: 1011, the event id is 101, response is 1
            //         812,  the event id is 81, response is 2
            //         853,  the event id is 85, response is 3

            //response code
            //1 - pending
            //2 - close
            //3 - acknowledge 

            result = s.Substring(0, s.Length - 1);

            #endregion

            return result;
        }

        private void connectToRS()
        {
            if (!string.IsNullOrEmpty(connectingRs) && (connectingRs == tbServerAddress.Text.Trim()))
                return;

            connectingRs = tbServerAddress.Text.Trim();

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
                labelInfo.Text = ex.Message;
                return;
            }

            labelInfo.Text = @"Connecting...";
        }

        private void initializeSQL()
        {
            SQLMonitor SQLBroker = new SQLMonitor(this);
            SQLBroker.Show();
        }

        private void initializeWatchers()
        {

            fireWatcher = new FireAlarmWatcher(this);
            emailWatcher = new EmailWatcher(this);
            securityWatcher = new AlertLogWatcher(this);
            securityWatcher.Show();
            logAction("initializeWatchers");
        }

        private string daysLeft()
        {
            DateTime today = DateTime.Now;
            TimeSpan daysLeft = expiration - today;
            int days = Convert.ToInt32(daysLeft.TotalDays) + 1;
            return days + " days left until expiration.";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClientDispatcher.Stop();
        }
        #endregion Form events

        #region Interface element events
        private void treeRadioObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            labelSelectInfo.Text = e.Node == null ? "" : e.Node.Text;
        }

        private string connectingRs;

        private void butConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(connectingRs) && (connectingRs == tbServerAddress.Text.Trim()))
                return;

            connectingRs = tbServerAddress.Text.Trim();

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
                BaseRsProxy rsProxy = new BaseRsProxy(RS_ID, "Radioserver", connectingRs, "", "", "", "", "");
                rsProxy.MsuPresenceChange += BaseRsProxyOnMsuPresenceChange;
                ClientDispatcher.ServerManager.AddServer(rsProxy);
            }
            catch (Exception ex)
            {
                connectingRs = "";
                labelInfo.Text = ex.Message;
                return;
            }

            labelInfo.Text = @"Connecting...";
        }

        private void checkServer()
        {
            BaseRsProxy ourRadioserver = ClientDispatcher.ServerManager[1];
            if (ourRadioserver != null)
            {
                MessageBox.Show("It works");
            }
            if (ourRadioserver.IsConnected)
            {
                MessageBox.Show("This also works");
            }
        }

        private void pttButton_Click(object sender, EventArgs e)
        {

            object callingObject;
            BaseMcsProxy mcsProxy;
            if (callMcs == null)
            {
                if (treeRadioObjects.SelectedNode == null)
                    return;
                callingObject = treeRadioObjects.SelectedNode.Tag;
                mcsProxy = ClientDispatcher.GetMcs(callingObject);
                if (mcsProxy == null)
                    return;
            }
            else
            {
                mcsProxy = callMcs;
                callingObject = mcsProxy.CalledAbonent;
            }

            ActiveCall call = ClientDispatcher.CallingController.GetActiveCall(mcsProxy, callingObject);
            if (!pttIsOn)
            {
                pttIsOn = true;
                ClientDispatcher.CallingController.StartPtt(mcsProxy, callingObject);
                if (call == null)
                    pttButton.BackColor = Color.Moccasin;
            }
            else
            {
                pttIsOn = false;
                ClientDispatcher.CallingController.StopPtt(mcsProxy, callingObject);
                if (call == null)
                    pttButton.BackColor = SystemColors.Control;
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

        private void BaseRsProxyOnMcsCall(object sender, McsCallEventArgs e)
        {
            if (labelInfo.InvokeRequired)
                treeRadioObjects.Invoke(new DelegateSetMcsState(SetMcsState), e.Mcs);
            else
                SetMcsState(e.Mcs);
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
            labelInfo.Text = rsProxy.Name + @" is connected";
            //initializeSQL();
            //initializeWatchers();
            #region Original
            //EmailWatcher anEmailWatcher = new EmailWatcher(this);
            #endregion

            foreach (BaseMcsProxy mcsProxy in rsProxy.BaseMcsList.Values.Where(mcsProxy => mcsProxy.IsConnected))
            {
                TreeNode mcsNode = new TreeNode { Name = mcsProxy.RsId + "_" + mcsProxy.Id, Text = mcsProxy.Name, Tag = mcsProxy };
                treeRadioObjects.Nodes.Add(mcsNode);
                mcsProxy.Call += McsProxyOnCall;
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

        private void McsProxyOnCall(object sender, CallEventArgs e)
        {
            BaseMcsProxy mcsProxy = sender as BaseMcsProxy;
            if (labelState.InvokeRequired)
                labelState.Invoke(new DelegateSetCallState(SetCallState), mcsProxy, e);
            else
                SetCallState(mcsProxy, e);
        }

        private void SetCallState(BaseMcsProxy mcsProxy, CallEventArgs e)
        {
            labelState.Text = e.callState.ToString();
        }

        private void ClearMcsList(BaseRsProxy rsProxy)
        {
            pttIsOn = false;
            labelInfo.Text = rsProxy.Name + @" is disconnected";
            string rsId = rsProxy.Id.ToString(CultureInfo.InvariantCulture) + "_";
            List<TreeNode> nodes = treeRadioObjects.Nodes.Cast<TreeNode>().Where(treeNode => treeNode.Name.StartsWith(rsId)).ToList();
            foreach (TreeNode treeNode in nodes)
                treeRadioObjects.Nodes.Remove(treeNode);
            labelSelectInfo.Text = "";
        }

        private void SetMcsState(BaseMcsProxy mcsProxy)
        {
            if (mcsProxy.ActiveCall == null)
            {
                pttIsOn = false;
                labelInfo.Text = "";
                pttButton.BackColor = SystemColors.Control;
                callMcs = null;
            }
            else
            {
                callMcs = mcsProxy;
                if (mcsProxy.RMode == RMode.Idle)
                {
                    pttButton.BackColor = Color.LightBlue;
                    labelInfo.Text = mcsProxy.ActiveCall.Abonent.ToString();
                }
                else
                {
                    switch (mcsProxy.ActiveCall.RMode)
                    {
                        case RMode.Rx:
                            pttButton.BackColor = Color.LightGreen;
                            labelInfo.Text = @"Incoming " + mcsProxy.ActiveCall.Abonent;
                            break;
                        case RMode.Tx:
                            pttButton.BackColor = Color.Orange;
                            labelInfo.Text = @"Outgoing " + mcsProxy.ActiveCall.Abonent;
                            break;
                    }
                }
            }
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
            if (labelInfo.Text.Contains(" connected"))
                labelInfo.Text = string.Empty;
            labelInfo.Text += rsProxy.Name + e.mcs.Name + @" is disconnected" + "\n";
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

        #region Settings
        private void soundSettings_Click(object sender, EventArgs e)
        {
            SoundSettingForm soundSettingForm = new SoundSettingForm();
            soundSettingForm.ShowDialog();
        }
        #endregion Settings

        private void button1_Click(object sender, EventArgs e)
        {
            BaseRsProxy radioServer = ClientDispatcher.ServerManager[1];

            foreach (KeyValuePair<int, BaseMcsProxy> element in radioServer.BaseMcsList)
            {
                MessageBox.Show("" + element.ToString());
            }

            if (radioServer != null && radioServer.IsConnected)
            {
                try
                {
                    //Radio Control Station 1 ID: 17475776
                    IPAddress anIPAddress = IPAddress.Parse("12.162");
                    radioServer.SendTextMessage(17826016, anIPAddress, SUDisplayType.Internal, "API TEST 123");
                    MessageBox.Show("Sent");

                    //Upstairs
                    /*
                    IPAddress aIPAddress = IPAddress.Parse("12.161");
                    radioServer.SendTextMessage(17826016, aIPAddress, SUDisplayType.Internal, "API TEST 123");
                    MessageBox.Show("Sent");
                    */
                }
                catch
                {
                    MessageBox.Show("Failed");
                }
            }
            else
            {
                MessageBox.Show("Failed to connect or send!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlertLogWatcher openWatcher = new AlertLogWatcher(this);
            openWatcher.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BaseRsProxy radioServer = ClientDispatcher.ServerManager[1];

            foreach (KeyValuePair<int, BaseMcsProxy> element in radioServer.BaseMcsList)
            {
                MessageBox.Show("" + element.ToString());
            }

            if (radioServer != null && radioServer.IsConnected)
            {
                try
                {
                    //Radio Control Station 1 ID: 17475776
                    //19923168
                    //Gold Coast: 18874592
                    IPAddress anIPAddress = IPAddress.Parse("12.156");
                    radioServer.SendTextMessage(controlStationID, anIPAddress, SUDisplayType.Internal, "Test Message sent from Computer.");
                    MessageBox.Show("Sent");

                    //Upstairs
                    /*
                    IPAddress aIPAddress = IPAddress.Parse("12.161");
                    radioServer.SendTextMessage(17826016, aIPAddress, SUDisplayType.Internal, "API TEST 123");
                    MessageBox.Show("Sent");
                    */
                }
                catch
                {
                    MessageBox.Show("Failed");
                }
            }
            else
            {
                MessageBox.Show("Failed to connect or send!");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            #region Original
            //EmailWatcher starGuest = new EmailWatcher(this);
            //FireAlarmWatcher fireAlarm = new FireAlarmWatcher(this);
            //AlertLogWatcher securityAlarm = new AlertLogWatcher(this);
            #endregion
            SQLMonitor initSQL = new SQLMonitor(this);
            initSQL.Show();
            //securityAlarm.Show();
        }

        public void sendToRadio(IPAddress radioIP, string msg)
        {
            //BaseRsProxy ALERTradioServer = ClientDispatcher.ServerManager[1];
            //if (ALERTradioServer != null && ALERTradioServer.IsConnected)
            //{ 
            try
            {
                //GOLD COAST: 18874592 //WWSI: 17475776
                //ALERTradioServer.SendTextMessage(controlStationID, radioIP, SUDisplayType.Internal, msg);//Changes made by gordon
                rsProxy.SendTextMessage(controlStationID, radioIP, SUDisplayType.Internal, msg);
                logAction("Message Successfully sent to: " + radioIP.ToString());
            }
            catch
            {
                logAction("Failed to send to Radio \"" + radioIP.ToString() + "\"");
            }
            // }
            //else
            // {
            //     logAction("Server down. Disconnected at: " + DateTime.Now.ToString());
            // }
        }

        public void logAction(string msg)
        {
            try
            {
                Thread.Sleep(1000);
                string logPath = @"C:\WWSI\Logs\WWSI Application Log.txt";
                //WWSI - LAPTOP
                //string logPath = @"C:\Alert Log Backup\EmailLog.txt";
                using (StreamWriter writer = File.AppendText(logPath))
                {
                    writer.WriteLine("[" + DateTime.Now.ToString() + "]: " + msg);
                }
            }
            catch
            {

            }

        }

        public void setStarGuestReply(string ret, string ID, string subject, string body)
        {
            returnAddress = ret;
            ID = radioAddress;
            subjectLine = subject;
            requestText = body;
        }

        public void replyStarGuest(string eventID, string ret, string ID, string subject, string body)
        {
            StarGuestRequest OCPRequest = new StarGuestRequest();

            OCPRequest.eventID = eventID;
            OCPRequest.returnAddress = ret;
            OCPRequest.radioAddress = ID;
            OCPRequest.subjectLine = subject;
            OCPRequest.request = body;

            collectionOfRequests.Add(OCPRequest);


            logAction(string.Format("replyStarGuest: OCPRequest Added, eventID: {0}, returnAddress: {1}, radioAddress: {2}, subject: {3}, request: {4}",
                eventID,
                ret,
                ID,
                subject,
                body));
        }

        public StarGuestRequest aNewRequest
        {
            get
            {
                return aRequest;
            }
            set
            {
                aRequest = value;
                collectionOfRequests.Add(aRequest);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AdminLogin anAdminLogin = new AdminLogin();
            anAdminLogin.Show();
        }
    }
}
