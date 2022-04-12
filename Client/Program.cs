using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using U02B40_HFT_2021221.Client;
using U02B40_HFT_2021221.Models;

namespace Client
{
     class Program
    {
         static void Main(string[] args)
        {
            Console.WriteLine("Waiting for server.");
            Console.ReadLine();
            var personhttpService = new HttpServices("Person", "http://localhost:60195/api/");
            var accounthttpService = new HttpServices("Account", "http://localhost:60195/api/");
            var transactionhttpService = new HttpServices("Transaction", "http://localhost:60195/api/");

            var persons = personhttpService.GetAll<Person>();
            var accounts = accounthttpService.GetAll<Account>();
            var transactions = transactionhttpService.GetAll<Transaction>();

            Display(persons);
            Display(accounts);
            Display(transactions);

            Console.ReadLine();

            var onePerson = personhttpService.Get<Person, int>(persons.First().Id);
            Console.WriteLine(onePerson);

            var oneAccount = accounthttpService.Get<Account, int>(accounts.First().Id);
            Console.WriteLine(oneAccount);

            var oneTransaction = personhttpService.Get<Transaction, int>(transactions.First().Id);
            Console.WriteLine(oneTransaction);


            /// Update, Create, Delete for Person

            var newPerson = new Person()
            {
                Id = 6,
                Name = "András",
                AccountId = 2
            };

            var result = personhttpService.Create(newPerson);

            if (result.IsSuccess)
            {
                Console.WriteLine("Creation was succesfull");
            }

            // Check
            persons = personhttpService.GetAll<Person>();
            Display(persons);

            // Update
            var personForUpdate = persons.First();
            personForUpdate.Name = "Tibi";

            result = personhttpService.Update(personForUpdate);

            if (result.IsSuccess)
            {
                Console.WriteLine("Update was successfull.");
            }

            // Check
            persons = personhttpService.GetAll<Person>();
            Display(persons);

            // Delete
            result = personhttpService.Delete(personForUpdate.Id);

            if (result.IsSuccess)
            {
                Console.WriteLine("Deletion was successfull.");
            }

            // Check
            persons = personhttpService.GetAll<Person>();
            Display(persons);

            /// Update, Create, Delete for Account

            var newAccount = new Account()
            {
                Id= 6,
                Name = "András Account",
                IsClosed = false
            };

            result = accounthttpService.Create(newAccount);

            if (result.IsSuccess)
            {
                Console.WriteLine("Creation was succesfull");
            }

            // Check
            accounts = accounthttpService.GetAll<Account>();
            Display(accounts);

            // Update
            var accountForUpdate = accounts.First();
            accountForUpdate.Name = "Tibi Accountja";

            result = accounthttpService.Update(accountForUpdate);

            if (result.IsSuccess)
            {
                Console.WriteLine("Update was successfull.");
            }

            // Check
            accounts = accounthttpService.GetAll<Account>();
            Display(accounts);

            // Delete
            result = accounthttpService.Delete(accountForUpdate.Id);

            if (result.IsSuccess)
            {
                Console.WriteLine("Deletion was successfull.");
            }

            // Check
            accounts = accounthttpService.GetAll<Account>();
            Display(accounts);


            /// Update, Create, Delete for Transaction

           var newTransaction = new Transaction()
            {
                Id = 11,
                Type = "div",
                AccountId = 1
            };

            result = transactionhttpService.Create(newTransaction);

            if (result.IsSuccess)
            {
                Console.WriteLine("Creation was succesfull");
            }

            // Check
            transactions = transactionhttpService.GetAll<Transaction>();
            Display(transactions);

            // Update
            var transactionForUpdate = transactions.First();
            transactionForUpdate.Type = "int";
            

            result = transactionhttpService.Update(transactionForUpdate);

            if (result.IsSuccess)
            {
                Console.WriteLine("Update was successfull.");
            }

            // Check
            transactions = transactionhttpService.GetAll<Transaction>();
            Display(transactions);

            // Delete
            result = transactionhttpService.Delete(transactionForUpdate.Id);

            if (result.IsSuccess)
            {
                Console.WriteLine("Deletion was successfull.");
            }

            // Check
            transactions = transactionhttpService.GetAll<Transaction>();
            Display(transactions);

            var averageperperson = transactionhttpService.GetAllCustom<AverageTransactionPerPerson>("GetAverage");
            Display(averageperperson);

            var inactivetransactioncount = transactionhttpService.GetAllCustom<InactiveTransactionCount>("GetInactive");
            Display(inactivetransactioncount);

            var personswithminus = transactionhttpService.GetAllCustom<PersonsWithMinus>("GetPersonsWithMinus");
            Display(personswithminus);

            var overthreshold = transactionhttpService.GetDecimalTreshold<OverThesholdDetail>(10000);
            Display(overthreshold);

            var suminperiod = transactionhttpService.GetSumInPeriod<SumInPeriod>(new DateTime(2015,01,01), new DateTime(2019,01,01));
            Display(suminperiod);






        }

        

        public static void Display<T>(List<T> list)
        {
            Console.WriteLine();

            foreach (T item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
