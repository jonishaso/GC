namespace SmartPTT_API
{
    partial class SoundSettingForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.voipMixerInputLine = new System.Windows.Forms.ComboBox();
            this.voipCaptureDevice = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.voipPlaybackDevice = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.textError = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.voipMixerInputLine);
            this.groupBox1.Controls.Add(this.voipCaptureDevice);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Audio Input";
            // 
            // voipMixerInputLine
            // 
            this.voipMixerInputLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voipMixerInputLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.voipMixerInputLine.FormattingEnabled = true;
            this.voipMixerInputLine.Location = new System.Drawing.Point(114, 72);
            this.voipMixerInputLine.Name = "voipMixerInputLine";
            this.voipMixerInputLine.Size = new System.Drawing.Size(447, 24);
            this.voipMixerInputLine.TabIndex = 3;
            // 
            // voipCaptureDevice
            // 
            this.voipCaptureDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voipCaptureDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.voipCaptureDevice.FormattingEnabled = true;
            this.voipCaptureDevice.Location = new System.Drawing.Point(114, 31);
            this.voipCaptureDevice.Name = "voipCaptureDevice";
            this.voipCaptureDevice.Size = new System.Drawing.Size(447, 24);
            this.voipCaptureDevice.TabIndex = 2;
            this.voipCaptureDevice.SelectedIndexChanged += new System.EventHandler(this.voipCaptureDevice_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Input Line";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.voipPlaybackDevice);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(10, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(576, 78);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audio Output";
            // 
            // voipPlaybackDevice
            // 
            this.voipPlaybackDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voipPlaybackDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.voipPlaybackDevice.FormattingEnabled = true;
            this.voipPlaybackDevice.Location = new System.Drawing.Point(114, 31);
            this.voipPlaybackDevice.Name = "voipPlaybackDevice";
            this.voipPlaybackDevice.Size = new System.Drawing.Size(447, 24);
            this.voipPlaybackDevice.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Device";
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(325, 287);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(119, 36);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.Location = new System.Drawing.Point(467, 287);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(119, 36);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // textError
            // 
            this.textError.ForeColor = System.Drawing.Color.Red;
            this.textError.Location = new System.Drawing.Point(10, 411);
            this.textError.Name = "textError";
            this.textError.Size = new System.Drawing.Size(582, 63);
            this.textError.TabIndex = 5;
            // 
            // SoundSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 338);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textError);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(615, 380);
            this.Name = "SoundSettingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sound Settings";
            this.Load += new System.EventHandler(this.SoundSettingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox voipMixerInputLine;
        private System.Windows.Forms.ComboBox voipCaptureDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox voipPlaybackDevice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Label textError;
    }
}