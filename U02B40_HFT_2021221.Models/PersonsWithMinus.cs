using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.Models
{
    public class PersonsWithMinus
    {
        public string PersonName { get; set; }

        public decimal Sum { get; set; }

        public override string ToString()
        {
            return $"{PersonName} - {Sum}";


        }

        public override bool Equals(object obj)
        {
            var other = obj as PersonsWithMinus;

            if (other == null)
                return false;

            return other.PersonName == PersonName && other.Sum == Sum;
        }
    }
}
