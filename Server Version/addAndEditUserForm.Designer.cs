namespace SmartPTT_API
{
    partial class addAndEditUserForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.radioTextBox = new System.Windows.Forms.TextBox();
            this.hibCheckBox = new System.Windows.Forms.CheckBox();
            this.saveBtt = new System.Windows.Forms.Button();
            this.cancelBtt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(140, 111);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(198, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(140, 137);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(198, 20);
            this.phoneTextBox.TabIndex = 1;
            // 
            // radioTextBox
            // 
            this.radioTextBox.Location = new System.Drawing.Point(140, 163);
            this.radioTextBox.Name = "radioTextBox";
            this.radioTextBox.Size = new System.Drawing.Size(198, 20);
            this.radioTextBox.TabIndex = 2;
            // 
            // hibCheckBox
            // 
            this.hibCheckBox.AutoSize = true;
            this.hibCheckBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hibCheckBox.Location = new System.Drawing.Point(140, 216);
            this.hibCheckBox.Name = "hibCheckBox";
            this.hibCheckBox.Size = new System.Drawing.Size(53, 20);
            this.hibCheckBox.TabIndex = 3;
            this.hibCheckBox.Text = "HIB ";
            this.hibCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveBtt
            // 
            this.saveBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtt.Location = new System.Drawing.Point(80, 302);
            this.saveBtt.Name = "saveBtt";
            this.saveBtt.Size = new System.Drawing.Size(75, 23);
            this.saveBtt.TabIndex = 4;
            this.saveBtt.Text = "Save";
            this.saveBtt.UseVisualStyleBackColor = true;
            this.saveBtt.Click += new System.EventHandler(this.saveBtt_Click);
            // 
            // cancelBtt
            // 
            this.cancelBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtt.Location = new System.Drawing.Point(209, 313);
            this.cancelBtt.Name = "cancelBtt";
            this.cancelBtt.Size = new System.Drawing.Size(75, 23);
            this.cancelBtt.TabIndex = 5;
            this.cancelBtt.Text = "Cancel";
            this.cancelBtt.UseVisualStyleBackColor = true;
            this.cancelBtt.Click += new System.EventHandler(this.cancelBtt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "User\'s Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Radio ID";
            // 
            // addAndEditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtt);
            this.Controls.Add(this.saveBtt);
            this.Controls.Add(this.hibCheckBox);
            this.Controls.Add(this.radioTextBox);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Name = "addAndEditUserForm";
            this.Text = "addAndEditUserForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox radioTextBox;
        private System.Windows.Forms.CheckBox hibCheckBox;
        private System.Windows.Forms.Button saveBtt;
        private System.Windows.Forms.Button cancelBtt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}