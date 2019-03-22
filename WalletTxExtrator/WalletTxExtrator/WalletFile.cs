using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalletTxExtrator
{
    public partial class WalletFile : Form
    {
        public WalletFile(string filepath)
        {
            InitializeComponent();

            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
                string s = File.ReadAllText(filepath);
                richTextBox1.Text = s;
            

        }

        private void searchText_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.Text != string.Empty)
                {// if the ritchtextbox is not empty; highlight the search criteria
                    int index = 0;
                    String temp = richTextBox1.Text;
                    richTextBox1.Text = "";
                    richTextBox1.Text = temp;
                    while (index < richTextBox1.Text.LastIndexOf(txt_Search.Text))
                    {
                        richTextBox1.Find(txt_Search.Text, index, richTextBox1.TextLength, RichTextBoxFinds.None);
                        richTextBox1.SelectionBackColor = Color.Yellow;
                        index = richTextBox1.Text.IndexOf(txt_Search.Text, index) + 1;
                        richTextBox1.Select();
                    }
                }
            }

            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }

    }
}
