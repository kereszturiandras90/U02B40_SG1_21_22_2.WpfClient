using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U02B40_HFT_2021221.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace U02B40_HFT_2021221.Data
{
    public class PersonsDBContext : DbContext
    {
        private const string DefaultConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\U02B40.mdf;Integrated Security=true;MultipleActiveResultSets=True";

       
        public DbSet<Person> Persons { get; set; }

        
        public DbSet<Account> Accounts { get; set; }

       
        public DbSet<Transaction> Transactions { get; set; }



        public PersonsDBContext()
        {
            Database.EnsureCreated();
        }



      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                              .UseSqlServer(DefaultConStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Person>(e => e.HasOne(p => p.Account).WithOne(a => a.Person).OnDelete(DeleteBehavior.ClientSetNull));
            modelBuilder.Entity<Transaction>(e => e.HasOne(t => t.Account).WithMany(a => a.Transactions).HasForeignKey(t => t.AccountId).OnDelete(DeleteBehavior.ClientSetNull));
            modelBuilder.Entity<Account>(e => e.HasMany(a => a.Transactions).WithOne(t => t.Account).OnDelete(DeleteBehavior.ClientSetNull));

            



            Transaction t1 = new  Transaction { Id = 001, AccountId = 001, TransferTime = new DateTime(2011, 12, 25), Amount = -10000, Currency="USD", Type="DIV" };
            Transaction t2 = new Transaction { Id = 002, AccountId = 002, TransferTime = new DateTime(2013, 12, 25), Amount = 15000, Currency="GBP", Type="INT" };
            Transaction t3 = new Transaction { Id = 003, AccountId = 002, TransferTime = new DateTime(2015, 12, 25), Amount = 20000, Currency="JMF", Type="STO" };
            Transaction t4 = new Transaction { Id = 004, AccountId = 003, TransferTime = new DateTime(2017, 12, 25), Amount = 30000, Currency="EUR", Type="DIV" };
            Transaction t5 = new Transaction { Id = 005, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 10000, Currency="RON" , Type="INT"};
            Transaction t6 = new Transaction { Id = 006, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 20000, Currency= "рубль", Type= "нахуй" };
            Transaction t7 = new Transaction { Id = 007, AccountId = 002, TransferTime = new DateTime(2018, 11, 25), Amount = 79000, Currency="AUD", Type="STO" };
            Transaction t8 = new Transaction { Id = 008, AccountId = 001, TransferTime = new DateTime(2019, 10, 25), Amount = -90000, Currency="HUF", Type="DIV" };
            Transaction t9 = new Transaction { Id = 009, AccountId = 001, TransferTime = new DateTime(2019, 12, 26), Amount = 59000, Currency="EUR", Type="INT" };

            Account a1 = new Account { Id = 001, Name = "worker account", IsClosed = false, IsInactive = false };
            Account a2 =new Account { Id = 002, Name = "Ibizai Account", IsClosed = true, IsInactive = true };
            Account a3 = new Account { Id = 003, Name = "Prostizós Account", IsClosed = false, IsInactive = false };
            Account a4 = new Account { Id = 004, Name = "szegény account", IsClosed = false, IsInactive = false };
            Account a5 = new Account { Id = 005, Name = "Drogbáró Account", IsClosed = true, IsInactive = false };

         
            Person p1 = new Person { Id = 001, AccountId = 001, Name = "Nagy Ádám", DateOfBirth = new DateTime(1990, 12, 31) };
            Person p2 = new Person { Id = 002, AccountId = 002, Name = "Ábel ANita", DateOfBirth = new DateTime(1987, 11, 21) };
            Person p3=  new  Person { Id = 003, AccountId = 003, Name = "Tordai Bence", DateOfBirth = new DateTime(1997, 12, 31) };
            Person p4 = new Person { Id = 004, AccountId = 004, Name = "Bede Zsolt", DateOfBirth = new DateTime(1988, 10, 23) };
            Person p5 = new Person { Id = 005, AccountId = 005, Name = "Orbán Viktor", DateOfBirth = new DateTime(1957, 08, 31) };

         




            modelBuilder.Entity<Person>().HasData(p1, p2, p3, p4, p5);
            modelBuilder.Entity<Account>().HasData(a1, a2, a3, a4, a5);
            modelBuilder.Entity<Transaction>().HasData(t1, t2, t3, t4, t5, t6, t7, t8, t9);



        }
    }
}

