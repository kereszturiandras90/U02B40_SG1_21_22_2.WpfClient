
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Linq;
using U02B40_HFT_2021221.WpfClient.Models;
using U02B40_HFT_2021221.Models;
using U02B40_HFT_2021221.WpfClient.BL.Interfaces;
using U02B40_HFT_2021221.WpfClient.Infrastructure;
using U02B40_HFT_2021221.Models.DTOs;

namespace U02B40_HFT_2021221.WpfClient.BL.Implementations
{
    public class TransactionHandlerService : ITransactionHandlerService
    {
        readonly IMessenger messenger;
        readonly ITransactionEditorService editorService;
        readonly ITransactionDisplayService transactionDisplayService;
        HttpServices httpService;

        public TransactionHandlerService(IMessenger messenger, ITransactionEditorService editorService, ITransactionDisplayService transactionDisplayService) // Should come from IoC <- dependency injection
        {
            this.messenger = messenger;
            this.editorService = editorService;
            this.transactionDisplayService = transactionDisplayService;
            httpService = new HttpServices("Transaction", "http://localhost:60195/api/"); // This can be taken via IoC in the future
        }

        public void AddTransaction(IList<TransactionModel> collection)
        {
            TransactionModel transactionToEdit = null;
            bool operationFinished = false;

            do
            {
                var newTransaction = editorService.EditTransaction(transactionToEdit);

                if (newTransaction != null)
                {
                    //newTransaction.TransferTime = System.DateTime.Now;
                    var operationResult = httpService.Create(new TransactionDTO()
                    {
                        Id = newTransaction.Id,
                        Amount = newTransaction.Amount,
                        Currency = newTransaction.Currency,
                        AccountId = newTransaction.AccountId,
                        TransferTime = newTransaction.TransferTime,
                        Type = newTransaction.Type
                    }) ;

                    transactionToEdit = newTransaction;
                    operationFinished = operationResult.IsSuccess;

                    if (operationResult.IsSuccess)
                    {
                       // collection.Add(newTransaction);
                        RefreshCollectionFromServer(collection);

                        SendMessage("Transaction add was successful");
                    }
                    else
                    {
                        SendMessage(operationResult.Messages.ToArray());
                    }
                }
                else
                {
                    SendMessage("Transaction add has cancelled");
                    operationFinished = true;
                }
            } while (!operationFinished);
        }

        private void RefreshCollectionFromServer(IList<TransactionModel> collection)
        {
            collection.Clear();
            var newTransactions = GetAll();

            foreach (var Transaction in newTransactions)
            {
                collection.Add(Transaction);
            }
        }

        private void SendMessage(params string[] messages)
        {
            messenger.Send(messages, "BlOperationResult");
        }

        public void ModifyTransaction(IList<TransactionModel> collection, TransactionModel transaction)
        {
            TransactionModel transactionToEdit = transaction;
            bool operationFinished = false;

            if (transactionToEdit == null)
            {
                SendMessage("Please select an item to be modified!");
                operationFinished = true;
            }
            else
            {
                do
                {
                    var editedTransaction = editorService.EditTransaction(transactionToEdit);

                    if (editedTransaction != null)
                    {
                        var operationResult = httpService.Update(new TransactionDTO()
                        {
                            Id = transaction.Id, // This prop cannot be changed

                            Amount = editedTransaction.Amount,
                            Currency = editedTransaction.Currency,
                            AccountId = editedTransaction.AccountId,
                            TransferTime = editedTransaction.TransferTime,
                            Type = editedTransaction.Type
                        });

                        transactionToEdit = editedTransaction;
                        operationFinished = operationResult.IsSuccess;

                        if (operationResult.IsSuccess)
                        {
                            RefreshCollectionFromServer(collection);
                            SendMessage("Transaction modification was successful");
                        }
                        else
                        {
                            SendMessage(operationResult.Messages.ToArray());
                        }
                    }
                    else
                    {
                        SendMessage("Transaction modification has cancelled");
                        operationFinished = true;
                    }
                } while (!operationFinished);
            }

            
        }

        public void DeleteTransaction(IList<TransactionModel> collection, TransactionModel transaction)
        {
            if (transaction != null)
            {
                var operationResult = httpService.Delete(transaction.Id);

                if (operationResult.IsSuccess)
                {
                    RefreshCollectionFromServer(collection);
                    SendMessage("Transaction deletion was successful");
                }
                else
                {
                    SendMessage(operationResult.Messages.ToArray());
                }
            }
            else
            {
                SendMessage("Transaction deletion failed");
            }
        }

        public IList<TransactionModel> GetAll()
        {
            // This data comes from DB, API or something like that
            var transactions = httpService.GetAll<Transaction>();

            return transactions.Select(x => new TransactionModel(x.Id, x.Type, x.TransferTime, x.Amount, x.Currency, x.AccountId)).ToList(); // TODO: use AutoMapper in the future
        }

      /*  public IList<BrandModel> GetAllBrands()
        {
            var brands = new List<BrandModel>()
            {
                new BrandModel(1, "Mazda"),
                new BrandModel(2, "Opel"),
                new BrandModel(3, "BMW"),
            }; // TODO: get it from API endpoint!

            return brands; // Note: at this point we have to map the data
        }*/

        public void ViewTransaction(TransactionModel transaction)
        {
            if (transaction == null)
            {
                SendMessage("Please select an item to be displayed!");

            }
            else
            {
                transactionDisplayService.Display(transaction);
            }
        }
    }
}
