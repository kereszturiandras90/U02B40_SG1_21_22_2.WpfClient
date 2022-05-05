
using System.Collections.Generic;
using U02B40_HFT_2021221.WpfClient.Models;

namespace U02B40_HFT_2021221.WpfClient.BL.Interfaces
{
    public interface ITransactionHandlerService
    {
        void AddTransaction(IList<TransactionModel> collection);
        void ModifyTransaction(IList<TransactionModel> collection, TransactionModel transaction);
        void DeleteTransaction(IList<TransactionModel> collection, TransactionModel transaction);
        void ViewTransaction(TransactionModel transaction);

        IList<TransactionModel> GetAll();

        IList<AccountModel> GetAllAccounts();

        IList<CurrencyModel> GetAllCurrencies();

        IList<TypeModel> GetAllTypes();
    }
}
