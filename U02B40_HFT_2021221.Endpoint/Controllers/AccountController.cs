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
    public class AccountController : ControllerBase
    {
        readonly IAccountLogic accountLogic;
        public AccountController(IAccountLogic accountLogic)
        {
            this.accountLogic = accountLogic;
        }

        // GET: api/Account
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Account> Get()
        {
            return accountLogic.ReadAll();
        }

        // GET api/Account/5
        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return accountLogic.Read(id);
        }

        // POST api/Account
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(Account account)
        {
            var result = new ApiResult(true);


            try
            {
                accountLogic.Create(account);
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
        public ApiResult Put(Account account)
        {
            var result = new ApiResult(true);


            try
            {
                accountLogic.Update(account);
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
                accountLogic.Delete(id);
            }
            catch (Exception)
            {

                result.IsSuccess = false;
            }

            return result;
        }
    }
}
