using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletTxExtrator
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
        public Transaction2[] Transactions { get; set; }
    }

    public partial class Transaction2
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
}
