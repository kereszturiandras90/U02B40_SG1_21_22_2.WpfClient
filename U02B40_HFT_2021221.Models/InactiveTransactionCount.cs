using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.Models
{
    public class InactiveTransactionCount
    {
        public int AccountId { get; set; }

        public int Count { get; set; }

        public override string ToString()
        {
            return $"{AccountId} - {Count}";


        }

        public override bool Equals(object obj)
        {
            var other = obj as InactiveTransactionCount;

            if (other == null)
                return false;

            return other.AccountId == AccountId && other.Count == Count;
        }
    }
}
