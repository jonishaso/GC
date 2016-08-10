﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmartPTT_API
{

    public delegate void transSendByRadio(string[] RadioID, string Message);
    public delegate void transSendByMobile(string[] phoneNO, string Message);

    public partial class sendAndHibForm : Form
    {    
        private DataTable SelectedTable;
        private EnumerableRowCollection noRadioUser;
        private EnumerableRowCollection noPhoneUser;
        private EnumerableRowCollection allRadio;
        private EnumerableRowCollection allPhone;

        public event transSendByRadio SendByRadioEvent;
        public event transSendByMobile SendByMobileEvent;

        public sendAndHibForm(DataTable t)
        {
            SelectedTable = t;
            InitializeComponent();
        }

        private void sendAndHibForm_Load(object sender, EventArgs e)
        {
            hibDataGridView.DataSource = SelectedTable;
            noRadioUser = from row in SelectedTable.AsEnumerable()
                          where row.Field<string>("radio") == null || row.Field<string>("radio") == ""
                          select row;
            noPhoneUser = from row in SelectedTable.AsEnumerable()
                          where row.Field<string>("phone") == null || row.Field<string>("phone") == ""
                          select row;
            allRadio = from row in SelectedTable.AsEnumerable()
                       where row.Field<string>("radio") != null && row.Field<string>("radio") != ""
                       select row;
            allPhone = from row in SelectedTable.AsEnumerable()
                       where row.Field<string>("phone") != null && row.Field<string>("phone") != ""
                       select row;

            foreach (DataRow r in noPhoneUser)
            {
                unavialablePhone.AppendText(string.Format("{0} \n", r.ItemArray[1]));
            }
            foreach (DataRow r in noRadioUser)
            {
                unavaibleRadio.AppendText(string.Format("{0} \n", r.ItemArray[1]));
            }
        }

        private void sendBtt_Click(object sender, EventArgs e)
        {
       
            if (ContentRichTextBox.Text == "")
            {
                MessageBox.Show("say something !!");
                return;
            }
                
            if (radioCheckBox.Checked && !phoneCheckBox.Checked)
            {
                string[] radioIDArray = allRadio.Cast<DataRow>().Select(r => r["radio"].ToString()).ToArray();
                SendByRadioEvent(radioIDArray, ContentRichTextBox.Text);
                ContentRichTextBox.Text = "";
                MessageBox.Show("mesage send ");
            }
            else if (phoneCheckBox.Checked && !radioCheckBox.Checked)
            {
                string[] phoneArray = allPhone.Cast<DataRow>().Select(r => r["phone"].ToString()).ToArray();
                SendByMobileEvent(phoneArray, ContentRichTextBox.Text);
                ContentRichTextBox.Text = "";
                MessageBox.Show("message send");
            }
            else if (radioCheckBox.Checked && phoneCheckBox.Checked)
            {
                string[] radioIDArray = allRadio.Cast<DataRow>().Select(r => r["radio"].ToString()).ToArray();
                SendByRadioEvent(radioIDArray, ContentRichTextBox.Text);
                MessageBox.Show("radio mesage sending finished ");
                string[] phoneArray = allPhone.Cast<DataRow>().Select(r => r["phone"].ToString()).ToArray();
                SendByMobileEvent(phoneArray, ContentRichTextBox.Text);
                MessageBox.Show("mobile mesage send finished");
                ContentRichTextBox.Text = "";
            }
            else
                MessageBox.Show("You have not choose which method to use ");

        }

        private void cancelBtt_Click(object sender, EventArgs e)
        {
            SelectedTable.Dispose();          
            this.Close();
        }
    }
}
