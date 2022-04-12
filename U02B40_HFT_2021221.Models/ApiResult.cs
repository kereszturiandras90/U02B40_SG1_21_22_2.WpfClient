using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U02B40_HFT_2021221.Models
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }

        public List<string> Messages { get; set; }

        public ApiResult(bool isSucces, List<string> messages = null)
        {
            IsSuccess = isSucces;
            Messages = messages;
        }

        public ApiResult()
        {

        }
    }
}
