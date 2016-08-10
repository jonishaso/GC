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
            this.countryCodeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(94, 30);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(233, 22);
            this.nameTextBox.TabIndex = 0;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(187, 73);
            this.phoneTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(140, 22);
            this.phoneTextBox.TabIndex = 1;
            // 
            // radioTextBox
            // 
            this.radioTextBox.Location = new System.Drawing.Point(94, 115);
            this.radioTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioTextBox.Name = "radioTextBox";
            this.radioTextBox.Size = new System.Drawing.Size(233, 22);
            this.radioTextBox.TabIndex = 2;
            // 
            // hibCheckBox
            // 
            this.hibCheckBox.AutoSize = true;
            this.hibCheckBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hibCheckBox.Location = new System.Drawing.Point(14, 152);
            this.hibCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hibCheckBox.Name = "hibCheckBox";
            this.hibCheckBox.Size = new System.Drawing.Size(53, 20);
            this.hibCheckBox.TabIndex = 3;
            this.hibCheckBox.Text = "HIB ";
            this.hibCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveBtt
            // 
            this.saveBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtt.Location = new System.Drawing.Point(68, 215);
            this.saveBtt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveBtt.Name = "saveBtt";
            this.saveBtt.Size = new System.Drawing.Size(87, 28);
            this.saveBtt.TabIndex = 4;
            this.saveBtt.Text = "Save";
            this.saveBtt.UseVisualStyleBackColor = true;
            this.saveBtt.Click += new System.EventHandler(this.saveBtt_Click);
            // 
            // cancelBtt
            // 
            this.cancelBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtt.Location = new System.Drawing.Point(174, 215);
            this.cancelBtt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelBtt.Name = "cancelBtt";
            this.cancelBtt.Size = new System.Drawing.Size(87, 28);
            this.cancelBtt.TabIndex = 5;
            this.cancelBtt.Text = "Cancel";
            this.cancelBtt.UseVisualStyleBackColor = true;
            this.cancelBtt.Click += new System.EventHandler(this.cancelBtt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Radio ID";
            // 
            // countryCodeComboBox
            // 
            this.countryCodeComboBox.FormattingEnabled = true;
            this.countryCodeComboBox.Location = new System.Drawing.Point(94, 71);
            this.countryCodeComboBox.Name = "countryCodeComboBox";
            this.countryCodeComboBox.Size = new System.Drawing.Size(87, 24);
            this.countryCodeComboBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(328, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Please do not use country code list when editing phone";
            // 
            // addAndEditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 257);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countryCodeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtt);
            this.Controls.Add(this.saveBtt);
            this.Controls.Add(this.hibCheckBox);
            this.Controls.Add(this.radioTextBox);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "addAndEditUserForm";
            this.Text = "Add or Edit User Info";
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
        private System.Windows.Forms.ComboBox countryCodeComboBox;
        private System.Windows.Forms.Label label4;
    }
}