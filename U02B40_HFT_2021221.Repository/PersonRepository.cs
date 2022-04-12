using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using U02B40_HFT_2021221.Data;
    using U02B40_HFT_2021221.Models;

    public class PersonRepository : RepositoryBase<Person, int>, IPersonRepository
    {
        public PersonRepository(PersonsDBContext dbContext)
            : base(dbContext)
        {
        }

       
        public void AddNew(string id, string name, DateTime szulido, string MotherName, string address)
        {
            Person person = new Person();
            //person.Id = id;
            person.Name = name;
            person.DateOfBirth = szulido;
            person.MotherName = MotherName;
            person.Address = address;

            this.DbContext.Add<Person>(person);
            this.DbContext.SaveChanges();
        }

    
      

       
        public override Person Read(int id)
        {
            return this.ReadAll().SingleOrDefault(x => x.Id == id);
        }

    
        
    }
}
