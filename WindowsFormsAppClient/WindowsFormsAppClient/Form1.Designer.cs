namespace WindowsFormsAppClient
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.commondComboBox = new System.Windows.Forms.ComboBox();
            this.varNameLabel = new System.Windows.Forms.Label();
            this.varNameTextBox = new System.Windows.Forms.TextBox();
            this.varTypeLabel = new System.Windows.Forms.Label();
            this.varTypeTextBox = new System.Windows.Forms.TextBox();
            this.newValLabel = new System.Windows.Forms.Label();
            this.newValTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.sendButton = new System.Windows.Forms.Button();
            this.sendMultiButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.changeIpButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.IPTextBox);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.logTextBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(394, 376);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sending to IP Address";
            // 
            // IPTextBox
            // 
            this.IPTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPTextBox.Location = new System.Drawing.Point(3, 23);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(391, 26);
            this.IPTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(3, 86);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(391, 237);
            this.logTextBox.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.commondComboBox);
            this.flowLayoutPanel2.Controls.Add(this.varNameLabel);
            this.flowLayoutPanel2.Controls.Add(this.varNameTextBox);
            this.flowLayoutPanel2.Controls.Add(this.varTypeLabel);
            this.flowLayoutPanel2.Controls.Add(this.varTypeTextBox);
            this.flowLayoutPanel2.Controls.Add(this.newValLabel);
            this.flowLayoutPanel2.Controls.Add(this.newValTextBox);
            this.flowLayoutPanel2.Controls.Add(this.sendButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(403, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(394, 376);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 29);
            this.label5.TabIndex = 7;
            this.label5.Text = "command type";
            // 
            // commondComboBox
            // 
            this.commondComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commondComboBox.FormattingEnabled = true;
            this.commondComboBox.Items.AddRange(new object[] {
            "GET",
            "SET",
            "PING"});
            this.commondComboBox.Location = new System.Drawing.Point(3, 32);
            this.commondComboBox.Name = "commondComboBox";
            this.commondComboBox.Size = new System.Drawing.Size(381, 32);
            this.commondComboBox.TabIndex = 8;
            this.commondComboBox.Text = "-- select command type --";
            this.commondComboBox.SelectedIndexChanged += new System.EventHandler(this.commondComboBox_SelectedIndexChanged);
            // 
            // varNameLabel
            // 
            this.varNameLabel.AutoSize = true;
            this.varNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varNameLabel.Location = new System.Drawing.Point(3, 67);
            this.varNameLabel.Name = "varNameLabel";
            this.varNameLabel.Size = new System.Drawing.Size(164, 29);
            this.varNameLabel.TabIndex = 5;
            this.varNameLabel.Text = "variable name";
            // 
            // varNameTextBox
            // 
            this.varNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varNameTextBox.Location = new System.Drawing.Point(3, 99);
            this.varNameTextBox.Name = "varNameTextBox";
            this.varNameTextBox.Size = new System.Drawing.Size(382, 29);
            this.varNameTextBox.TabIndex = 4;
            // 
            // varTypeLabel
            // 
            this.varTypeLabel.AutoSize = true;
            this.varTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varTypeLabel.Location = new System.Drawing.Point(3, 131);
            this.varTypeLabel.Name = "varTypeLabel";
            this.varTypeLabel.Size = new System.Drawing.Size(149, 29);
            this.varTypeLabel.TabIndex = 3;
            this.varTypeLabel.Text = "variable type";
            // 
            // varTypeTextBox
            // 
            this.varTypeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.varTypeTextBox.Location = new System.Drawing.Point(3, 163);
            this.varTypeTextBox.Name = "varTypeTextBox";
            this.varTypeTextBox.Size = new System.Drawing.Size(382, 29);
            this.varTypeTextBox.TabIndex = 2;
            // 
            // newValLabel
            // 
            this.newValLabel.AutoSize = true;
            this.newValLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newValLabel.Location = new System.Drawing.Point(3, 195);
            this.newValLabel.Name = "newValLabel";
            this.newValLabel.Size = new System.Drawing.Size(121, 29);
            this.newValLabel.TabIndex = 1;
            this.newValLabel.Text = "new value";
            // 
            // newValTextBox
            // 
            this.newValTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newValTextBox.Location = new System.Drawing.Point(3, 227);
            this.newValTextBox.Name = "newValTextBox";
            this.newValTextBox.Size = new System.Drawing.Size(382, 29);
            this.newValTextBox.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.sendMultiButton);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(403, 385);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(394, 62);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // sendBtn
            // 
            this.sendButton.Location = new System.Drawing.Point(3, 262);
            this.sendButton.Name = "sendBtn";
            this.sendButton.Size = new System.Drawing.Size(382, 29);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // button1
            // 
            this.sendMultiButton.Location = new System.Drawing.Point(3, 3);
            this.sendMultiButton.Name = "button1";
            this.sendMultiButton.Size = new System.Drawing.Size(382, 32);
            this.sendMultiButton.TabIndex = 3;
            this.sendMultiButton.Text = "send multiple commands with a file";
            this.sendMultiButton.UseVisualStyleBackColor = true;
            this.sendMultiButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.changeIpButton);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 385);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(394, 62);
            this.flowLayoutPanel4.TabIndex = 3;
            // 
            // changeIpBtn
            // 
            this.changeIpButton.Location = new System.Drawing.Point(3, 3);
            this.changeIpButton.Name = "changeIpBtn";
            this.changeIpButton.Size = new System.Drawing.Size(375, 32);
            this.changeIpButton.TabIndex = 0;
            this.changeIpButton.Text = "change IP address";
            this.changeIpButton.UseVisualStyleBackColor = true;
            this.changeIpButton.Click += new System.EventHandler(this.changeIpBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label varNameLabel;
        private System.Windows.Forms.TextBox varNameTextBox;
        private System.Windows.Forms.Label varTypeLabel;
        private System.Windows.Forms.TextBox varTypeTextBox;
        private System.Windows.Forms.Label newValLabel;
        private System.Windows.Forms.TextBox newValTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.ComboBox commondComboBox;
        private System.Windows.Forms.Button sendMultiButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button changeIpButton;
    }
}

