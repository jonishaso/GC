namespace SmartPTT_API
{
    partial class MainForm
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
            this.treeRadioObjects = new System.Windows.Forms.TreeView();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.addBtt = new System.Windows.Forms.Button();
            this.deleteBtt = new System.Windows.Forms.Button();
            this.editBtt = new System.Windows.Forms.Button();
            this.freshBtt = new System.Windows.Forms.Button();
            this.hibBtt = new System.Windows.Forms.Button();
            this.MessageBtt = new System.Windows.Forms.Button();
            this.connectContralStation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // treeRadioObjects
            // 
            this.treeRadioObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeRadioObjects.Location = new System.Drawing.Point(12, 290);
            this.treeRadioObjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeRadioObjects.Name = "treeRadioObjects";
            this.treeRadioObjects.Size = new System.Drawing.Size(246, 297);
            this.treeRadioObjects.TabIndex = 6;
            this.treeRadioObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeRadioObjects_AfterSelect);
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.Color.White;
            this.consoleBox.Location = new System.Drawing.Point(264, 290);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(271, 298);
            this.consoleBox.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Console";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Radio Sever";
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(542, 253);
            this.dataGridView.TabIndex = 26;
            // 
            // addBtt
            // 
            this.addBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtt.Location = new System.Drawing.Point(560, 12);
            this.addBtt.Name = "addBtt";
            this.addBtt.Size = new System.Drawing.Size(75, 25);
            this.addBtt.TabIndex = 27;
            this.addBtt.Text = "Add";
            this.addBtt.UseVisualStyleBackColor = true;
            this.addBtt.Click += new System.EventHandler(this.addBtt_Click);
            // 
            // deleteBtt
            // 
            this.deleteBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtt.Location = new System.Drawing.Point(560, 43);
            this.deleteBtt.Name = "deleteBtt";
            this.deleteBtt.Size = new System.Drawing.Size(75, 25);
            this.deleteBtt.TabIndex = 28;
            this.deleteBtt.Text = "Delete";
            this.deleteBtt.UseVisualStyleBackColor = true;
            this.deleteBtt.Click += new System.EventHandler(this.deleteBtt_Click);
            // 
            // editBtt
            // 
            this.editBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtt.Location = new System.Drawing.Point(560, 74);
            this.editBtt.Name = "editBtt";
            this.editBtt.Size = new System.Drawing.Size(75, 23);
            this.editBtt.TabIndex = 29;
            this.editBtt.Text = "Edit";
            this.editBtt.UseVisualStyleBackColor = true;
            this.editBtt.Click += new System.EventHandler(this.editBtt_Click);
            // 
            // freshBtt
            // 
            this.freshBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.freshBtt.Location = new System.Drawing.Point(560, 103);
            this.freshBtt.Name = "freshBtt";
            this.freshBtt.Size = new System.Drawing.Size(75, 25);
            this.freshBtt.TabIndex = 30;
            this.freshBtt.Text = "Fresh";
            this.freshBtt.UseVisualStyleBackColor = true;
            this.freshBtt.Click += new System.EventHandler(this.freshBtt_Click);
            // 
            // hibBtt
            // 
            this.hibBtt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hibBtt.Location = new System.Drawing.Point(560, 209);
            this.hibBtt.Name = "hibBtt";
            this.hibBtt.Size = new System.Drawing.Size(75, 25);
            this.hibBtt.TabIndex = 31;
            this.hibBtt.Text = "HIB";
            this.hibBtt.UseVisualStyleBackColor = true;
            this.hibBtt.Click += new System.EventHandler(this.hibBtt_Click);
            // 
            // MessageBtt
            // 
            this.MessageBtt.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageBtt.Location = new System.Drawing.Point(560, 240);
            this.MessageBtt.Name = "MessageBtt";
            this.MessageBtt.Size = new System.Drawing.Size(75, 25);
            this.MessageBtt.TabIndex = 32;
            this.MessageBtt.Text = "Message";
            this.MessageBtt.UseVisualStyleBackColor = true;
            this.MessageBtt.Click += new System.EventHandler(this.MessageBtt_Click);
            // 
            // connectContralStation
            // 
            this.connectContralStation.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectContralStation.Location = new System.Drawing.Point(560, 155);
            this.connectContralStation.Name = "connectContralStation";
            this.connectContralStation.Size = new System.Drawing.Size(75, 23);
            this.connectContralStation.TabIndex = 33;
            this.connectContralStation.Text = "Ctr Station";
            this.connectContralStation.UseVisualStyleBackColor = true;
            this.connectContralStation.Click += new System.EventHandler(this.connectContralStation_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(645, 598);
            this.Controls.Add(this.connectContralStation);
            this.Controls.Add(this.MessageBtt);
            this.Controls.Add(this.hibBtt);
            this.Controls.Add(this.freshBtt);
            this.Controls.Add(this.editBtt);
            this.Controls.Add(this.deleteBtt);
            this.Controls.Add(this.addBtt);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.treeRadioObjects);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.MinimumSize = new System.Drawing.Size(454, 381);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WWSI Messenger GUI Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeRadioObjects;
        public System.Windows.Forms.TextBox consoleBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button addBtt;
        private System.Windows.Forms.Button deleteBtt;
        private System.Windows.Forms.Button editBtt;
        private System.Windows.Forms.Button freshBtt;
        private System.Windows.Forms.Button hibBtt;
        private System.Windows.Forms.Button MessageBtt;
        private System.Windows.Forms.Button connectContralStation;
    }
}

