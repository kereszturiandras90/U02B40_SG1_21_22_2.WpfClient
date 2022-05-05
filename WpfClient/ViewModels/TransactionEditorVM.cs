
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;
using U02B40_HFT_2021221.WpfClient.Models;
using U02B40_HFT_2021221.WpfClient.BL.Interfaces;
using System;
using System.Collections;

namespace U02B40_HFT_2021221.WpfClient.ViewModels
{
    public class TransactionEditorVM : ViewModelBase
    {
        private TransactionModel currentTransaction;

        public TransactionModel CurrentTransaction
        {
            get { return currentTransaction; }
            set 
            {
                Set(ref currentTransaction, value);
              SelectedAccount = AvailableAccounts?.SingleOrDefault(x => x.Id == currentTransaction.AccountId);
                SelectedCurrency = AvailableCurrencies?.SingleOrDefault(x => x.Currency == currentTransaction.Currency);
                SelectedType = AvailableTypes?.SingleOrDefault(x => x.Type == currentTransaction.Type);
            }
        }

        private AccountModel accountModel;

        public AccountModel SelectedAccount
        {
            get { return accountModel; }
            set
            {
                Set(ref accountModel, value);
                currentTransaction.AccountId = accountModel?.Id ?? 0;
            }
        }


        private CurrencyModel currencyModel;

        public CurrencyModel SelectedCurrency
        {
            get { return currencyModel; }
            set
            {
                Set(ref currencyModel, value);
                currentTransaction.Currency = currencyModel?.Currency ?? "USD";
            }
        }


        private TypeModel typeModel;

        public TypeModel SelectedType
        {
            get { return typeModel; }
            set
            {
                Set(ref typeModel, value);
                currentTransaction.Type = typeModel?.Type ?? "INT";
            }
        }

        public IList<AccountModel> AvailableAccounts { get; private set; }

        public IList<CurrencyModel> AvailableCurrencies { get; private set; }

        public IList<TypeModel> AvailableTypes { get; private set; }

        //  private BrandModel brandModel;

        /*   public BrandModel SelectedBrand
           {
               get { return brandModel; }
               set {
                   Set(ref brandModel, value);
                   currentTransaction.BrandId = brandModel?.Id ?? 0;
               }
           }*/

        // public IList<BrandModel> AvailableBrands { get; private set; }

        private bool editEnabled;

        public bool EditEnabled
        {
            get { return editEnabled; }
            set 
            { 
                Set(ref editEnabled, value);
                RaisePropertyChanged(nameof(CancelButtonVisibility));
            }
        }

        public System.Windows.Visibility CancelButtonVisibility => EditEnabled ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

        public TransactionEditorVM(ITransactionHandlerService TransactionHandlerService)
        {
            CurrentTransaction = new TransactionModel();

            if (CurrentTransaction.TransferTime == new DateTime(0001, 01, 01))
            {
                CurrentTransaction.TransferTime = DateTime.Today;
            }

            AvailableAccounts =   TransactionHandlerService.GetAllAccounts();

            AvailableCurrencies = TransactionHandlerService.GetAllCurrencies();

            AvailableTypes = TransactionHandlerService.GetAllTypes();



            /* if (IsInDesignModeStatic)
             {
                 AvailableBrands = new List<BrandModel>()
                 {
                     new BrandModel(1, "Mazda"),
                     new BrandModel(2, "Opel"),
                     new BrandModel(3, "BMW"),
                 };

                 SelectedBrand = AvailableBrands[1]; // Should sets the brandId too
                 CurrentTransaction.Model = "Astra G";
                 CurrentTransaction.Price = 1750;
             }
             else
             {
               //  AvailableBrands = TransactionHandlerService.GetAllBrands();
             }*/
        }

        public TransactionEditorVM() : this(IsInDesignModeStatic ? null: ServiceLocator.Current.GetInstance<ITransactionHandlerService>())
        {
        }
    }
}
