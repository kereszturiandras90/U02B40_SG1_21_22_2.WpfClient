﻿
using U02B40_HFT_2021221.WpfClient;
using U02B40_HFT_2021221.WpfClient.BL.Interfaces;
using U02B40_HFT_2021221.WpfClient.Models;


namespace U02B40_HFT_2021221.WpfClient
{
    public class TransactionEditorViaWindowService : ITransactionEditorService
    {
        public TransactionModel EditTransaction(TransactionModel transaction)
        {
            var window = new TransactionEditorWindow(transaction);

            if (window.ShowDialog() == true)
            {
                return window.Transaction;
            }

            return null;
        }
    }
}
