using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using U02B40_HFT_2021221.Models;
    using U02B40_HFT_2021221.Repository;
    using Microsoft.EntityFrameworkCore;
    using U02B40_HFT_2021221.Data;

    public class AccountRepository : RepositoryBase<Account, int>, IAccountRepository
    {
       
        public AccountRepository(PersonsDBContext dbContext)
            : base(dbContext)
        {
        }

        

        public override Account Read(int id)
        {
            return this.ReadAll().SingleOrDefault(x => x.Id == id);
        }

  
       
    }
}

