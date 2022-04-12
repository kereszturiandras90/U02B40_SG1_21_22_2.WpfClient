using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U02B40_HFT_2021221.Logic.Interfaces;
using U02B40_HFT_2021221;
using U02B40_HFT_2021221.Models;
using U02B40_HFT_2021221.Repository;

namespace U02B40_HFT_2021221.Logic.Services
{
    public class AccountLogic : IAccountLogic
    {
        IPersonRepository _personRepository;
        IAccountRepository _accountRepository;
        ITransactionRepository _transactionRepository;

        public AccountLogic(IPersonRepository personRepository, IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _personRepository = personRepository;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;



        }

        public IList<Account> ReadAll()
        {
            return (IList<Account>)_accountRepository.ReadAll().ToList();
        }

        public Account Read(int id)
        {
            return _accountRepository.Read(id);
        }

        public Account Create(Account entity)
        {
            if(entity.Name.Length > 30)
            {
                throw new ArgumentOutOfRangeException("The max length of the Name must be shorter than or equal to 30 characters!");
            }

            if(entity.Id == null)
            {
                throw new ArgumentNullException("The Id must be available!");
            }


            var result = _accountRepository.Create(entity);

            

            return result;
        }
        public Account Update(Account entity)
        {
          

            if (entity.Name.Length > 30)
            {
                throw new ArgumentOutOfRangeException("The max length of the Name must be shorter than or equal to 30 characters!");
            }


       

            var result = _accountRepository.Update(entity);

         
            return result;
        }

        public void Delete(int id)
        {
          

            _accountRepository.Delete(id);
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

        
    }
}
