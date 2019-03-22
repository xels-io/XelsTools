using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToTreeView
{
    public class Transaction
    {
        public string id { get; set; }
        public string amount { get; set; }
        public string blockHash { get; set; }
        public string blockHeight { get; set; }
        public string index { get; set; }
        public string scriptPubKey { get; set; }
        public string isPropagated { get; set; }

        public List<Payment> toPay { get; set; }
        public List<Transaction> ChildTx { get; set; }
    }

    public partial class Payment
    {
        [JsonProperty("destinationScriptPubKey")]
        public string DestinationScriptPubKey { get; set; }

        [JsonProperty("destinationAddress")]
        public string DestinationAddress { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }
    }
    public class SpendingDetails
    {
        public string transactionId { get; set; }

        [JsonProperty("payments")]
        public Payment[] payments { get; set; }
        public string blockHeight { get; set; }
        public string isCoinStake { get; set; }
        public string creationTime { get; set; }
    }
    public class Root
    {
        public string id { get; set; }
        public string amount { get; set; }
        public string index { get; set; }
        public string blockHeight { get; set; }
        public string blockHash { get; set; }
        public string creationTime { get; set; }
        public string scriptPubKey { get; set; }
        public string isPropagated { get; set; }
        public SpendingDetails spendingDetails { get; set; }
    }

    class Program
    {
        Program()
        {
        }
        public void FindChild(List<Root> flatObjects, Dictionary<string, string> myDictionary, int index,ref Transaction tx2,string ParentId, string ParentIndex , string ChildId = null)
        {

            for (int i = index + 1; i < flatObjects.Count; i++) 
            {

                if (flatObjects[i].id == ChildId)
                {

                    if (tx2.id == ParentId)
                    {
                        tx2=(ConstructTransaction(flatObjects[i], tx2));

                        if (!myDictionary.ContainsKey(flatObjects[i].id))
                            myDictionary.Add(flatObjects[i].id, flatObjects[i].index);
                    }
                    else
                    {
                        foreach (var ob in tx2.ChildTx)
                        {
                            if (ob.id == ParentId && ob.index== ParentIndex)
                            {
                                ConstructTransaction(flatObjects[i], ob);

                                if (!myDictionary.ContainsKey(flatObjects[i].id))
                                    myDictionary.Add(flatObjects[i].id, flatObjects[i].index);

                            }

                        }

                    }           

                    int ind = flatObjects.IndexOf(flatObjects[i]);
                    if (flatObjects[i].spendingDetails != null)
                    {
                        string ParentId2 = flatObjects[i].id;
                        string ParentIndex2 = flatObjects[i].index;
                        FindChild(flatObjects, myDictionary, ind,ref tx2, ParentId2 , ParentIndex2 , flatObjects[i].spendingDetails.transactionId);
                    }
                }

            }
        }


        static void Main(string[] args)
        {
            Program p = new Program();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<Transaction> listTransactions = new List<Transaction>();
            //List<Root> root = JsonConvert.DeserializeObject<List<Root>>(File.ReadAllText(@"C:\Users\Jishu\Desktop\jishu(edited).txt"));
            List<Root> root = JsonConvert.DeserializeObject<List<Root>>(File.ReadAllText(@"C:\Users\Jishu\Desktop\Childtree.txt"));

            //int index = root.Count();
            foreach (var item in root)
            {
                string ParentId, Parentindex;
                if (!dict.ContainsKey(item.id))
                {

                    dict.Add(item.id, item.index);

                    Transaction tx1 = p.ConstructTransaction(item);

                    if (item.spendingDetails != null)
                    {
                        ParentId = item.id;
                        Parentindex = item.index;
                        int ind = root.IndexOf(item);
                        p.FindChild(root, dict, ind, ref tx1, ParentId, Parentindex, item.spendingDetails.transactionId);

                    }
                    listTransactions.Add(tx1);

                }
                
            }

            bool fileResult=false;
            try
            {
                var json = JsonConvert.SerializeObject(listTransactions, Formatting.Indented);
                System.IO.File.WriteAllText(@"C:\Users\Jishu\Desktop\Result.txt", json);
                fileResult = true;
            }
            catch (Exception e)
            {
                fileResult = false;
            }

            if(fileResult==true)
             Console.WriteLine("written sucessfully");

            Console.ReadKey();
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

               
                if (root1.spendingDetails != null)
                {
                    int paymentLength = root1.spendingDetails.payments.Length;
                    tx.toPay = new List<Payment>();
                    for (int i=0;i< paymentLength; i++)
                    {
                        if (root1.spendingDetails.payments[i]!=null)
                        tx.toPay.Add(root1.spendingDetails.payments[i]);
                    }
                }

                tx.ChildTx = new List<Transaction>();

            }
            else
            {
                tx.ChildTx.Add(ConstructTransaction(root1));
            }
            return tx;
        }

    }

}
