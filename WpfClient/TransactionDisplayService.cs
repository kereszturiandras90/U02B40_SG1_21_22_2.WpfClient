using U02B40_HFT_2021221.WpfClient;
using U02B40_HFT_2021221.WpfClient.BL.Interfaces;
using U02B40_HFT_2021221.WpfClient.Models;


namespace U0240_HFT_2021221.WpfClient
{
    public class TransactionDisplayService : ITransactionDisplayService
    {
        public void Display(TransactionModel transaction)
        {
            var window = new TransactionEditorWindow(transaction, false);

            window.Show();
        }
    }
}
