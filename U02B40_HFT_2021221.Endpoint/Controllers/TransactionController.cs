using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U02B40_HFT_2021221.Logic.Interfaces;
using U02B40_HFT_2021221.Models;
using U02B40_HFT_2021221.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace U02B40_HFT_2021221.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public readonly ITransactionLogic transactionLogic;
        public TransactionController(ITransactionLogic transactionLogic)
        {
            this.transactionLogic = transactionLogic;
        }
        // GET: api/<TransactionController>
        [HttpGet]
        [ActionName("GetAll")]
        public IEnumerable<Transaction> Get()
        {
            return transactionLogic.ReadAll();
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public Transaction Get(int id)
        {
            return transactionLogic.Read(id);
        }

        // POST api/<TransactionController>
        [HttpPost]
        [ActionName("Create")]
        public ApiResult Post(TransactionDTO transaction)
        {
            var result = new ApiResult(true);


            try
            {
                transactionLogic.Create(new Transaction
                {
                    Id = transaction.Id,
                    TransferTime = transaction.TransferTime,
                    Type = transaction.Type,
                    Amount = transaction.Amount,
                    Currency = transaction.Currency,
                    AccountId = transaction.AccountId
                }) ;
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Messages = new List<string>() { ex.Message};
            }


            return result;
        }

        // PUT api/<TransactionController>/5
        [HttpPut]
        [ActionName("Update")]
        public ApiResult Put(Transaction transaction)
        {
            var result = new ApiResult(true);


            try
            {
                transactionLogic.Update(transaction);
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Messages = new List<string>() { ex.Message };
            }


            return result;
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            var result = new ApiResult(true);


            try
            {
                transactionLogic.Delete(id);
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Messages = new List<string>() { ex.Message };
            }


            return result;
        }
        [HttpGet]
        [ActionName("GetAverage")]
        public IEnumerable<AverageTransactionPerPerson> GetAverageTransactionPerPerson()
        {
           return transactionLogic.GetAverageTransactionPerPerson();
        }
        [HttpGet]
        [ActionName("GetInactive")]
        public IEnumerable<InactiveTransactionCount> GetInactiveTransactionCounts()
        {
            return transactionLogic.GetInactiveTransactionCount();
        }
        [HttpGet]
        [ActionName("GetOverThreshold")]
        public IEnumerable<OverThesholdDetail> GetOverThesholdDetails(decimal treshold)
        {
            return transactionLogic.GetOverTresholdDetails(treshold);
        }
        [HttpGet]
        [ActionName("GetSumInPeriod")]
        public IEnumerable<SumInPeriod> GetSumInPeriods(DateTime periodbegin, DateTime periodend)
        {
            return transactionLogic.GetSumOfTransactionAmountInGivenPeriod(periodbegin, periodend);
        }
        [HttpGet]
        [ActionName("GetPersonsWithMinus")]
        public IEnumerable<PersonsWithMinus> GetPersonsWithMinus()
        {
            return transactionLogic.GetPersonsWithMinus();
        }
    }
    }

