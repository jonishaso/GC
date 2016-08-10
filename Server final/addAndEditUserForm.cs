using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;

namespace SmartPTT_API
{
    public delegate bool transfAdding(userDetial u);
    public delegate bool transfEditing(userDetial new_inform, int ID);

    public partial class addAndEditUserForm : Form
    {
        private userDetial user;
        private int ID;
        bool add_OR_edit;//add new user = true; edit existing user = false
        private string country_Code;
        public event transfAdding transEventAdding;
        public event transfEditing transEventEditing;
        public event Action refreshDB;

        public addAndEditUserForm(userDetial u, int user_id)// for editing user's infor purpose
        {
            user = u;
            ID = user_id;
            add_OR_edit = false;
            InitializeComponent();
            nameTextBox.Text = u.name;
            phoneTextBox.Text = u.phone;
            radioTextBox.Text = u.radio;
            hibCheckBox.Checked = u.HIB;
        }
        public addAndEditUserForm()// for adding a new user purpose
        {
            user = new userDetial(null, null, null, false);
            add_OR_edit = true;
            InitializeComponent();
            StreamReader r = new StreamReader(string.Format("{0}/CountryCode.json", Path.GetDirectoryName(Application.ExecutablePath)));
            string json = r.ReadToEnd();
            List<countryCode> array = JsonConvert.DeserializeObject<List<countryCode>>(json);         
            countryCodeComboBox.DataSource = array;
            countryCodeComboBox.DisplayMember = "name";
            countryCodeComboBox.ValueMember = "code";
        }

        private void saveBtt_Click(object sender, EventArgs e)
        {
            user.name = nameTextBox.Text;
            
            user.radio = radioTextBox.Text;
            user.HIB = hibCheckBox.Checked ? true : false;
            if (add_OR_edit == true)
            {
                user.phone = countryCodeComboBox.SelectedValue.ToString() + phoneTextBox.Text;
                transEventAdding(user);
                refreshDB();
            }
            else
            {
                user.phone = phoneTextBox.Text;
                transEventEditing(user, ID);
                refreshDB();
            }
            this.Close();
        }

        private void cancelBtt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class countryCode
    {
        public string name { get; set; }
        public string code{ get; set; }

        public countryCode(string c, string n)
        {
            code = c;
            name = n;
        }

    }
 
}
