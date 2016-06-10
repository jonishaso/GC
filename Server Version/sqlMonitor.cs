using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SmartPTT_API
{
    public class sqlMonitor
    {
        string msg;
        MainForm parentForm;
        #region Initialization
        public sqlMonitor(MainForm aForm)
        {
            parentForm = aForm;
            CanRequestNotifications();
            initialiseDependency();
        }
        #endregion

        #region Properties
        private int changeCount = 0;
        private const string tableName = "Inventory";
        private const string statusMessage = "{0} changes have occurred.";
        private string connectionString = @"Data Source=LENOVO-PC\SQLEXPRESS;Initial Catalog=Clients;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private DataSet dataToWatch = null;
        private SqlConnection connection = null;
        private SqlCommand command = null;
        #endregion

        // Active SQL server listening when form loaded
        private void Form1_Load(object sender, EventArgs e)
        {
            CanRequestNotifications();
        }


        // Contact Jashiua...
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

        // Refer SQLMonitor class...
        private string GetSQL()
        {
            return "SELECT [message], [unread], [radioID], [phoneNum], [toPhone], [toRadio] FROM [Clients].[dbo].[RadioMessenger] WHERE [unread] = '1'";
        }

        //Fires event on change
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {


            List<string> lstPhone = new List<string>();
            List<string> lstRadio = new List<string>();
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;
            if (i.InvokeRequired)
            {
                OnChangeEventHandler tempDelegate = new OnChangeEventHandler(dependency_OnChange);      //Fire event once Table data changes
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
                {
                    connection.Open();
                    stateOn(connection);
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(GetSQL(), connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())       //Read the data from SQL database
                        {
                            msg = reader["message"].ToString();             //SQL message -> string msg


                            if (reader["toPhone"].ToString() == "1")
                            {
                                lstPhone.Add(reader["phoneNum"].ToString());         //SQL phoneNum -> lst
                            }
                            if (reader["toRadio"].ToString() == "1")
                            {
                                lstRadio.Add(reader["radioID"].ToString());         //SQL radioID -> lst
                                //MessageBox.Show("got it");
                            }
                        }
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    stateOff(connection);
                }
            }
            foreach (var radioID in lstRadio)
            {
                parentForm.sendRadio(radioID, msg);
            }

            foreach (var phoneNum in lstPhone)
            {
                parentForm.sendSMS(msg, phoneNum);
                Thread.Sleep(3000);
            }

            GetData();
            // setState();
        }

        // Once read messages in SQL server, reset every "FLAGS" - used to set conditions
        private void setReadMsg(SqlConnection conn)
        {
            string cmdRead = @"UPDATE [clients].[dbo].[RadioMessenger] SET [unread] = '0', [toPhone] = '0', [toRadio] = '0'";
            SqlCommand cmd = new SqlCommand(cmdRead, conn);
            cmd.ExecuteNonQuery();
        }

        // Once one of client ends occupy the server, set the "FLAG" to be busy
        private void stateOn(SqlConnection conn)
        {
            string cmdRead = @"UPDATE [Clients].[dbo].[ServerActive] SET [IsBusy] = '1' WHERE [Name] = 'Server' ";
            SqlCommand cmd = new SqlCommand(cmdRead, conn);
            cmd.ExecuteNonQuery();
        }

        // Free up the server once the request completed
        private void stateOff(SqlConnection conn)
        {
            string cmdRead = @"UPDATE [Clients].[dbo].[ServerActive] SET [IsBusy] = '0' WHERE [Name] = 'Server' ";
            SqlCommand cmd = new SqlCommand(cmdRead, conn);
            cmd.ExecuteNonQuery();
        }

        // Contact Jashiua if you have any questions about this
        public void setState()
        {
            string cmdRead = "UPDATE [Clients].[dbo].[ServerActive] SET [isBusy] = @isBusy";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(cmdRead, connection))
            {
                connection.Open();
                command.Parameters.Add("@isBusy", SqlDbType.TinyInt).Value = 0;
            }
        }

        // Contact Jashiua if you have any questions about this
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
        //Initializes SQLDependency
        public void initialiseDependency()
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
    }
}
