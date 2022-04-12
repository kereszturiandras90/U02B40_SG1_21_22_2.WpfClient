
using U02B40_HFT_2021221.WpfClient;
using U02B40_HFT_2021221.WpfClient.BL.Interfaces;
using U02B40_HFT_2021221.WpfClient.Models;


namespace U0240_HFT_2021221.WpfClient
{
    public class TransactionEditorViaWindowService : ITransactionEditorService
    {
        public TransactionModel EditTransaction(TransactionModel Transaction)
        {
            var window = new TransactionEditorWindow(Transaction);

            if (window.ShowDialog() == true)
            {
                return window.Transaction;
            }

            return null;
        }
    }
}
