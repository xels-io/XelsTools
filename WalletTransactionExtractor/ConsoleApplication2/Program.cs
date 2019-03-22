using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace ConsoleApplication2
{
        public partial class Wallet
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("encryptedSeed")]
            public string EncryptedSeed { get; set; }

            [JsonProperty("chainCode")]
            public string ChainCode { get; set; }

            [JsonProperty("blockLocator")]
            public string[] BlockLocator { get; set; }

            [JsonProperty("network")]
            public string Network { get; set; }

            [JsonProperty("creationTime")]
            public string CreationTime { get; set; }

            [JsonProperty("accountsRoot")]
            public AccountsRoot[] AccountsRoot { get; set; }
        }

        public partial class AccountsRoot
        {
            [JsonProperty("coinType")]
            public string CoinType { get; set; }

            [JsonProperty("lastBlockSyncedHeight")]
            public string LastBlockSyncedHeight { get; set; }

            [JsonProperty("lastBlockSyncedHash")]
            public string LastBlockSyncedHash { get; set; }

            [JsonProperty("accounts")]
            public Account[] Accounts { get; set; }
        }

        public partial class Account
        {
            [JsonProperty("index")]
            public string Index { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("hdPath")]
            public string HdPath { get; set; }

            [JsonProperty("extPubKey")]
            public string ExtPubKey { get; set; }

            [JsonProperty("creationTime")]
            public string CreationTime { get; set; }

            [JsonProperty("externalAddresses")]
            public ExInAddress[] ExternalAddresses { get; set; }

            [JsonProperty("internalAddresses")]
            public ExInAddress[] InternalAddresses { get; set; }
        }

        public partial class ExInAddress
        {
            [JsonProperty("index")]
            public long Index { get; set; }

            [JsonProperty("scriptPubKey")]
            public string ScriptPubKey { get; set; }

            [JsonProperty("pubkey")]
            public string Pubkey { get; set; }

            [JsonProperty("address")]
            public string Address { get; set; }

            [JsonProperty("hdPath")]
            public string HdPath { get; set; }

            [JsonProperty("transactions")]
            public Transaction[] Transactions { get; set; }
        }

        public partial class Transaction
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("amount")]
            public long Amount { get; set; }

            [JsonProperty("index")]
            public long Index { get; set; }

            [JsonProperty("blockHeight")]
            public long BlockHeight { get; set; }

            [JsonProperty("blockHash")]
            public string BlockHash { get; set; }

            [JsonProperty("creationTime")]
            public string CreationTime { get; set; }

            [JsonProperty("scriptPubKey")]
            public string ScriptPubKey { get; set; }

            [JsonProperty("isPropagated")]
            public bool IsPropagated { get; set; }

            [JsonProperty("spendingDetails")]
            public SpendingDetails SpendingDetails { get; set; }
        }

        public partial class SpendingDetails
        {
            [JsonProperty("transactionId")]
            public string TransactionId { get; set; }

            [JsonProperty("payments")]
            public Payment[] Payments { get; set; }

            [JsonProperty("blockHeight")]
            public long BlockHeight { get; set; }

            [JsonProperty("creationTime")]
            public long CreationTime { get; set; }
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

        
    class Program
    {
        dynamic root;
        List<object> Externallist = new List<object>();
        List<object> Internallist = new List<object>();
        public void writeText()
        {
           
          lock (this)
            {
                if (Externallist != null || Internallist != null)
                {
                    //List<object> combinelist = new List<object>();
                    //combinelist.Add(Externallist);
                    //combinelist.AddRange(Internallist);

                    Externallist.AddRange(Internallist);

                    //var external1 = JsonConvert.SerializeObject(Externallist, Formatting.Indented);
                    //var internal1 = JsonConvert.SerializeObject(Internallist, Formatting.Indented);

                    var result = JsonConvert.SerializeObject(Externallist, Formatting.Indented);

                    System.IO.File.AppendAllText(@"C:\Users\Jishu\Desktop\jishu(edited).txt", result);
                    Console.WriteLine("Write sucessfull");
                }
            }
            
        }
        public void readText()
        {
            lock(this)
            {
               
                root = JsonConvert.DeserializeObject<Wallet>(File.ReadAllText(@"C:\Users\Jishu\Desktop\Neo.wallet.json"));
                //int count = root.AccountsRoot[0].Accounts[0].ExternalAddresses[0].Transactions.Count;
                //foreach(var tx in External + root.AccountsRoot[0].Accounts[0].ExternalAddresses[0].Transactions)
                //{
                //    External = External + tx;
                //}

                int countExternal = root.AccountsRoot[0].Accounts[0].ExternalAddresses.Length;
               
                for(int i=0;i< countExternal; i++)
                {
                    Externallist.AddRange(root.AccountsRoot[0].Accounts[0].ExternalAddresses[i].Transactions);
                }

                int countInternal= root.AccountsRoot[0].Accounts[0].InternalAddresses.Length;

                for (int j = 0; j < countInternal; j++)
                {
                    Internallist.AddRange(root.AccountsRoot[0].Accounts[0].InternalAddresses[j].Transactions);
                }
                Console.WriteLine("Read sucessfull");
            }

        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Thread tread1 = new Thread(new ThreadStart(p.readText));
            Thread tread2 = new Thread(new ThreadStart(p.writeText));
            //tread2.IsBackground = true;
            tread1.Start();
            tread1.Join();
            tread2.Start();
            tread2.Join();
            Console.ReadKey();
        }
    }
}
