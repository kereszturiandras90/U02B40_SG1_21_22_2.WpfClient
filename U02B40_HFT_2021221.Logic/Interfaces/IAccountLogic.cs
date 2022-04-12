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
    public interface IAccountLogic
    {
        IList<Account> ReadAll();

        Account Read(int id);

        Account Create(Account entity);

        Account Update(Account entity);

        void Delete(int id);
    }
}
