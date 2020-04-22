﻿namespace WindowsFormsAppLogs
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.importLogBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.logDataGridView = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.typeCountBox = new System.Windows.Forms.TextBox();
            this.SourceCountBox = new System.Windows.Forms.TextBox();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.infoChkBox = new System.Windows.Forms.CheckBox();
            this.warningChkBox = new System.Windows.Forms.CheckBox();
            this.errorChkBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.sourceCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.timeStampTextBox = new System.Windows.Forms.TextBox();
            this.bodyTextBox = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logDataGridView)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.logDataGridView, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1268, 594);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.importLogBtn);
            this.flowLayoutPanel1.Controls.Add(this.closeBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(509, 507);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(756, 84);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save as CSV";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // importLogBtn
            // 
            this.importLogBtn.Location = new System.Drawing.Point(180, 3);
            this.importLogBtn.Name = "importLogBtn";
            this.importLogBtn.Size = new System.Drawing.Size(88, 23);
            this.importLogBtn.TabIndex = 2;
            this.importLogBtn.Text = "Import Log File";
            this.importLogBtn.UseVisualStyleBackColor = true;
            this.importLogBtn.Click += new System.EventHandler(this.importLogBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(274, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // logDataGridView
            // 
            this.logDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logDataGridView.Location = new System.Drawing.Point(509, 92);
            this.logDataGridView.Name = "logDataGridView";
            this.logDataGridView.Size = new System.Drawing.Size(756, 409);
            this.logDataGridView.TabIndex = 1;
            this.logDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.logDataGridView_CellContentClick);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.typeCountBox);
            this.flowLayoutPanel2.Controls.Add(this.SourceCountBox);
            this.flowLayoutPanel2.Controls.Add(this.dateTextBox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(509, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(756, 83);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // typeCountBox
            // 
            this.typeCountBox.AcceptsReturn = true;
            this.typeCountBox.AcceptsTab = true;
            this.typeCountBox.Location = new System.Drawing.Point(3, 3);
            this.typeCountBox.Multiline = true;
            this.typeCountBox.Name = "typeCountBox";
            this.typeCountBox.ReadOnly = true;
            this.typeCountBox.Size = new System.Drawing.Size(156, 68);
            this.typeCountBox.TabIndex = 0;
            // 
            // SourceCountBox
            // 
            this.SourceCountBox.Location = new System.Drawing.Point(165, 3);
            this.SourceCountBox.Multiline = true;
            this.SourceCountBox.Name = "SourceCountBox";
            this.SourceCountBox.ReadOnly = true;
            this.SourceCountBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SourceCountBox.Size = new System.Drawing.Size(199, 68);
            this.SourceCountBox.TabIndex = 1;
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(370, 3);
            this.dateTextBox.Multiline = true;
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.ReadOnly = true;
            this.dateTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dateTextBox.Size = new System.Drawing.Size(176, 68);
            this.dateTextBox.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.infoChkBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.warningChkBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.errorChkBox, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(256, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(247, 83);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // infoChkBox
            // 
            this.infoChkBox.AutoSize = true;
            this.infoChkBox.Checked = true;
            this.infoChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.infoChkBox.Location = new System.Drawing.Point(3, 3);
            this.infoChkBox.Name = "infoChkBox";
            this.infoChkBox.Size = new System.Drawing.Size(51, 17);
            this.infoChkBox.TabIndex = 3;
            this.infoChkBox.Text = "INFO";
            this.infoChkBox.UseVisualStyleBackColor = true;
            // 
            // warningChkBox
            // 
            this.warningChkBox.AutoSize = true;
            this.warningChkBox.Checked = true;
            this.warningChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.warningChkBox.Location = new System.Drawing.Point(3, 34);
            this.warningChkBox.Name = "warningChkBox";
            this.warningChkBox.Size = new System.Drawing.Size(79, 17);
            this.warningChkBox.TabIndex = 4;
            this.warningChkBox.Text = "WARNING";
            this.warningChkBox.UseVisualStyleBackColor = true;
            // 
            // errorChkBox
            // 
            this.errorChkBox.AutoSize = true;
            this.errorChkBox.Checked = true;
            this.errorChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.errorChkBox.Location = new System.Drawing.Point(3, 65);
            this.errorChkBox.Name = "errorChkBox";
            this.errorChkBox.Size = new System.Drawing.Size(65, 15);
            this.errorChkBox.TabIndex = 5;
            this.errorChkBox.Text = "ERROR";
            this.errorChkBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.sourceCheckedListBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(256, 92);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(247, 409);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // sourceCheckedListBox
            // 
            this.sourceCheckedListBox.FormattingEnabled = true;
            this.sourceCheckedListBox.Location = new System.Drawing.Point(3, 3);
            this.sourceCheckedListBox.Name = "sourceCheckedListBox";
            this.sourceCheckedListBox.Size = new System.Drawing.Size(241, 184);
            this.sourceCheckedListBox.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Run Filters";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.textBox5);
            this.flowLayoutPanel3.Controls.Add(this.typeTextBox);
            this.flowLayoutPanel3.Controls.Add(this.sourceTextBox);
            this.flowLayoutPanel3.Controls.Add(this.timeStampTextBox);
            this.flowLayoutPanel3.Controls.Add(this.bodyTextBox);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 92);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(247, 409);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(3, 29);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.ReadOnly = true;
            this.typeTextBox.Size = new System.Drawing.Size(79, 20);
            this.typeTextBox.TabIndex = 0;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(88, 29);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.ReadOnly = true;
            this.sourceTextBox.Size = new System.Drawing.Size(144, 20);
            this.sourceTextBox.TabIndex = 1;
            // 
            // timeStampTextBox
            // 
            this.timeStampTextBox.Location = new System.Drawing.Point(3, 55);
            this.timeStampTextBox.Name = "timeStampTextBox";
            this.timeStampTextBox.ReadOnly = true;
            this.timeStampTextBox.Size = new System.Drawing.Size(229, 20);
            this.timeStampTextBox.TabIndex = 2;
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Location = new System.Drawing.Point(3, 81);
            this.bodyTextBox.Multiline = true;
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.ReadOnly = true;
            this.bodyTextBox.Size = new System.Drawing.Size(229, 307);
            this.bodyTextBox.TabIndex = 3;
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(3, 3);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(229, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.Text = "Selected Row";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel4.Controls.Add(this.button3);
            this.flowLayoutPanel4.Controls.Add(this.button4);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(23, 207);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(200, 199);
            this.flowLayoutPanel4.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(190, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Show Row Details";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 594);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logDataGridView)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button importLogBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.DataGridView logDataGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox typeCountBox;
        private System.Windows.Forms.TextBox SourceCountBox;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox infoChkBox;
        private System.Windows.Forms.CheckBox warningChkBox;
        private System.Windows.Forms.CheckBox errorChkBox;
        private System.Windows.Forms.CheckedListBox sourceCheckedListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TextBox timeStampTextBox;
        private System.Windows.Forms.TextBox bodyTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button button4;
    }
}

