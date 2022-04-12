using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U02B40_HFT_2021221.Models;
using U02B40_HFT_2021221.Models;
using U02B40_HFT_2021221.Models;

namespace U02B40_HFT_2021221.Logic.Interfaces
{
    public interface ITransactionLogic
    {
        IList<Transaction> ReadAll();

        Transaction Read(int id);

        Transaction Create(Transaction entity);

        Transaction Update(Transaction entity);

        void Delete(int id);

        IEnumerable<AverageTransactionPerPerson> GetAverageTransactionPerPerson();

        IEnumerable<PersonsWithMinus> GetPersonsWithMinus();

        IEnumerable<InactiveTransactionCount> GetInactiveTransactionCount();

        IEnumerable<OverThesholdDetail> GetOverTresholdDetails(decimal treshold);

        public IEnumerable<SumInPeriod> GetSumOfTransactionAmountInGivenPeriod(DateTime periodbegin, DateTime periodend);


    }
}
