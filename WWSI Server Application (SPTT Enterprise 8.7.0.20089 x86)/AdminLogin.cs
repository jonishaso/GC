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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = passwordText.Text;
            if (password.Contains("password"))
            {
                MessageBox.Show("Admin login successful.");
                ConfigureApp aConfiguration = new ConfigureApp(true);
                aConfiguration.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect Password. Please try again.");
            }
        }
    }
}
