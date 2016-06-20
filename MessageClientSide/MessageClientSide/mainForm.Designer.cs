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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.sendBtt = new System.Windows.Forms.Button();
            this.consoleTextbox = new System.Windows.Forms.TextBox();
            this.hibBtt = new System.Windows.Forms.Button();
            this.messageRichBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Location = new System.Drawing.Point(85, 33);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(539, 225);
            this.dataGridView.TabIndex = 0;
            // 
            // sendBtt
            // 
            this.sendBtt.Location = new System.Drawing.Point(182, 315);
            this.sendBtt.Name = "sendBtt";
            this.sendBtt.Size = new System.Drawing.Size(75, 23);
            this.sendBtt.TabIndex = 1;
            this.sendBtt.Text = "Send";
            this.sendBtt.UseVisualStyleBackColor = true;
            this.sendBtt.Click += new System.EventHandler(this.sendBtt_Click);
            // 
            // consoleTextbox
            // 
            this.consoleTextbox.Location = new System.Drawing.Point(110, 418);
            this.consoleTextbox.Name = "consoleTextbox";
            this.consoleTextbox.Size = new System.Drawing.Size(246, 20);
            this.consoleTextbox.TabIndex = 2;
            // 
            // hibBtt
            // 
            this.hibBtt.Location = new System.Drawing.Point(409, 321);
            this.hibBtt.Name = "hibBtt";
            this.hibBtt.Size = new System.Drawing.Size(75, 23);
            this.hibBtt.TabIndex = 3;
            this.hibBtt.Text = "HIB";
            this.hibBtt.UseVisualStyleBackColor = true;
            this.hibBtt.Click += new System.EventHandler(this.hibBtt_Click);
            // 
            // messageRichBox
            // 
            this.messageRichBox.Location = new System.Drawing.Point(536, 317);
            this.messageRichBox.Name = "messageRichBox";
            this.messageRichBox.Size = new System.Drawing.Size(100, 96);
            this.messageRichBox.TabIndex = 4;
            this.messageRichBox.Text = "";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 513);
            this.Controls.Add(this.messageRichBox);
            this.Controls.Add(this.hibBtt);
            this.Controls.Add(this.consoleTextbox);
            this.Controls.Add(this.sendBtt);
            this.Controls.Add(this.dataGridView);
            this.Name = "mainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button sendBtt;
        private System.Windows.Forms.TextBox consoleTextbox;
        private System.Windows.Forms.Button hibBtt;
        private System.Windows.Forms.RichTextBox messageRichBox;
    }
}

