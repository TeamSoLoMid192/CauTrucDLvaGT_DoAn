namespace CTDL_EV_Dictionary_Hash
{
    partial class AddWord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddWord));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.addMeaningBox = new System.Windows.Forms.RichTextBox();
            this.AddBt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.addNewKey = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addNewKey);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.addMeaningBox);
            this.panel1.Controls.Add(this.AddBt);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 363);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Meaning and Explaination";
            // 
            // addMeaningBox
            // 
            this.addMeaningBox.Location = new System.Drawing.Point(7, 77);
            this.addMeaningBox.Name = "addMeaningBox";
            this.addMeaningBox.Size = new System.Drawing.Size(598, 248);
            this.addMeaningBox.TabIndex = 1;
            this.addMeaningBox.Text = "";
            // 
            // AddBt
            // 
            this.AddBt.Location = new System.Drawing.Point(260, 331);
            this.AddBt.Name = "AddBt";
            this.AddBt.Size = new System.Drawing.Size(75, 23);
            this.AddBt.TabIndex = 0;
            this.AddBt.Text = "Add";
            this.AddBt.UseVisualStyleBackColor = true;
            this.AddBt.Click += new System.EventHandler(this.AddBt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Word";
            // 
            // addNewKey
            // 
            this.addNewKey.Location = new System.Drawing.Point(7, 21);
            this.addNewKey.Name = "addNewKey";
            this.addNewKey.ReadOnly = true;
            this.addNewKey.Size = new System.Drawing.Size(595, 20);
            this.addNewKey.TabIndex = 5;
            // 
            // AddWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 381);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddWord";
            this.Text = "Add New Word";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddBt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox addNewKey;
        public System.Windows.Forms.RichTextBox addMeaningBox;
    }
}