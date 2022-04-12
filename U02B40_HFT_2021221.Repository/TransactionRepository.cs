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
    using Microsoft.EntityFrameworkCore;
    using U02B40_HFT_2021221.Data;
    using U02B40_HFT_2021221.Models;

   
    public class TransactionRepository : RepositoryBase<Transaction, int>, ITransactionRepository
    {
      
        public TransactionRepository(PersonsDBContext dbContext)
            : base(dbContext)
        {
        }

    

       
        public override Transaction Read(int id)
        {
            return this.ReadAll().SingleOrDefault(x => x.Id == id);
        }

       
    }
}

