using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SmartPTT_API
{
    public partial class SQLMonitor : Form
    {
        private int changeCount = 0;
        MainForm parentForm;

        //private string connectionString = @"Data Source=AP00372RD1\SMGCAlert;Initial Catalog=Clients;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private string connectionString = string.Format(@"Data Source={0}\{1};Initial Catalog={2};Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
            "AP00372RD1", "SMGCAlert", "Clients");


        private const string tableName = "Inventory";
        private const string statusMessage = "{0} changes have occurred.";
        private string[] nameArray;
        //private string connectionString = @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Clients;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private DataSet dataToWatch = null;
        private SqlConnection connection = null;
        private SqlCommand command = null;

        public SQLMonitor(MainForm aForm)
        {
            InitializeComponent();
            parentForm = aForm;
            radioSend();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CanRequestNotifications();
        }

        public void formatConnString(string hn, string s, string pn, string uid, string p)
        {
            connectionString = string.Format(@"Data Source={0}\{1}, {2};Initial Catalog=Clients;User ID={3};Password={4}", hn, s, pn, uid, p);
        }

        private bool CanRequestNotifications()
        {

            try
            {
                SqlClientPermission perm =
                    new SqlClientPermission(
                    PermissionState.Unrestricted);

                perm.Demand();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetConnectionString()
        {
            //return @"server=192.168.28.12\SQLExpress;Database=practicedb;Trusted_Connection=false;User Id=sa;Password=Odnalor168";
            //return @"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            //return @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AlertProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //return @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Clients;Integrated Security=False;User ID=sa;Password=wired&wireless;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //return @"Data Source=WWSI-PC\SQLEXPRESSWWSI, 1433;Initial Catalog=Clients;User ID=sa;Password=sqlwwsi123";
            return @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Clients;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public bool SQLCheckConn()
        {
            try
            {
                int retOne;
                string SQLKey = "SELECT 1";
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(SQLKey, con))
                {
                    con.Open();
                    retOne = (int)command.ExecuteScalar();
                }
                return retOne == 1;
            }
            catch
            {
                return false;
            }
        }

        private string GetSQL()
        {
            return "SELECT [radioID], [message], [unread] FROM [dbo].[radiomessenger] WHERE [unread] = '1'";
        }

        //Fires event on change
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;

            if (i.InvokeRequired)
            {
                OnChangeEventHandler tempDelegate = new OnChangeEventHandler(dependency_OnChange);

                object[] args = { sender, e };

                i.BeginInvoke(tempDelegate, args);

                return;
            }

            SqlDependency dependency = (SqlDependency)sender;

            dependency.OnChange -= dependency_OnChange;

            ++changeCount;

            //Fire Event
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(GetSQL(), connection))
                {
                    connection.Open();
                    List<string> ipList = new List<string>();
                    List<string> messageList = new List<string>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader["radioID"].ToString();
                            string msg = reader["Message"].ToString();
                            ipList.Add(id);
                            messageList.Add(msg);
                        }
                        sendToRadio(ipList, messageList);
                    }
                }
            }
            finally
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    setReadMsg(connection);
                }
            }

            GetData();
        }

        private void sendToRadio(List<string> list, List<string> list2)
        {
            string[] nameArray = list.ToArray();
            string[] msgArray = list2.ToArray();
            for (int i = 0; i < nameArray.Length; i++)
            {
                IPAddress anIP = IPAddress.Parse(nameArray[i]);
                parentForm.sendToRadio(anIP, msgArray[i]);
            }

        }

        private void setReadMsg(SqlConnection conn)
        {
            string cmdRead = @"UPDATE [dbo].[radioMessenger] SET [unread] = '0'";
            SqlCommand cmd = new SqlCommand(cmdRead, conn);
            cmd.ExecuteNonQuery();
        }

        private void GetData()
        {
            dataToWatch.Clear();

            command.Notification = null;

            SqlDependency dependency =
                new SqlDependency(command);
            dependency.OnChange += new
                OnChangeEventHandler(dependency_OnChange);

            using (SqlDataAdapter adapter =
                new SqlDataAdapter(command))
            {
                adapter.Fill(dataToWatch, tableName);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            changeCount = 0;

            SqlDependency.Stop(connectionString);
            SqlDependency.Start(connectionString);

            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }

            if (command == null)
            {
                command = new SqlCommand(GetSQL(), connection);

                SqlParameter prm =
                    new SqlParameter("@Quantity", SqlDbType.Int);
                prm.Direction = ParameterDirection.Input;
                prm.DbType = DbType.Int32;
                prm.Value = 100;
                command.Parameters.Add(prm);
            }
            if (dataToWatch == null)
            {
                dataToWatch = new DataSet();
            }

            GetData();

        }

        //Initializes SQLDependency
        private void radioSend()
        {
            changeCount = 0;
            //label1.Text = String.Format(statusMessage, changeCount);

            // Remove any existing dependency connection, then create a new one.
            SqlDependency.Stop(connectionString);
            SqlDependency.Start(connectionString);

            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }

            if (command == null)
            {
                // GetSQL is a local procedure that returns
                // a paramaterized SQL string. You might want
                // to use a stored procedure in your application.
                command = new SqlCommand(GetSQL(), connection);

                SqlParameter prm =
                    new SqlParameter("@Quantity", SqlDbType.Int);
                prm.Direction = ParameterDirection.Input;
                prm.DbType = DbType.Int32;
                prm.Value = 100;
                command.Parameters.Add(prm);
            }
            if (dataToWatch == null)
            {
                dataToWatch = new DataSet();
            }

            GetData();

        }

        public void write(string s)
        {
            DateTime now = DateTime.Now;
            EmailLog.AppendText("[" + now + "]: " + s);
            Thread th = new Thread(()=>write("dd"),23);
            th.IsBackground = true;
        }

    }
}
