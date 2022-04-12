using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U02B40_HFT_2021221.Logic.Interfaces;
using U02B40_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace U02B40_HFT_2021221.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        readonly IPersonLogic personLogic;
        public PersonController(IPersonLogic personLogic)
        {
            this.personLogic = personLogic;
        }

        // GET: api/Account
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Person> Get()
        {
            return personLogic.ReadAll();
        }

        // GET api/Account/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return personLogic.Read(id);
        }

        // POST api/Account
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(Person person)
        {
            var result = new ApiResult(true);


            try
            {
                personLogic.Create(person);
            }
            catch (Exception)
            {

                result.IsSuccess = false;
            }


            return result;
        }

        // PUT api/Account
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(Person person)
        {
            var result = new ApiResult(true);


            try
            {
                personLogic.Update(person);
            }
            catch (Exception)
            {

                result.IsSuccess = false;
            }


            return result;
        }

        // DELETE api/Account/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);

            try
            {
                personLogic.Delete(id);
            }
            catch (Exception)
            {

                result.IsSuccess = false;
            }

            return result;
        }
    }
}
