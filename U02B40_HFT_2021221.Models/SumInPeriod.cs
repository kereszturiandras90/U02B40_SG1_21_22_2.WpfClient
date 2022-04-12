using System;
using System.Collections.Generic;
using System.Text;

namespace U02B40_HFT_2021221.Models
{
    public class SumInPeriod
    {
        public int AccountId { get; set; }

        public decimal Sum { get; set; }

        public override string ToString()
        {
            return $"{AccountId} - {Sum}";
            

        }

        public override bool Equals(object obj)
        {
            var other = obj as SumInPeriod;

            if (other == null)
                return false;

            return other.AccountId == AccountId && other.Sum == Sum; 
        }
    }
}
