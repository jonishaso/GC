namespace SmartPTT_API
{
    partial class SQLMonitor
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
            this.EmailLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EmailLog
            // 
            this.EmailLog.BackColor = System.Drawing.SystemColors.Window;
            this.EmailLog.Location = new System.Drawing.Point(12, 12);
            this.EmailLog.Multiline = true;
            this.EmailLog.Name = "EmailLog";
            this.EmailLog.ReadOnly = true;
            this.EmailLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EmailLog.Size = new System.Drawing.Size(300, 200);
            this.EmailLog.TabIndex = 0;
            // 
            // SQLMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 226);
            this.Controls.Add(this.EmailLog);
            this.Name = "SQLMonitor";
            this.Text = "SQLMonitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EmailLog;
    }
}