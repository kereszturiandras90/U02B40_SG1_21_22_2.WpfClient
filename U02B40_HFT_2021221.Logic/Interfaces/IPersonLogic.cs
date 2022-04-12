using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U02B40_HFT_2021221.Models;

namespace U02B40_HFT_2021221.Logic.Interfaces
{
    public interface IPersonLogic
    {
        IList<Person> ReadAll();

        Person Read(int id);

        Person Create(Person entity);

        Person Update(Person entity);

        void Delete(int id);
    }
}
