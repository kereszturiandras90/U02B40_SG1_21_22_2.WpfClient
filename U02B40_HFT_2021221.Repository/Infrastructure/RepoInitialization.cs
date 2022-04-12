using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using U02B40_HFT_2021221.Data;

namespace U02B40_HFT_2021221.Repository.Infrastructure
{
    public static class RepoInitialization
    {
        public static void InitRepoServices(IServiceCollection services)
        {
            services.AddScoped<PersonsDBContext>((sp) => new PersonsDBContext());
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}
