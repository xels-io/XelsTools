using System.Windows.Forms;

namespace WalletTxExtrator
{
    partial class XelsWalletInputFile
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
            this.BrowseButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OpenJasonWallet = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.showText = new System.Windows.Forms.Button();
            this.gorelatorfile = new System.Windows.Forms.Button();
            this.flpSelectedFiles = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // BrowseButton
            // 
            this.BrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton.ForeColor = System.Drawing.Color.DarkRed;
            this.BrowseButton.Location = new System.Drawing.Point(438, 74);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(112, 27);
            this.BrowseButton.TabIndex = 0;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(403, 20);
            this.textBox1.TabIndex = 1;
            // 
            // OpenJasonWallet
            // 
            this.OpenJasonWallet.FileName = "OpenJasonWallet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepPink;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please Insert a Json Wallet File";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // showText
            // 
            this.showText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showText.ForeColor = System.Drawing.Color.Chocolate;
            this.showText.Location = new System.Drawing.Point(29, 265);
            this.showText.Name = "showText";
            this.showText.Size = new System.Drawing.Size(253, 31);
            this.showText.TabIndex = 4;
            this.showText.Text = "View all Transactions File";
            this.showText.UseVisualStyleBackColor = true;
            this.showText.Click += new System.EventHandler(this.showText_Click);
            // 
            // gorelatorfile
            // 
            this.gorelatorfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gorelatorfile.ForeColor = System.Drawing.Color.Fuchsia;
            this.gorelatorfile.Location = new System.Drawing.Point(288, 265);
            this.gorelatorfile.Name = "gorelatorfile";
            this.gorelatorfile.Size = new System.Drawing.Size(253, 31);
            this.gorelatorfile.TabIndex = 7;
            this.gorelatorfile.Text = "View Child Parent Relationship";
            this.gorelatorfile.UseVisualStyleBackColor = true;
            this.gorelatorfile.Click += new System.EventHandler(this.gorelatorfile_Click);
            // 
            // flpSelectedFiles
            // 
            this.flpSelectedFiles.AutoScroll = true;
            this.flpSelectedFiles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSelectedFiles.Location = new System.Drawing.Point(29, 117);
            this.flpSelectedFiles.Name = "flpSelectedFiles";
            this.flpSelectedFiles.Size = new System.Drawing.Size(521, 80);
            this.flpSelectedFiles.TabIndex = 9;
            // 
            // XelsWalletInputFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(569, 341);
            this.Controls.Add(this.flpSelectedFiles);
            this.Controls.Add(this.gorelatorfile);
            this.Controls.Add(this.showText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BrowseButton);
            this.Name = "XelsWalletInputFile";
            this.Text = "Xels Wallet Input File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog OpenJasonWallet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button showText;
        private System.Windows.Forms.Button gorelatorfile;
        private System.Windows.Forms.FlowLayoutPanel flpSelectedFiles;
    }
}