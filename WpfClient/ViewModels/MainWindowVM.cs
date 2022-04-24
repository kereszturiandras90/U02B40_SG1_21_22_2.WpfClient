
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using U02B40_HFT_2021221.WpfClient.Models;
using System;
using U02B40_HFT_2021221.WpfClient.BL.Interfaces;

namespace U02B40_HFT_2021221.WpfClient.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private TransactionModel currentTransaction;

        public TransactionModel CurrentTransaction
        {
            get { return currentTransaction; }
            set { Set(ref currentTransaction, value); }
        }

        public ObservableCollection<TransactionModel> Transactions { get; private set; }

        public ICommand AddCommand { get; private set; }
        public ICommand ModifyCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ViewCommand { get; private set; }

        public ICommand LoadCommand { get; private set; }

        readonly ITransactionHandlerService transactionHandlerService;

        public MainWindowVM(ITransactionHandlerService transactionHandlerService)
        {
            this.transactionHandlerService = transactionHandlerService;
            Transactions = new ObservableCollection<TransactionModel>();

            if (IsInDesignMode)
            {
                Transactions.Add(new TransactionModel(001, "transfer", DateTime.Now, 100, "SEK", 001 ));
                Transactions.Add(new TransactionModel(002, "transfer", DateTime.Now, 1100, "EUR", 002));
                var money = new TransactionModel(003, "transfer", DateTime.Now, 200, "SEK", 003);
                Transactions.Add(money);
                Transactions.Add(new TransactionModel(001, "transfer", DateTime.Now, 500000, "JMF", 001));
                CurrentTransaction = money;
            }

            LoadCommand = new RelayCommand(() =>
            {
                var Transactions = this.transactionHandlerService.GetAll();
                Transactions.Clear();

                foreach (var Transaction in Transactions)
                {
                    Transactions.Add(Transaction);
                }
            });

            AddCommand = new RelayCommand(() => this.transactionHandlerService.AddTransaction(Transactions));
            ModifyCommand = new RelayCommand(() => this.transactionHandlerService.ModifyTransaction(Transactions, CurrentTransaction));
            DeleteCommand = new RelayCommand(() => this.transactionHandlerService.DeleteTransaction(Transactions, CurrentTransaction));
            ViewCommand = new RelayCommand(() => this.transactionHandlerService.ViewTransaction(CurrentTransaction));
        }

        public MainWindowVM() : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<ITransactionHandlerService>())
        {
        }
    }
}
