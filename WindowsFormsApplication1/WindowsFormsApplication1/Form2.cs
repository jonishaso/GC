using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        SqlConnection dbConn;
        public Form2(SqlConnection conn)
        {
            dbConn = conn;
            InitializeComponent();
        }

        private void sendBtt_Click(object sender, EventArgs e)
        {

        }
    }
}
