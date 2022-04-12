using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.Models.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public DateTime TransferTime { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public int AccountId { get; set; }
    }
}
