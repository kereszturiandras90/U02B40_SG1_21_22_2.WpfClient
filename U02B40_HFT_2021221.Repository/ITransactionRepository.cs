using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using U02B40_HFT_2021221.Models;

   
    public interface ITransactionRepository : IRepository<Transaction, int>
    {
     
          }
}

