using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalletTxExtrator
{
    public partial class XelsWalletInputFile : Form
    {
        //List<dynamic> root = new List<dynamic>();
        dynamic root;
        List<object> Externallist = new List<object>();
        List<object> Internallist = new List<object>();
        List<object> Conbinelist = new List<object>();
        List<string> FilePathlist = new List<string>();
       public struct ListElement
        {
            public string TxId;
            public string TxIndex;
        }
        ListElement listElement;
        List<Transaction> listTransactions = new List<Transaction>();
        public List<ListElement> Usedtransactions = new List<ListElement>();
        string filename;
        public XelsWalletInputFile()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenJasonWallet = new OpenFileDialog();

            OpenJasonWallet.InitialDirectory = @"C:\";
            OpenJasonWallet.Title = "Browse Text Files";

            OpenJasonWallet.CheckFileExists = true;
            OpenJasonWallet.CheckPathExists = true;

            OpenJasonWallet.DefaultExt = "txt";
            OpenJasonWallet.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            OpenJasonWallet.FilterIndex = 2;
            OpenJasonWallet.RestoreDirectory = true;

            OpenJasonWallet.ReadOnlyChecked = true;
            OpenJasonWallet.ShowReadOnly = true;

            if (OpenJasonWallet.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                flpSelectedFiles.Controls.Clear();
                string path = OpenJasonWallet.FileName;
                FilePathlist.Add(path);
                filename = Path.GetFileNameWithoutExtension(path);
                textBox1.Text = path;
                //MessageBox.Show(path);
                //var jsonText = File.ReadAllText(path);

                using (StreamReader r = new StreamReader(path))
                {

                    string json = r.ReadToEnd();
                    if (json != null)
                    {
                        string fileName2 = String.Concat(filename, ".json");
                        string foldername = "XelsWalletFolder";
                        if (!Directory.Exists(@"C:/test/" + foldername))
                            Directory.CreateDirectory(@"C:/test/" + foldername);

                        if(!File.Exists(@"C:/test/XelsWalletFolder/" + fileName2))
                        {
                            System.IO.File.WriteAllText(@"C:/test/XelsWalletFolder/" + fileName2, json);
                        }

                        try
                        {
                            //if (root.Count == 0)
                            //root.Add(JsonConvert.DeserializeObject<Wallet>(json));
                            root = JsonConvert.DeserializeObject<Wallet>(json);
                            json = "";

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.GetType().FullName + Environment.NewLine + "Please enter correct Json file");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data formate is not Correct. Please enter correct Formate. ");
                    }
                }

                //int rootLength = root.Count;

                if (root!= null)
                {
                    
                        int countExternal = root.AccountsRoot[0].Accounts[0].ExternalAddresses.Length;

                        for (int i = 0; i < countExternal; i++)
                        {
                            Externallist.AddRange(root.AccountsRoot[0].Accounts[0].ExternalAddresses[i].Transactions);
                        }

                        int countInternal = root.AccountsRoot[0].Accounts[0].InternalAddresses.Length;

                        for (int j = 0; j < countInternal; j++)
                        {
                            Internallist.AddRange(root.AccountsRoot[0].Accounts[0].InternalAddresses[j].Transactions);
                        }
                        //label2.ForeColor = Color.Blue;
                        //label2.Text = "Sucessfully added" +" "+ filename +" "+ "file";

                        int fileNumber=FilePathlist.Count;

                        Button[] button = new Button[fileNumber];
                        Label[] labels = new Label[fileNumber];
                         for (int m=0;m<fileNumber;m++)
                         {
                            labels[m] = new Label();
                            labels[m].Text = Path.GetFileNameWithoutExtension(FilePathlist[m]);
                            labels[m].Name = Convert.ToString(m);
                            //labels[m].Location = new System.Drawing.Point(mlX, mY);
                            labels[m].ForeColor = Color.Blue;
                            labels[m].Click += new EventHandler(btn_Click);
                           }
                        for (int i = 0; i < fileNumber; i++)
                        {
                            flpSelectedFiles.Controls.Add(labels[i]);
                            //this.Controls.Add(labels[i]);
                        }

                        root = null;
                        writeText();
                   
                }
            }
            else
                MessageBox.Show("Please Enter Right File");

        }

        void btn_Click(object sender, EventArgs e)
        {
            var s = (sender as Label).Name;
            int id = Convert.ToInt32(s);

            string fileToOpen = FilePathlist[id];
            var existityCheck = File.Exists(fileToOpen) ? "Yes" : "No";

            if (existityCheck == "No")
                MessageBox.Show("File does not exist. Please Browse a file");
            else
            {
                WalletFile wf = new WalletFile(fileToOpen);
                wf.Show();
            }

        }

        public void writeText()
        {

            if (Externallist != null || Internallist != null)
            {
                Conbinelist.AddRange(Externallist);
                Conbinelist.AddRange(Internallist);
                Externallist.Clear();
                Internallist.Clear();
                var result = JsonConvert.SerializeObject(Conbinelist, Formatting.Indented);

                string fileName3 = String.Concat("transactionFile", ".txt");
                string foldername = "XelsWalletFolder";

                if (File.Exists(@"C:/test/XelsWalletFolder/" + fileName3))
                {
                    File.Delete(@"C:/test/XelsWalletFolder/" + fileName3);
                }

                if (!Directory.Exists(@"C:/test/" + foldername))
                     Directory.CreateDirectory(@"C:/test/" + foldername);

                System.IO.File.WriteAllText(@"C:/test/XelsWalletFolder/" + fileName3, result + Environment.NewLine);
               
                //MessageBox.Show("Write sucessfully");
            }

        }

        private void showText_Click(object sender, EventArgs e)
        {
            var fileToOpen = "C:/test/XelsWalletFolder/transactionFile.txt";
            var existityCheck = File.Exists(fileToOpen) ? "Yes" : "No";

            if (existityCheck == "No")
                MessageBox.Show("File does not exist. Please Browse a file");
            else
            {
                TransactionTextFile ttf = new TransactionTextFile();
                ttf.Show();
            }


        }

        private void gorelatorfile_Click(object sender, EventArgs e)
        {
            //var fileToOpen = "C:/test/XelsWalletFolder/transactionFile.txt";
            //var existityCheck = File.Exists(fileToOpen) ? "Yes" : "No";

            //if (existityCheck == "No")
            //    MessageBox.Show("File does not exist. Please Browse a file");
            //else
            //{
                XelsWalletInputFile p = new XelsWalletInputFile();
                //Dictionary<string, string> dict = new Dictionary<string, string>();
               
                List<Root> root = new List<Root>();

                string path = "C:/test/XelsWalletFolder/transactionFile.txt";


                using (StreamReader r = new StreamReader(path))
                {
                    string json1 = r.ReadToEnd();
                    try
                    {
                        root = JsonConvert.DeserializeObject<List<Root>>(json1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.GetType().Name);
                    }
                }

            //var topNode = new TreeNode("All Transaction");
            //treeView1.Nodes.Add(topNode);

            //List<Root> root = JsonConvert.DeserializeObject<List<Root>>(File.ReadAllText(@"C:\Users\Jishu\Desktop\jishu(edited).txt"));

            //int index = root.Count();

            if (root != null)
            {
                    foreach (var item in root)
                    {
                        string ParentId, Parentindex;
                        listElement.TxId = item.id;
                        listElement.TxIndex = item.index;
                        if (!Usedtransactions.Contains(listElement))
                        {
                            Usedtransactions.Add(listElement);
                       
                            Transaction tx1 = p.ConstructTransaction(item);
                            //TreeNode tn = p.ConstructTreeNode(item);

                            if (item.spendingDetails != null)
                            {
                                ParentId = item.id;
                                Parentindex = item.index;
                                int ind = root.IndexOf(item);
                                //p.FindChild(root, dict, ind, ref tx1,ref tn, ParentId, Parentindex, item.spendingDetails.TransactionId);
                                p.FindChild(root,ref Usedtransactions, ref listTransactions, ind, ref tx1, ParentId, Parentindex, item.spendingDetails.TransactionId);
                            }
                            listTransactions.Add(tx1);
                            //treeView1.Nodes.Add(tx1.id);
                        }
                    }


                    FormTreeView treeview = new FormTreeView(listTransactions);
                    treeview.ShowDialog();
                }
            
        }

        public Transaction ConstructTransaction(Root root1, Transaction tx = null)
        {

            if (tx == null)
            {
                tx = new Transaction();
                tx.id = root1.id;
                tx.index = root1.index;
                tx.isPropagated = root1.isPropagated;
                tx.scriptPubKey = root1.scriptPubKey;
                tx.amount = root1.amount;
                tx.blockHash = root1.blockHash;
                tx.blockHeight = root1.blockHeight;
                tx.creationTime = root1.creationTime;

                if (root1.spendingDetails != null)
                {
                    int paymentLength = root1.spendingDetails.Payments.Length;
                    tx.toPay = new List<Payment>();
                    for (int i = 0; i < paymentLength; i++)
                    {
                        if (root1.spendingDetails.Payments[i] != null)
                        {
                            tx.toPay.Add(root1.spendingDetails.Payments[i]);

                        }
                    }
                }

                //tx.ChildTx = new List<Transaction>();

                //treeNodes.Add(new TreeNode(tx.id, childNodes.ToArray()));
                //childNodes = new List<TreeNode>();

            }
            else
            {
                tx.ChildTx.Add(ConstructTransaction(root1));
            }
            return tx;
        }

        void iterateChild(List<Transaction> t,string ParentId,string ParentIndex, Root flatObjects, ref List<ListElement> Usedtransactions, ref List<Transaction> listTransactions)
        {
            int n = t.Count;
            if (n != 0)
            {
                foreach (Transaction ob in t)
                {
                    if (ob.id == ParentId && ob.index == ParentIndex)
                    {
                        int countTransaction = listTransactions.Count;
                        for(int i=0;i<countTransaction;i++)
                        {
                            if(listTransactions[i].id== ob.id && listTransactions[i].index == ob.index)
                            {
                                listTransactions.RemoveAt(i);
                                listElement.TxId = ob.id;
                                listElement.TxIndex = ob.index;
                                if (Usedtransactions.Contains(listElement))
                                {
                                    Usedtransactions.Remove(listElement);
                                }
                            }
                        }
                        ConstructTransaction(flatObjects, ob);
                        listElement.TxId = flatObjects.id;
                        listElement.TxIndex = flatObjects.index;
                        if (!Usedtransactions.Contains(listElement))
                        {
                            Usedtransactions.Add(listElement);
                        }

                    }
                    iterateChild(ob.ChildTx, ParentId, ParentIndex, flatObjects,ref Usedtransactions, ref listTransactions);
                }
            }
            
        }
        public void FindChild(List<Root> flatObjects,ref List<ListElement> Usedtransactions,ref List<Transaction> listTransactions, int index, ref Transaction tx2, string ParentId, string ParentIndex, string ChildId = null)
        {

            
            for (int i = 0; i < flatObjects.Count; i++)
            {
                if (flatObjects[i].id == ChildId)
                {

                    if (tx2.id == ParentId)
                    {
                        for (int x = 0; x < listTransactions.Count; x++)
                        {
                            if (listTransactions[x].id == flatObjects[i].id && listTransactions[x].index == flatObjects[i].index)
                            {
                                listTransactions.RemoveAt(x);
                                listElement.TxId = flatObjects[i].id;
                                listElement.TxIndex = flatObjects[i].index;
                                if (Usedtransactions.Contains(listElement))
                                {
                                    Usedtransactions.Remove(listElement);
                                }
                            }
                        }

                        tx2 = (ConstructTransaction(flatObjects[i], tx2));
                        //tn2=ConstructTreeNode(flatObjects[i],tn2);
                        listElement.TxId = flatObjects[i].id;
                        listElement.TxIndex = flatObjects[i].index;
                        if (!Usedtransactions.Contains(listElement))
                        {
                            Usedtransactions.Add(listElement);
                        }
                    }
                    else
                    {
                        for (int x = 0; x < listTransactions.Count; x++)
                        {
                            if (listTransactions[x].id == flatObjects[i].id && listTransactions[x].index == flatObjects[i].index)
                            {
                                listTransactions.RemoveAt(x);
                                listElement.TxId = flatObjects[i].id;
                                listElement.TxIndex = flatObjects[i].index;
                                if (Usedtransactions.Contains(listElement))
                                {
                                    Usedtransactions.Remove(listElement);
                                }
                            }
                        }

                        iterateChild(tx2.ChildTx, ParentId, ParentIndex, flatObjects[i],ref Usedtransactions, ref listTransactions);

                    }

                    int ind = flatObjects.IndexOf(flatObjects[i]);
                    if (flatObjects[i].spendingDetails != null)
                    {
                        string ParentId2 = flatObjects[i].id;
                        string ParentIndex2 = flatObjects[i].index;
                        //FindChild(flatObjects, myDictionary, ind, ref tx2, ref tn2 , ParentId2, ParentIndex2, flatObjects[i].spendingDetails.TransactionId);
                        FindChild(flatObjects,ref Usedtransactions, ref listTransactions, ind, ref tx2, ParentId2, ParentIndex2, flatObjects[i].spendingDetails.TransactionId);
                    }
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

   
}
