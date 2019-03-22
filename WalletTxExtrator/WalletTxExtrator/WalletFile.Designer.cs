namespace WalletTxExtrator
{
    partial class WalletFile
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
            this.searchText = new System.Windows.Forms.Button();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(27, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1159, 455);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(1110, 19);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(75, 23);
            this.searchText.TabIndex = 1;
            this.searchText.Text = "Search";
            this.searchText.UseVisualStyleBackColor = true;
            this.searchText.Click += new System.EventHandler(this.searchText_Click);
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(681, 22);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(409, 20);
            this.txt_Search.TabIndex = 2;
            // 
            // WalletFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 531);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.richTextBox1);
            this.Name = "WalletFile";
            this.Text = "WalletFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button searchText;
        private System.Windows.Forms.TextBox txt_Search;
    }
}