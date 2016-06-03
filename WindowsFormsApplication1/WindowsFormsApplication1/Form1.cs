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
    public partial class Form1 : Form
    {
        sql dbConn;
        public Form1(sql conn)
        {
            dbConn = conn;                  
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kKDataSet.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.kKDataSet.users);          
        }

        private void addBtt_click(object sender, EventArgs e)
        {

            new Form2(dbConn);
            
        }

        private void deleteBtt_click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow  i in dataGridView1.SelectedRows)
            {
                dbConn.deleteRow( i.Cells[1].Value.ToString());
            }
            dataGridView1.DataSource = dbConn.selectRow(3).Tables["users"];          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
