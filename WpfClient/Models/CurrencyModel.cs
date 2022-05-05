using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.WpfClient.Models
{
    public class CurrencyModel
    {
        public string Currency { get; set; }

        public CurrencyModel(string currency)
        {
            Currency = currency;
        }
    }
}
