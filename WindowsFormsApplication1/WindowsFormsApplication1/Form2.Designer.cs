namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.radioLabel = new System.Windows.Forms.Label();
            this.hibCheckBox = new System.Windows.Forms.CheckBox();
            this.sendBtt = new System.Windows.Forms.Button();
            this.cancelBtt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(102, 89);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(102, 144);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(200, 20);
            this.textBox3.TabIndex = 2;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(2, 45);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(77, 16);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "User Name";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLabel.Location = new System.Drawing.Point(2, 89);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(103, 16);
            this.phoneLabel.TabIndex = 4;
            this.phoneLabel.Text = "Phone Number";
            // 
            // radioLabel
            // 
            this.radioLabel.AutoSize = true;
            this.radioLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioLabel.Location = new System.Drawing.Point(1, 144);
            this.radioLabel.Name = "radioLabel";
            this.radioLabel.Size = new System.Drawing.Size(99, 16);
            this.radioLabel.TabIndex = 5;
            this.radioLabel.Text = "Radio Number";
            // 
            // hibCheckBox
            // 
            this.hibCheckBox.AutoSize = true;
            this.hibCheckBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hibCheckBox.Location = new System.Drawing.Point(102, 185);
            this.hibCheckBox.Name = "hibCheckBox";
            this.hibCheckBox.Size = new System.Drawing.Size(49, 20);
            this.hibCheckBox.TabIndex = 7;
            this.hibCheckBox.Text = "HIB";
            this.hibCheckBox.UseVisualStyleBackColor = true;
            // 
            // sendBtt
            // 
            this.sendBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBtt.Location = new System.Drawing.Point(51, 348);
            this.sendBtt.Name = "sendBtt";
            this.sendBtt.Size = new System.Drawing.Size(75, 30);
            this.sendBtt.TabIndex = 8;
            this.sendBtt.Text = "Save";
            this.sendBtt.UseVisualStyleBackColor = true;
            this.sendBtt.Click += new System.EventHandler(this.sendBtt_Click);
            // 
            // cancelBtt
            // 
            this.cancelBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtt.Location = new System.Drawing.Point(171, 348);
            this.cancelBtt.Name = "cancelBtt";
            this.cancelBtt.Size = new System.Drawing.Size(75, 30);
            this.cancelBtt.TabIndex = 9;
            this.cancelBtt.Text = "Cancel";
            this.cancelBtt.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 412);
            this.Controls.Add(this.cancelBtt);
            this.Controls.Add(this.sendBtt);
            this.Controls.Add(this.hibCheckBox);
            this.Controls.Add(this.radioLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label radioLabel;
        private System.Windows.Forms.CheckBox hibCheckBox;
        private System.Windows.Forms.Button sendBtt;
        private System.Windows.Forms.Button cancelBtt;
    }
}