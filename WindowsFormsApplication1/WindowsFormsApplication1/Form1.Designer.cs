namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.deleteBtt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addBtt = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sendBtt = new System.Windows.Forms.Button();
            this.hibBtt = new System.Windows.Forms.Button();
            this.smBox = new System.Windows.Forms.RichTextBox();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kKDataSet = new WindowsFormsApplication1.KKDataSet();
            this.usersTableAdapter = new WindowsFormsApplication1.KKDataSetTableAdapters.usersTableAdapter();
            this.smLable = new System.Windows.Forms.Label();
            this.userLable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kKDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // deleteBtt
            // 
            this.deleteBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.deleteBtt.Location = new System.Drawing.Point(12, 214);
            this.deleteBtt.Name = "deleteBtt";
            this.deleteBtt.Size = new System.Drawing.Size(75, 30);
            this.deleteBtt.TabIndex = 1;
            this.deleteBtt.Text = "Delete";
            this.deleteBtt.UseVisualStyleBackColor = true;
            this.deleteBtt.Click += new System.EventHandler(this.deleteBtt_click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(543, 390);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 20);
            this.textBox1.TabIndex = 2;
            // 
            // addBtt
            // 
            this.addBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addBtt.Location = new System.Drawing.Point(12, 171);
            this.addBtt.Name = "addBtt";
            this.addBtt.Size = new System.Drawing.Size(75, 30);
            this.addBtt.TabIndex = 5;
            this.addBtt.Text = "Add";
            this.addBtt.UseVisualStyleBackColor = true;
            this.addBtt.Click += new System.EventHandler(this.addBtt_click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.usersBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(110, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(343, 404);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // sendBtt
            // 
            this.sendBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendBtt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sendBtt.Location = new System.Drawing.Point(676, 171);
            this.sendBtt.Name = "sendBtt";
            this.sendBtt.Size = new System.Drawing.Size(75, 30);
            this.sendBtt.TabIndex = 8;
            this.sendBtt.Text = "send";
            this.sendBtt.UseVisualStyleBackColor = true;
            // 
            // hibBtt
            // 
            this.hibBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hibBtt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.hibBtt.Location = new System.Drawing.Point(574, 171);
            this.hibBtt.Name = "hibBtt";
            this.hibBtt.Size = new System.Drawing.Size(75, 30);
            this.hibBtt.TabIndex = 9;
            this.hibBtt.Text = "HIB";
            this.hibBtt.UseVisualStyleBackColor = true;
            // 
            // smBox
            // 
            this.smBox.Location = new System.Drawing.Point(473, 46);
            this.smBox.Name = "smBox";
            this.smBox.Size = new System.Drawing.Size(278, 96);
            this.smBox.TabIndex = 10;
            this.smBox.Text = "";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "phone";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "users";
            this.usersBindingSource.DataSource = this.kKDataSet;
            // 
            // kKDataSet
            // 
            this.kKDataSet.DataSetName = "KKDataSet";
            this.kKDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // smLable
            // 
            this.smLable.AutoSize = true;
            this.smLable.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.smLable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.smLable.Location = new System.Drawing.Point(470, 21);
            this.smLable.Name = "smLable";
            this.smLable.Size = new System.Drawing.Size(116, 16);
            this.smLable.TabIndex = 11;
            this.smLable.Text = "Message Content";
            // 
            // userLable
            // 
            this.userLable.AutoSize = true;
            this.userLable.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.userLable.Location = new System.Drawing.Point(107, 21);
            this.userLable.Name = "userLable";
            this.userLable.Size = new System.Drawing.Size(62, 16);
            this.userLable.TabIndex = 12;
            this.userLable.Text = "User List";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.userLable);
            this.Controls.Add(this.smLable);
            this.Controls.Add(this.smBox);
            this.Controls.Add(this.hibBtt);
            this.Controls.Add(this.sendBtt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.addBtt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.deleteBtt);
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kKDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button deleteBtt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addBtt;
        private KKDataSet kKDataSet;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private KKDataSetTableAdapters.usersTableAdapter usersTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button sendBtt;
        private System.Windows.Forms.Button hibBtt;
        private System.Windows.Forms.RichTextBox smBox;
        private System.Windows.Forms.Label smLable;
        private System.Windows.Forms.Label userLable;
    }
}

