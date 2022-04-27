using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U02B40_HFT_2021221.Logic.Interfaces;
using U02B40_HFT_2021221.Models;

using U02B40_HFT_2021221.Repository;

namespace U02B40_HFT_2021221.Logic.Services
{
   public class TransactionLogic : ITransactionLogic
    {
        ITransactionRepository _transactionRepository;
        IAccountRepository _accountRepository;
        IPersonRepository _personRepository;

        public TransactionLogic(ITransactionRepository transactionRepository, IAccountRepository accountRepository, IPersonRepository personRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _personRepository = personRepository;


        }

        public IList<Transaction> ReadAll()
        {
            return _transactionRepository.ReadAll().ToList();
        }

        public Transaction Read(int id)
        {
            return _transactionRepository.Read(id);
        }

        public Transaction Create(Transaction entity)
        {
            // TODO check access

            if(entity.TransferTime > DateTime.Now)
            {
                throw new InvalidOperationException("Please enter a valid time for the transaction!");
            }

            if (entity.Id == ' ')
            {
                throw new ArgumentNullException("The transaction identifier must be available");
            }

            var result = _transactionRepository.Create(entity);

            // TODO: log

            return result;
        }
        public Transaction Update(Transaction entity)
        {
            // TODO check access

            if(entity.Type?.Length > 6)
            {
                throw new ArgumentOutOfRangeException("the length of the transaction type must shorter or equal to 6 characters");
            }

            // TODO: map

            var result = _transactionRepository.Update(entity);

            // TODO: log

            return result;
        }

        public void Delete(int id)
        {
            // TODO check access

            // TODO: check relations

            _transactionRepository.Delete(id);
        }

        public IEnumerable<SumInPeriod> GetSumOfTransactionAmountInGivenPeriod(DateTime periodbegin, DateTime periodend)
        {
            var result = from transaction in _transactionRepository.ReadAll()
                         where transaction.TransferTime <= periodend && transaction.TransferTime >= periodbegin
                         group transaction by transaction.AccountId into groped
                         select new SumInPeriod
                         {
                             AccountId = groped.Key,
                             Sum = groped.Sum(x => x.Amount)
                         };

            return result.ToList();
        }

        public IEnumerable<OverThesholdDetail> GetOverTresholdDetails(decimal treshold)
        {
            var result = from transaction in _transactionRepository.ReadAll()
                         group transaction by transaction.AccountId into grouped
                         select new
                         {

                             AccountId = grouped.Key,
                             Sum = grouped.Sum(x => x.Amount)
                         };


            var result2 = from tarnssum in result
                          from person in _personRepository.ReadAll()
                          where tarnssum.Sum >= treshold && person.AccountId == tarnssum.AccountId
                          select new OverThesholdDetail
                          {
                              PersonName = person.Name,
                              PersonBorn = person.DateOfBirth,
                              Sum = tarnssum.Sum

                          };

            return result2.ToList();


        }

        public IEnumerable<AverageTransactionPerPerson> GetAverageTransactionPerPerson()
        {
            var result = from transaction in _transactionRepository.ReadAll()
                         group transaction by transaction.AccountId into grouped
                         select new
                         {
                             Average = grouped.Average(x => x.Amount),
                             AccountId = grouped.Key
                         };

            var result2 = from partres in result
                          from person in _personRepository.ReadAll()
                          where person.AccountId == partres.AccountId
                          select new AverageTransactionPerPerson
                          {
                              Average = partres.Average,
                              PersonName = person.Name
                          };

            return result2.ToList();
        }

        public IEnumerable<PersonsWithMinus> GetPersonsWithMinus()
        {
            var result = from transaction in _transactionRepository.ReadAll()
                         group transaction by transaction.AccountId into grouped
                         select new
                         {
                             Sum = grouped.Sum(x => x.Amount),
                             AccountId = grouped.Key
                         };


            var result2 = from partres in result
                          from person in _personRepository.ReadAll()
                          where person.AccountId == partres.AccountId && partres.Sum < 0
                          select new PersonsWithMinus
                          {
                              Sum = partres.Sum,
                              PersonName = person.Name
                          };

            return result2.ToList();
        }

        public IEnumerable<InactiveTransactionCount> GetInactiveTransactionCount()
        {
            var result = from transaction in _transactionRepository.ReadAll()
                         group transaction by transaction.AccountId into grouped 
                         select new InactiveTransactionCount
                         {
                             Count = grouped.Count(),
                             AccountId = grouped.Key
                         };

            var result2 = from partres in result
                          join account in _accountRepository.ReadAll()
                          on  partres.AccountId equals account.Id
                          where account.IsInactive == true 
                          select new InactiveTransactionCount
                          {
                              Count = partres.Count,
                              AccountId = account.Id
                          };

            return result2.ToList();
        }
    }
}
