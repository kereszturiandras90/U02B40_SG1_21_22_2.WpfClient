using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.WpfClient.Models
{
    public class AccountModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AccountModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
