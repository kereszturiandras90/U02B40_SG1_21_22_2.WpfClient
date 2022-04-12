using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U02B40_HFT_2021221.Logic.Interfaces;
using U02B40_HFT_2021221.Logic.Services;
using U02B40_HFT_2021221.Repository.Infrastructure;

namespace U02B40_HFT_2021221.Logic.Infrastructure
{
    public static class BLInitialisation
    {
        public static void InitBlServices(IServiceCollection services)
        {
            RepoInitialization.InitRepoServices(services);

            services.AddScoped<IAccountLogic, AccountLogic>();
            services.AddScoped<ITransactionLogic, TransactionLogic>();
            services.AddScoped<IPersonLogic, PersonLogic>();

        }
    }
}
