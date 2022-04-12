
using U02B40_HFT_2021221.WpfClient.Models;

namespace U02B40_HFT_2021221.WpfClient.BL.Interfaces
{
    public interface ITransactionEditorService
    {
        TransactionModel EditTransaction(TransactionModel transaction);
    }
}
