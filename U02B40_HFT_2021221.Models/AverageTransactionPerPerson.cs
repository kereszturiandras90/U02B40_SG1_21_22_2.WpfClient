using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.Models
{
    public class AverageTransactionPerPerson
    {

        public string PersonName { get; set; }

        public decimal Average { get; set; }

        public override string ToString()
        {
            return $"{PersonName} - {Average}";


        }

        public override bool Equals(object obj)
        {
            var other = obj as AverageTransactionPerPerson;

            if (other == null)
                return false;

            return other.PersonName == PersonName && other.Average == Average;
        }
    }
}
