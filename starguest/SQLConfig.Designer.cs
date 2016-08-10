namespace SmartPTT_API
{
    partial class SQLConfig
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
            this.closeButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.portNumBox = new System.Windows.Forms.TextBox();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.hostBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.portNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(111, 207);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(93, 23);
            this.closeButton.TabIndex = 23;
            this.closeButton.Text = "Cancel";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 207);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(93, 23);
            this.connectButton.TabIndex = 22;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(12, 181);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '●';
            this.passwordBox.Size = new System.Drawing.Size(189, 20);
            this.passwordBox.TabIndex = 21;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(12, 142);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(189, 20);
            this.nameBox.TabIndex = 20;
            // 
            // portNumBox
            // 
            this.portNumBox.Location = new System.Drawing.Point(12, 103);
            this.portNumBox.Name = "portNumBox";
            this.portNumBox.Size = new System.Drawing.Size(189, 20);
            this.portNumBox.TabIndex = 19;
            this.portNumBox.Text = "1433";
            // 
            // serverBox
            // 
            this.serverBox.Location = new System.Drawing.Point(12, 64);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(189, 20);
            this.serverBox.TabIndex = 18;
            // 
            // hostBox
            // 
            this.hostBox.Location = new System.Drawing.Point(12, 25);
            this.hostBox.Name = "hostBox";
            this.hostBox.Size = new System.Drawing.Size(189, 20);
            this.hostBox.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Username";
            // 
            // portNumber
            // 
            this.portNumber.AutoSize = true;
            this.portNumber.Location = new System.Drawing.Point(12, 87);
            this.portNumber.Name = "portNumber";
            this.portNumber.Size = new System.Drawing.Size(66, 13);
            this.portNumber.TabIndex = 14;
            this.portNumber.Text = "Port Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Server Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Host Name/PC Name";
            // 
            // SQLConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 243);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.portNumBox);
            this.Controls.Add(this.serverBox);
            this.Controls.Add(this.hostBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.portNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SQLConfig";
            this.Text = "SQLConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox portNumBox;
        private System.Windows.Forms.TextBox serverBox;
        private System.Windows.Forms.TextBox hostBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label portNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}