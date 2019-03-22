using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletTxExtrator
{
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
        public class Transaction
        {
            public string id { get; set; }
            public string amount { get; set; }
            public string blockHash { get; set; }
            public string blockHeight { get; set; }
            public string index { get; set; }
            public string scriptPubKey { get; set; }
            public string isPropagated { get; set; }
            
            public string creationTime { get; set; }
            public List<Payment> toPay { get; set; }
            public List<Transaction> ChildTx { get; set; }
            public Transaction()
            {
                ChildTx = new List<Transaction>();

            }
    }

    
}
