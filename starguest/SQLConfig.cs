using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartPTT_API
{
    public partial class SQLConfig : Form
    {
        SQLMonitor parentSQL;

        public SQLConfig(SQLMonitor aMonitor)
        {
            InitializeComponent();
            parentSQL = aMonitor;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            parentSQL.formatConnString(hostBox.Text, serverBox.Text, portNumBox.Text, nameBox.Text, passwordBox.Text);
            if (parentSQL.SQLCheckConn())
            {
                MessageBox.Show("Successfully connected to the Database.");
            }
            else
            {
                MessageBox.Show("Connection failed. Please try again.");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
