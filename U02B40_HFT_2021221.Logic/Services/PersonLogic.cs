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
    public class PersonLogic : IPersonLogic
    {
        IPersonRepository _personRepository;
        IAccountRepository _accountRepository;
        ITransactionRepository _transactionRepository;
        public PersonLogic(IPersonRepository personRepository, IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _personRepository = personRepository;
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;



        }
        public Person Create(Person entity)
        {
            if(entity.Id == default)
            {
                throw new ArgumentNullException("Please provide an identifier!");
            }
            if(entity.Name.Length > 30)
            {
                throw new ArgumentOutOfRangeException("The name must be shorter or equal to 30 characters");
            }
            var result = _personRepository.Create(entity);
            return result;
        }

        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }

        public Person Read(int id)
        {
            return _personRepository.Read(id);
        }

        public IList<Person> ReadAll()
        {
            return (IList<Person>)_personRepository.ReadAll().ToList();
        }

        public Person Update(Person entity)
        {

            if(entity.Name.Length > 20) {
                throw new ArgumentOutOfRangeException("The name must be shorther than or equal to 20 characters");
            }


            var result = _personRepository.Update(entity);


            return result;
        }
    }
}
