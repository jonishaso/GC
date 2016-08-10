namespace SmartPTT_API
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbServerAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butConnect = new System.Windows.Forms.Button();
            this.pttButton = new System.Windows.Forms.Button();
            this.labelInfo = new System.Windows.Forms.Label();
            this.treeRadioObjects = new System.Windows.Forms.TreeView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.soundSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.labelSelectInfo = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.openWatcher = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbServerAddress
            // 
            this.tbServerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbServerAddress.Location = new System.Drawing.Point(88, 39);
            this.tbServerAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbServerAddress.Name = "tbServerAddress";
            this.tbServerAddress.Size = new System.Drawing.Size(230, 20);
            this.tbServerAddress.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Radioserver";
            // 
            // butConnect
            // 
            this.butConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butConnect.Location = new System.Drawing.Point(322, 36);
            this.butConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(102, 25);
            this.butConnect.TabIndex = 2;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // pttButton
            // 
            this.pttButton.Location = new System.Drawing.Point(246, 87);
            this.pttButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pttButton.Name = "pttButton";
            this.pttButton.Size = new System.Drawing.Size(89, 43);
            this.pttButton.TabIndex = 4;
            this.pttButton.Text = "PTT";
            this.pttButton.UseVisualStyleBackColor = true;
            this.pttButton.Click += new System.EventHandler(this.pttButton_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInfo.ForeColor = System.Drawing.Color.Blue;
            this.labelInfo.Location = new System.Drawing.Point(243, 150);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(183, 65);
            this.labelInfo.TabIndex = 5;
            this.labelInfo.Text = "Info";
            // 
            // treeRadioObjects
            // 
            this.treeRadioObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeRadioObjects.Location = new System.Drawing.Point(9, 74);
            this.treeRadioObjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeRadioObjects.Name = "treeRadioObjects";
            this.treeRadioObjects.Size = new System.Drawing.Size(214, 244);
            this.treeRadioObjects.TabIndex = 6;
            this.treeRadioObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeRadioObjects_AfterSelect);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soundSettings,
            this.toolStripButton1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(438, 25);
            this.toolStrip.TabIndex = 7;
            // 
            // soundSettings
            // 
            this.soundSettings.Enabled = false;
            this.soundSettings.Image = ((System.Drawing.Image)(resources.GetObject("soundSettings.Image")));
            this.soundSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.soundSettings.Name = "soundSettings";
            this.soundSettings.Size = new System.Drawing.Size(106, 22);
            this.soundSettings.Text = "Sound Settings";
            this.soundSettings.Click += new System.EventHandler(this.soundSettings_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(140, 22);
            this.toolStripButton1.Text = "Admin Configuration";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // labelSelectInfo
            // 
            this.labelSelectInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSelectInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelSelectInfo.ForeColor = System.Drawing.Color.DarkMagenta;
            this.labelSelectInfo.Location = new System.Drawing.Point(9, 323);
            this.labelSelectInfo.Name = "labelSelectInfo";
            this.labelSelectInfo.Size = new System.Drawing.Size(214, 26);
            this.labelSelectInfo.TabIndex = 8;
            this.labelSelectInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelState
            // 
            this.labelState.BackColor = System.Drawing.Color.White;
            this.labelState.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelState.Location = new System.Drawing.Point(243, 323);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(181, 26);
            this.labelState.TabIndex = 9;
            // 
            // openWatcher
            // 
            this.openWatcher.Location = new System.Drawing.Point(246, 218);
            this.openWatcher.Multiline = true;
            this.openWatcher.Name = "openWatcher";
            this.openWatcher.Size = new System.Drawing.Size(178, 58);
            this.openWatcher.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 21);
            this.button1.TabIndex = 11;
            this.button1.Text = "Test Connection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(337, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 43);
            this.button2.TabIndex = 12;
            this.button2.Text = "SQL ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 362);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.openWatcher);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.labelSelectInfo);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.treeRadioObjects);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.pttButton);
            this.Controls.Add(this.butConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbServerAddress);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(454, 381);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WWSI Messenger Server 1.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbServerAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.Button pttButton;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TreeView treeRadioObjects;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton soundSettings;
        private System.Windows.Forms.Label labelSelectInfo;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.TextBox openWatcher;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

