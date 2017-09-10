namespace Loot3Vorbereitung
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.typeTab = new System.Windows.Forms.TabPage();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.rarityTab = new System.Windows.Forms.TabPage();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.allowedTab = new System.Windows.Forms.TabPage();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.attributeTab = new System.Windows.Forms.TabPage();
            this.attributeCheckBox = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.typeTab.SuspendLayout();
            this.rarityTab.SuspendLayout();
            this.allowedTab.SuspendLayout();
            this.attributeTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(707, 199);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Loot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Namefilter";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.typeTab);
            this.tabControl1.Controls.Add(this.rarityTab);
            this.tabControl1.Controls.Add(this.allowedTab);
            this.tabControl1.Controls.Add(this.attributeTab);
            this.tabControl1.Location = new System.Drawing.Point(726, 39);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(250, 199);
            this.tabControl1.TabIndex = 3;
            // 
            // typeTab
            // 
            this.typeTab.Controls.Add(this.checkedListBox1);
            this.typeTab.Location = new System.Drawing.Point(4, 22);
            this.typeTab.Name = "typeTab";
            this.typeTab.Padding = new System.Windows.Forms.Padding(3);
            this.typeTab.Size = new System.Drawing.Size(242, 173);
            this.typeTab.TabIndex = 0;
            this.typeTab.Text = "Types";
            this.typeTab.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(239, 169);
            this.checkedListBox1.TabIndex = 0;
            // 
            // rarityTab
            // 
            this.rarityTab.Controls.Add(this.checkedListBox2);
            this.rarityTab.Location = new System.Drawing.Point(4, 22);
            this.rarityTab.Name = "rarityTab";
            this.rarityTab.Padding = new System.Windows.Forms.Padding(3);
            this.rarityTab.Size = new System.Drawing.Size(242, 173);
            this.rarityTab.TabIndex = 1;
            this.rarityTab.Text = "Rarities";
            this.rarityTab.UseVisualStyleBackColor = true;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(0, 1);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(242, 169);
            this.checkedListBox2.TabIndex = 0;
            // 
            // allowedTab
            // 
            this.allowedTab.Controls.Add(this.checkedListBox3);
            this.allowedTab.Location = new System.Drawing.Point(4, 22);
            this.allowedTab.Name = "allowedTab";
            this.allowedTab.Size = new System.Drawing.Size(242, 173);
            this.allowedTab.TabIndex = 2;
            this.allowedTab.Text = "AllowedItems";
            this.allowedTab.UseVisualStyleBackColor = true;
            // 
            // checkedListBox3
            // 
            this.checkedListBox3.FormattingEnabled = true;
            this.checkedListBox3.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox3.Name = "checkedListBox3";
            this.checkedListBox3.Size = new System.Drawing.Size(239, 169);
            this.checkedListBox3.TabIndex = 0;
            // 
            // attributeTab
            // 
            this.attributeTab.Controls.Add(this.attributeCheckBox);
            this.attributeTab.Location = new System.Drawing.Point(4, 22);
            this.attributeTab.Name = "attributeTab";
            this.attributeTab.Size = new System.Drawing.Size(242, 173);
            this.attributeTab.TabIndex = 3;
            this.attributeTab.Text = "Attributes";
            this.attributeTab.UseVisualStyleBackColor = true;
            // 
            // attributeCheckBox
            // 
            this.attributeCheckBox.FormattingEnabled = true;
            this.attributeCheckBox.Location = new System.Drawing.Point(3, 3);
            this.attributeCheckBox.Name = "attributeCheckBox";
            this.attributeCheckBox.Size = new System.Drawing.Size(236, 169);
            this.attributeCheckBox.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(155, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(461, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Add Containers";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 261);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.typeTab.ResumeLayout(false);
            this.rarityTab.ResumeLayout(false);
            this.allowedTab.ResumeLayout(false);
            this.attributeTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage typeTab;
        private System.Windows.Forms.TabPage rarityTab;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage allowedTab;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
        private System.Windows.Forms.TabPage attributeTab;
        private System.Windows.Forms.CheckedListBox attributeCheckBox;
    }
}