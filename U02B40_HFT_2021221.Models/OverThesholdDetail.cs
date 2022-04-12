using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.Models
{
    public class OverThesholdDetail
    {
        public string PersonName { get; set; }

        public DateTime PersonBorn { get; set; }

        public decimal Sum { get; set; }

        public override string ToString()
        {
            return $"{PersonName} - {PersonBorn} - {Sum}";


        }

        public override bool Equals(object obj)
        {
            var other = obj as OverThesholdDetail;

            if (other == null)
                return false;

            return other.PersonBorn == PersonBorn && other.Sum == Sum && other.PersonName == PersonName; 
        }
    }
}
