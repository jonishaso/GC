namespace MessageClientSide
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.sendBtt = new System.Windows.Forms.Button();
            this.hibBtt = new System.Windows.Forms.Button();
            this.messageRichBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioCheckBox = new System.Windows.Forms.CheckBox();
            this.mobileCheckBox = new System.Windows.Forms.CheckBox();
            this.refreshBtt = new System.Windows.Forms.Button();
            this.searchBtt = new System.Windows.Forms.Button();
            this.searchComboBox = new System.Windows.Forms.ComboBox();
            this.CleanBttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            // 
            // sendBtt
            // 
            resources.ApplyResources(this.sendBtt, "sendBtt");
            this.sendBtt.Name = "sendBtt";
            this.sendBtt.UseVisualStyleBackColor = true;
            this.sendBtt.Click += new System.EventHandler(this.sendBtt_Click);
            // 
            // hibBtt
            // 
            resources.ApplyResources(this.hibBtt, "hibBtt");
            this.hibBtt.Name = "hibBtt";
            this.hibBtt.UseVisualStyleBackColor = true;
            this.hibBtt.Click += new System.EventHandler(this.hibBtt_Click);
            // 
            // messageRichBox
            // 
            resources.ApplyResources(this.messageRichBox, "messageRichBox");
            this.messageRichBox.Name = "messageRichBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // radioCheckBox
            // 
            resources.ApplyResources(this.radioCheckBox, "radioCheckBox");
            this.radioCheckBox.Name = "radioCheckBox";
            this.radioCheckBox.UseVisualStyleBackColor = true;
            // 
            // mobileCheckBox
            // 
            resources.ApplyResources(this.mobileCheckBox, "mobileCheckBox");
            this.mobileCheckBox.Name = "mobileCheckBox";
            this.mobileCheckBox.UseVisualStyleBackColor = true;
            // 
            // refreshBtt
            // 
            resources.ApplyResources(this.refreshBtt, "refreshBtt");
            this.refreshBtt.Name = "refreshBtt";
            this.refreshBtt.UseVisualStyleBackColor = true;
            this.refreshBtt.Click += new System.EventHandler(this.refreshBtt_Click);
            // 
            // searchBtt
            // 
            resources.ApplyResources(this.searchBtt, "searchBtt");
            this.searchBtt.Name = "searchBtt";
            this.searchBtt.UseVisualStyleBackColor = true;
            this.searchBtt.Click += new System.EventHandler(this.searchBtt_Click);
            // 
            // searchComboBox
            // 
            this.searchComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.searchComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.searchComboBox.BackColor = System.Drawing.Color.Gray;
            this.searchComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.searchComboBox, "searchComboBox");
            this.searchComboBox.Name = "searchComboBox";
            // 
            // CleanBttn
            // 
            resources.ApplyResources(this.CleanBttn, "CleanBttn");
            this.CleanBttn.Name = "CleanBttn";
            this.CleanBttn.UseVisualStyleBackColor = true;
            this.CleanBttn.Click += new System.EventHandler(this.CleanBttn_Click);
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.CleanBttn);
            this.Controls.Add(this.searchComboBox);
            this.Controls.Add(this.searchBtt);
            this.Controls.Add(this.refreshBtt);
            this.Controls.Add(this.mobileCheckBox);
            this.Controls.Add(this.radioCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageRichBox);
            this.Controls.Add(this.hibBtt);
            this.Controls.Add(this.sendBtt);
            this.Controls.Add(this.dataGridView);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "mainForm";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button sendBtt;
        private System.Windows.Forms.Button hibBtt;
        private System.Windows.Forms.RichTextBox messageRichBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox radioCheckBox;
        private System.Windows.Forms.CheckBox mobileCheckBox;
        private System.Windows.Forms.Button refreshBtt;
        private System.Windows.Forms.Button searchBtt;
        private System.Windows.Forms.ComboBox searchComboBox;
        private System.Windows.Forms.Button CleanBttn;
    }
}

