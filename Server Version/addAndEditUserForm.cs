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
    public delegate bool transfAdding(userDetial u);
    public delegate bool transfEditing(userDetial new_inform, int ID);

    public partial class addAndEditUserForm : Form
    {
        private userDetial user;
        private int ID;
        bool add_OR_edit;//add new user = true; edit existing user = false

        public event transfAdding transEventAdding;
        public event transfEditing transEventEditing;

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
        }

        private void saveBtt_Click(object sender, EventArgs e)
        {
            user.name = nameTextBox.Text;
            user.phone = phoneTextBox.Text;
            user.radio = radioTextBox.Text;
            user.HIB = hibCheckBox.Checked ? true : false;
            if (add_OR_edit == true)
            {
                transEventAdding(user);
            }
            else
            {
                transEventEditing(user, ID);
            }
            this.Close();
        }

        private void cancelBtt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
