namespace SmartPTT_API
{
    partial class ConfigureApp
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
            this.appConfig = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.dateTextbox = new System.Windows.Forms.TextBox();
            this.radioIPTextBox = new System.Windows.Forms.TextBox();
            this.monthTextBox = new System.Windows.Forms.TextBox();
            this.rsIPTextBox = new System.Windows.Forms.TextBox();
            this.csIDTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.expirationCheckbox = new System.Windows.Forms.CheckBox();
            this.SGCheckbox = new System.Windows.Forms.CheckBox();
            this.FPCheckbox = new System.Windows.Forms.CheckBox();
            this.SPCheckbox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.appConfig.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // appConfig
            // 
            this.appConfig.Controls.Add(this.tabPage1);
            this.appConfig.Controls.Add(this.tabPage2);
            this.appConfig.Controls.Add(this.tabPage3);
            this.appConfig.Location = new System.Drawing.Point(12, 12);
            this.appConfig.Name = "appConfig";
            this.appConfig.SelectedIndex = 0;
            this.appConfig.Size = new System.Drawing.Size(350, 287);
            this.appConfig.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Menu;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(342, 261);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Application Configuration";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.yearTextBox);
            this.groupBox2.Controls.Add(this.dateTextbox);
            this.groupBox2.Controls.Add(this.radioIPTextBox);
            this.groupBox2.Controls.Add(this.monthTextBox);
            this.groupBox2.Controls.Add(this.rsIPTextBox);
            this.groupBox2.Controls.Add(this.csIDTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 129);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuration";
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(234, 71);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(62, 20);
            this.yearTextBox.TabIndex = 9;
            // 
            // dateTextbox
            // 
            this.dateTextbox.Location = new System.Drawing.Point(136, 71);
            this.dateTextbox.Name = "dateTextbox";
            this.dateTextbox.Size = new System.Drawing.Size(43, 20);
            this.dateTextbox.TabIndex = 8;
            // 
            // radioIPTextBox
            // 
            this.radioIPTextBox.Location = new System.Drawing.Point(136, 97);
            this.radioIPTextBox.Name = "radioIPTextBox";
            this.radioIPTextBox.Size = new System.Drawing.Size(160, 20);
            this.radioIPTextBox.TabIndex = 7;
            // 
            // monthTextBox
            // 
            this.monthTextBox.Location = new System.Drawing.Point(186, 71);
            this.monthTextBox.Name = "monthTextBox";
            this.monthTextBox.Size = new System.Drawing.Size(42, 20);
            this.monthTextBox.TabIndex = 6;
            // 
            // rsIPTextBox
            // 
            this.rsIPTextBox.Location = new System.Drawing.Point(136, 45);
            this.rsIPTextBox.Name = "rsIPTextBox";
            this.rsIPTextBox.Size = new System.Drawing.Size(160, 20);
            this.rsIPTextBox.TabIndex = 5;
            // 
            // csIDTextBox
            // 
            this.csIDTextBox.Location = new System.Drawing.Point(136, 19);
            this.csIDTextBox.Name = "csIDTextBox";
            this.csIDTextBox.Size = new System.Drawing.Size(160, 20);
            this.csIDTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Radio IP (Test)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Expiration DD/MM/YY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Radio Server PC IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control Station ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.expirationCheckbox);
            this.groupBox1.Controls.Add(this.SGCheckbox);
            this.groupBox1.Controls.Add(this.FPCheckbox);
            this.groupBox1.Controls.Add(this.SPCheckbox);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enable/Disable Features";
            // 
            // expirationCheckbox
            // 
            this.expirationCheckbox.AutoSize = true;
            this.expirationCheckbox.Location = new System.Drawing.Point(190, 66);
            this.expirationCheckbox.Name = "expirationCheckbox";
            this.expirationCheckbox.Size = new System.Drawing.Size(72, 17);
            this.expirationCheckbox.TabIndex = 6;
            this.expirationCheckbox.Text = "Expiration";
            this.expirationCheckbox.UseVisualStyleBackColor = true;
            // 
            // SGCheckbox
            // 
            this.SGCheckbox.AutoSize = true;
            this.SGCheckbox.Location = new System.Drawing.Point(190, 43);
            this.SGCheckbox.Name = "SGCheckbox";
            this.SGCheckbox.Size = new System.Drawing.Size(73, 17);
            this.SGCheckbox.TabIndex = 5;
            this.SGCheckbox.Text = "StarGuest";
            this.SGCheckbox.UseVisualStyleBackColor = true;
            // 
            // FPCheckbox
            // 
            this.FPCheckbox.AutoSize = true;
            this.FPCheckbox.Location = new System.Drawing.Point(64, 66);
            this.FPCheckbox.Name = "FPCheckbox";
            this.FPCheckbox.Size = new System.Drawing.Size(102, 17);
            this.FPCheckbox.TabIndex = 4;
            this.FPCheckbox.Text = "Fire Alarm Panel";
            this.FPCheckbox.UseVisualStyleBackColor = true;
            // 
            // SPCheckbox
            // 
            this.SPCheckbox.AutoSize = true;
            this.SPCheckbox.Location = new System.Drawing.Point(64, 43);
            this.SPCheckbox.Name = "SPCheckbox";
            this.SPCheckbox.Size = new System.Drawing.Size(94, 17);
            this.SPCheckbox.TabIndex = 3;
            this.SPCheckbox.Text = "Security Panel";
            this.SPCheckbox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Menu;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(342, 261);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SQL Configuration";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Menu;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(342, 261);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Email Configuration";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 301);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(263, 301);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ConfigureApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(373, 329);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.appConfig);
            this.Name = "ConfigureApp";
            this.Text = "ConfigureApp";
            this.Load += new System.EventHandler(this.ConfigureApp_load);
            this.appConfig.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl appConfig;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox SGCheckbox;
        private System.Windows.Forms.CheckBox FPCheckbox;
        private System.Windows.Forms.CheckBox SPCheckbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox radioIPTextBox;
        private System.Windows.Forms.TextBox monthTextBox;
        private System.Windows.Forms.TextBox rsIPTextBox;
        private System.Windows.Forms.TextBox csIDTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox expirationCheckbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox dateTextbox;
    }
}