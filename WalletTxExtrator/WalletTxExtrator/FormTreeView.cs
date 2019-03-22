using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WalletTxExtrator
{
    public partial class FormTreeView : Form
    {
        List<Transaction> listTransactions = new List<Transaction>();
        List<TreeNode> treeNodes = new List<TreeNode>();
        //List<TreeNode> childNodes = new List<TreeNode>();
        public FormTreeView(List<Transaction> ListTransactions)
        {
            //ConfigLists.OrderBy(x => x, weekComparer).ToList();
            listTransactions = ListTransactions.OrderByDescending(x => x.ChildTx.Count>0).ToList();
            InitializeComponent();
            treeView1.TabStop = false;

            treeView1.NodeMouseClick +=
               new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
            MakeTree();
            //write_show();
            treeView1.ExpandAll();

        }

        void findChild( Transaction tx1 , string id1, string index1)
        {
            if((tx1.id== id1)&& (tx1.index == index1))
            {
                string s = tx1.creationTime;
                long t = Convert.ToInt32(s);
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime CreationTime=origin.AddSeconds(t);

                textBox1.Text = tx1.id;
                textBox2.Text = tx1.index;
                textBox3.Text = tx1.scriptPubKey;
                textBox4.Text = tx1.amount;
                textBox5.Text = tx1.blockHash;
                textBox6.Text = tx1.blockHeight;

                textBox7.Text = tx1.isPropagated;
                textBox8.Text = CreationTime.ToString();
                
                
                if (tx1.toPay != null)
                {
                    int g=tx1.toPay.Count;
                    for (int j = 0; j < g; j++)
                    {
                        richTextBox1.Text += tx1.toPay[j].Amount+"  " + "xels" + "   " + "sends" + "   " + "to" + "   " + tx1.toPay[j].DestinationAddress+ "   " + "destination" + Environment.NewLine ;
                    }
                }
                else
                    richTextBox1.Text = "null" +Environment.NewLine;
            }
            else
            {
                if (tx1.ChildTx.Count > 0)
                {
                    for (int j = 0; j < tx1.ChildTx.Count; j++)
                    {
                        findChild(tx1.ChildTx[j], id1, index1);
                    }

                }

            }
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int n = listTransactions.Count;
            for (int i = 0; i < n; i++)
            {
                if((listTransactions[i].id == e.Node.Text) && (listTransactions[i].index == Convert.ToString(e.Node.Tag)))
                {
                    string s = listTransactions[i].creationTime;
                    long t = Convert.ToInt32(s);
                    DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    DateTime CreationTime = origin.AddSeconds(t);

                    textBox1.Text = listTransactions[i].id;
                    textBox2.Text = listTransactions[i].index;
                    textBox3.Text = listTransactions[i].scriptPubKey;
                    textBox4.Text = listTransactions[i].amount;
                    
                    textBox5.Text = listTransactions[i].blockHash;
                    textBox6.Text = listTransactions[i].blockHeight;
                    textBox7.Text = listTransactions[i].isPropagated;
                    textBox8.Text = CreationTime.ToString();

                    richTextBox1.Clear();

                    if (listTransactions[i].toPay != null)
                    { 
                        if(listTransactions[i].toPay.Count>0)
                        {
                            int k = listTransactions[i].toPay.Count;

                            for(int j=0;j<k;j++)
                            {
                                richTextBox1.Text +=listTransactions[i].toPay[j].Amount +"  "+"xels"+ "   "+"sent"+"   " + "to" + "   " + listTransactions[i].toPay[j].DestinationAddress+ "   " + "destination" + Environment.NewLine;
                            }

                        }
                    }
                    else
                        richTextBox1.Text = "null" + Environment.NewLine;

                }
                else
                {

                    foreach (Transaction tx in listTransactions[i].ChildTx)
                    {
                        findChild(tx, e.Node.Text, Convert.ToString(e.Node.Tag));

                    }

                }
            }

        }

        void AddNode(Transaction tx , TreeNode inTreeNode)
        {
            //TreeNode parentnode = inTreeNode;
            //var childNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode
            //{
            //    Text = tx.id,
            //    Tag = tx.index
            //})];


            TreeNode child = new TreeNode();
            child.Text = tx.id;
            child.Tag = tx.index;


            inTreeNode.Nodes.Add(child);
            if (tx.ChildTx.Count > 0)
            {
                //TreeNode parentnode = childNode;
                for (int j = 0; j < tx.ChildTx.Count; j++)
                {
                    AddNode(tx.ChildTx[j], child);
                }

            }
           

        }
        public void MakeTree()
        {


            //var topNode = new TreeNode("All Transaction");
            //treeView1.Nodes.Add(topNode);



            int n = listTransactions.Count;
            treeView1.Nodes.Clear();

            //var topNode = new TreeNode("All Transaction");
            //treeView1.Nodes.Add(topNode);

            for (int i = 0; i < n; i++)
            {

                TreeNode parentNode = new TreeNode();


                parentNode.Text = listTransactions[i].id;
                parentNode.Tag = listTransactions[i].index;


                treeView1.Nodes.Add(parentNode);

                //if (listTransactions[i].ChildTx.Count > 0)
                //{
                //    treeView1.Nodes.Add(parentNode);
                //}
                //else
                //    treeView2.Nodes.Add(parentNode);

                //var tNode = treeView1.Nodes[treeView1.Nodes.Add(new TreeNode
                //{
                //    Text = listTransactions[i].id,
                //    Tag = listTransactions[i].index,
                //})];


                if (listTransactions[i].ChildTx.Count > 0)
                {
                    foreach (Transaction tx in listTransactions[i].ChildTx)
                    {
                        AddNode(tx, parentNode);

                    }
                  
                }
                //treeView2.ExpandAll();
                //treeView1.Nodes[0].Nodes.AddRange(treeNodes.ToArray());

            }

            //TreeNode nodes = this.treeView2.Clone() as TreeNode;

            //this.treeView1.Nodes.Add(nodes);

        }

    }
}
