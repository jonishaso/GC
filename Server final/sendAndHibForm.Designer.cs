namespace SmartPTT_API
{
    partial class sendAndHibForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sendAndHibForm));
            this.hibDataGridView = new System.Windows.Forms.DataGridView();
            this.ContentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sendBtt = new System.Windows.Forms.Button();
            this.cancelBtt = new System.Windows.Forms.Button();
            this.contentlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioCheckBox = new System.Windows.Forms.CheckBox();
            this.phoneCheckBox = new System.Windows.Forms.CheckBox();
            this.unavialablePhone = new System.Windows.Forms.RichTextBox();
            this.unavaibleRadio = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.hibDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // hibDataGridView
            // 
            this.hibDataGridView.AllowUserToAddRows = false;
            this.hibDataGridView.AllowUserToDeleteRows = false;
            this.hibDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hibDataGridView.Location = new System.Drawing.Point(12, 28);
            this.hibDataGridView.Name = "hibDataGridView";
            this.hibDataGridView.ReadOnly = true;
            this.hibDataGridView.Size = new System.Drawing.Size(462, 191);
            this.hibDataGridView.TabIndex = 0;
            // 
            // ContentRichTextBox
            // 
            this.ContentRichTextBox.Location = new System.Drawing.Point(12, 241);
            this.ContentRichTextBox.Name = "ContentRichTextBox";
            this.ContentRichTextBox.Size = new System.Drawing.Size(462, 96);
            this.ContentRichTextBox.TabIndex = 1;
            this.ContentRichTextBox.Text = "";
            // 
            // sendBtt
            // 
            this.sendBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBtt.Location = new System.Drawing.Point(306, 527);
            this.sendBtt.Name = "sendBtt";
            this.sendBtt.Size = new System.Drawing.Size(75, 23);
            this.sendBtt.TabIndex = 2;
            this.sendBtt.Text = "Send";
            this.sendBtt.UseVisualStyleBackColor = true;
            this.sendBtt.Click += new System.EventHandler(this.sendBtt_Click);
            // 
            // cancelBtt
            // 
            this.cancelBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtt.Location = new System.Drawing.Point(387, 527);
            this.cancelBtt.Name = "cancelBtt";
            this.cancelBtt.Size = new System.Drawing.Size(75, 23);
            this.cancelBtt.TabIndex = 3;
            this.cancelBtt.Text = "Cancel";
            this.cancelBtt.UseVisualStyleBackColor = true;
            this.cancelBtt.Click += new System.EventHandler(this.cancelBtt_Click);
            // 
            // contentlabel
            // 
            this.contentlabel.AutoSize = true;
            this.contentlabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentlabel.Location = new System.Drawing.Point(12, 222);
            this.contentlabel.Name = "contentlabel";
            this.contentlabel.Size = new System.Drawing.Size(116, 16);
            this.contentlabel.TabIndex = 4;
            this.contentlabel.Text = "Message Content";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Send To :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Send By :";
            // 
            // radioCheckBox
            // 
            this.radioCheckBox.AutoSize = true;
            this.radioCheckBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCheckBox.Location = new System.Drawing.Point(362, 407);
            this.radioCheckBox.Name = "radioCheckBox";
            this.radioCheckBox.Size = new System.Drawing.Size(64, 20);
            this.radioCheckBox.TabIndex = 7;
            this.radioCheckBox.Text = "Radio";
            this.radioCheckBox.UseVisualStyleBackColor = true;
            // 
            // phoneCheckBox
            // 
            this.phoneCheckBox.AutoSize = true;
            this.phoneCheckBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneCheckBox.Location = new System.Drawing.Point(362, 381);
            this.phoneCheckBox.Name = "phoneCheckBox";
            this.phoneCheckBox.Size = new System.Drawing.Size(68, 20);
            this.phoneCheckBox.TabIndex = 8;
            this.phoneCheckBox.Text = "Phone";
            this.phoneCheckBox.UseVisualStyleBackColor = true;
            // 
            // unavialablePhone
            // 
            this.unavialablePhone.Location = new System.Drawing.Point(12, 381);
            this.unavialablePhone.Name = "unavialablePhone";
            this.unavialablePhone.Size = new System.Drawing.Size(130, 150);
            this.unavialablePhone.TabIndex = 9;
            this.unavialablePhone.Text = "";
            // 
            // unavaibleRadio
            // 
            this.unavaibleRadio.Location = new System.Drawing.Point(148, 381);
            this.unavaibleRadio.Name = "unavaibleRadio";
            this.unavaibleRadio.Size = new System.Drawing.Size(130, 150);
            this.unavaibleRadio.TabIndex = 10;
            this.unavaibleRadio.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Unavialable Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(147, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Unaviable Radio";
            // 
            // sendAndHibForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 562);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.unavaibleRadio);
            this.Controls.Add(this.unavialablePhone);
            this.Controls.Add(this.phoneCheckBox);
            this.Controls.Add(this.radioCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contentlabel);
            this.Controls.Add(this.cancelBtt);
            this.Controls.Add(this.sendBtt);
            this.Controls.Add(this.ContentRichTextBox);
            this.Controls.Add(this.hibDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "sendAndHibForm";
            this.Text = "Send Message";
            this.Load += new System.EventHandler(this.sendAndHibForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hibDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView hibDataGridView;
        private System.Windows.Forms.RichTextBox ContentRichTextBox;
        private System.Windows.Forms.Button sendBtt;
        private System.Windows.Forms.Button cancelBtt;
        private System.Windows.Forms.Label contentlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox radioCheckBox;
        private System.Windows.Forms.CheckBox phoneCheckBox;
        private System.Windows.Forms.RichTextBox unavialablePhone;
        private System.Windows.Forms.RichTextBox unavaibleRadio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}