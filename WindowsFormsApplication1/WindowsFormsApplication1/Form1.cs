using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        emailWatcher newestMail;

        public Form1(emailWatcher em)
        {
            newestMail = em;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newestMail.FreshEmail();
            //textBox1.Text = newestMail.lastEmail.fromAddress;
            textBox1.Text = "adfdsfsdafasfadfasf";
            
        }

        private void freshEmail_Click(object sender, EventArgs e)
        {
            //List<string> hh = new List<string>();

            //hh.Add("123");
            //hh.Add("456");
            //hh.Add("789");
            //lbox.DataSource = hh;
            //lbox.DataSource = newestMail.lastTenEmail;
        }
    }
}
