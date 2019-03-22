namespace WalletTxExtrator
{
    partial class TransactionTextFile
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.search_Click = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(23, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1116, 461);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(646, 22);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(402, 20);
            this.txt_Search.TabIndex = 1;
            // 
            // search_Click
            // 
            this.search_Click.Location = new System.Drawing.Point(1063, 19);
            this.search_Click.Name = "search_Click";
            this.search_Click.Size = new System.Drawing.Size(75, 23);
            this.search_Click.TabIndex = 2;
            this.search_Click.Text = "Search";
            this.search_Click.UseVisualStyleBackColor = true;
            this.search_Click.Click += new System.EventHandler(this.search_Click_Click);
            // 
            // TransactionTextFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 521);
            this.Controls.Add(this.search_Click);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.richTextBox1);
            this.Name = "TransactionTextFile";
            this.Text = "TransactionTextFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button search_Click;
    }
}