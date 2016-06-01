namespace SmartPTT_API
{
    partial class AlertLogWatcher
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
            this.AlertLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AlertLog
            // 
            this.AlertLog.BackColor = System.Drawing.SystemColors.Window;
            this.AlertLog.Location = new System.Drawing.Point(12, 12);
            this.AlertLog.Multiline = true;
            this.AlertLog.Name = "AlertLog";
            this.AlertLog.ReadOnly = true;
            this.AlertLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AlertLog.Size = new System.Drawing.Size(300, 200);
            this.AlertLog.TabIndex = 0;
            // 
            // AlertLogWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 226);
            this.Controls.Add(this.AlertLog);
            this.Name = "AlertLogWatcher";
            this.Text = "AlertLogWatcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AlertLog;
    }
}