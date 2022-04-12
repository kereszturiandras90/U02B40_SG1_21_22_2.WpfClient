using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.WpfClient.Models
{
    public class TransactionModel: ObservableObject
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { Set(ref type, value); }
        }

        private DateTime transferTime;

        public DateTime TransferTime
        {
            get { return transferTime; }
            set { Set(ref transferTime, value); }
        }

        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set { Set(ref amount, value); }
        }

        private string currency;

        public string Currency
        {
            get { return currency; }
            set { Set(ref currency, value); }
        }

        private int accountId;

        public int AccountId
        {
            get { return accountId; }
            set { Set(ref accountId, value); }
        }

        public TransactionModel()
        {

        }

        public TransactionModel(int id, string type, DateTime transferTime, decimal amount, string currency, int accountId)
        {
            this.id = id;
            this.type = type;
            this.transferTime = transferTime;
            this.amount = amount;
            this.currency = currency;
            this.accountId = accountId;
        }

        public TransactionModel(TransactionModel other)
        {
            id = other.Id;
            type = other.Type;
            transferTime = other.TransferTime;
            amount = other.Amount;
            currency = other.Currency;
            accountId = other.AccountId;

        }
    }
}
