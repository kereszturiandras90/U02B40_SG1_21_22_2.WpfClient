using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using U02B40_HFT_2021221.Logic.Interfaces;
using U02B40_HFT_2021221.Logic.Services;
using U02B40_HFT_2021221.Models;
using U02B40_HFT_2021221.Repository;

namespace U02B40_HFT_2021221.Test
{
    [TestFixture]
    class BankTest


    {





        [TestCase]
        public void GetSumImPeriodWorksAsExpected()
        {
            var transactions = new List<Transaction>();
            transactions.Add(new Transaction { Id = 001, AccountId = 001, TransferTime = new DateTime(2011, 12, 25), Amount = 10000 });
            transactions.Add(new Transaction { Id = 002, AccountId = 002, TransferTime = new DateTime(2013, 12, 25), Amount = 15000 });
            transactions.Add(new Transaction { Id = 003, AccountId = 002, TransferTime = new DateTime(2015, 12, 25), Amount = 20000 });
            transactions.Add(new Transaction { Id = 004, AccountId = 003, TransferTime = new DateTime(2017, 12, 25), Amount = 30000 });
            transactions.Add(new Transaction { Id = 005, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 50000 });
            /* transactions.Add(new Transaction { Id = 006, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 50000 });
             transactions.Add(new Transaction { Id = 007, AccountId = 002, TransferTime = new DateTime(2018, 11, 25), Amount = 79000 });
             transactions.Add(new Transaction { Id = 008, AccountId = 001, TransferTime = new DateTime(2019, 10, 25), Amount = 90000 });
             transactions.Add(new Transaction { Id = 009, AccountId = 001, TransferTime = new DateTime(2019, 12, 26), Amount = 59000 });*/
            var begin = new DateTime(2015, 01, 01);
            var end = new DateTime(2020, 01, 01);
            var accs = new List<Account>();
            accs.Add(new Account { Id = 001 });
            accs.Add(new Account { Id = 002 });
            //accs.Add(new Account { Id = 003 });
            //accs.Add(new Account { Id = 004 });
            //accs.Add(new Account { Id = 005 });

            var persons = new List<Person>();
            persons.Add(new Person { Id = 001, AccountId = 001, Name = "Nagy Ádám", DateOfBirth = new DateTime(1990, 12, 31) });
            persons.Add(new Person { Id = 002, AccountId = 002, Name = "Ábel ANita", DateOfBirth = new DateTime(1987, 11, 21) });
            persons.Add(new Person { Id = 003, AccountId = 003, Name = "Tordai Bence", DateOfBirth = new DateTime(1997, 12, 31) });
            persons.Add(new Person { Id = 004, AccountId = 004, Name = "Bede Zsolt", DateOfBirth = new DateTime(1988, 10, 23) });
            persons.Add(new Person { Id = 005, AccountId = 005, Name = "Orbán Viktor", DateOfBirth = new DateTime(1957, 08, 31) });


            var expresult = new List<SumInPeriod>();
            expresult.Add(new SumInPeriod { AccountId = 002, Sum = 20000 });
            expresult.Add(new SumInPeriod { AccountId = 003, Sum = 80000 });




            var transRepo = new Mock<ITransactionRepository>();
            var accRepo = new Mock<IAccountRepository>();
            var persRepo = new Mock<IPersonRepository>();

            transRepo.Setup(x => x.ReadAll()).Returns(transactions.AsQueryable());
            accRepo.Setup(x => x.ReadAll()).Returns(accs.AsQueryable());
            persRepo.Setup(x => x.ReadAll()).Returns(persons.AsQueryable());

            var logic = new TransactionLogic(transRepo.Object, accRepo.Object, persRepo.Object);
            //Act
            var result = logic.GetSumOfTransactionAmountInGivenPeriod(begin, end);
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expresult));






        }
        [TestCase]
        public void GetOverTresholdDetailsWorksAsExpected()
        {
            var transactions = new List<Transaction>();
            transactions.Add(new Transaction { Id = 001, AccountId = 001, TransferTime = new DateTime(2011, 12, 25), Amount = 10000 });
            transactions.Add(new Transaction { Id = 002, AccountId = 002, TransferTime = new DateTime(2013, 12, 25), Amount = 15000 });
            transactions.Add(new Transaction { Id = 003, AccountId = 002, TransferTime = new DateTime(2015, 12, 25), Amount = 20000 });
            transactions.Add(new Transaction { Id = 004, AccountId = 003, TransferTime = new DateTime(2017, 12, 25), Amount = 30000 });
            transactions.Add(new Transaction { Id = 005, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 10000 });
            transactions.Add(new Transaction { Id = 006, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 20000 });
            transactions.Add(new Transaction { Id = 007, AccountId = 002, TransferTime = new DateTime(2018, 11, 25), Amount = 79000 });
            transactions.Add(new Transaction { Id = 008, AccountId = 001, TransferTime = new DateTime(2019, 10, 25), Amount = 90000 });
            transactions.Add(new Transaction { Id = 009, AccountId = 001, TransferTime = new DateTime(2019, 12, 26), Amount = 59000 });
            var begin = new DateTime(2015, 01, 01);
            var end = new DateTime(2020, 01, 01);
            var accs = new List<Account>();
            accs.Add(new Account { Id = 001 });
            accs.Add(new Account { Id = 002 });
            accs.Add(new Account { Id = 003 });
            accs.Add(new Account { Id = 004 });
            accs.Add(new Account { Id = 005 });

            var persons = new List<Person>();
            persons.Add(new Person { Id = 001, AccountId = 001, Name = "Nagy Ádám", DateOfBirth = new DateTime(1990, 12, 31) });
            persons.Add(new Person { Id = 002, AccountId = 002, Name = "Ábel ANita", DateOfBirth = new DateTime(1987, 11, 21) });
            persons.Add(new Person { Id = 003, AccountId = 003, Name = "Tordai Bence", DateOfBirth = new DateTime(1997, 12, 31) });
            persons.Add(new Person { Id = 004, AccountId = 004, Name = "Bede Zsolt", DateOfBirth = new DateTime(1988, 10, 23) });
            persons.Add(new Person { Id = 005, AccountId = 005, Name = "Orbán Viktor", DateOfBirth = new DateTime(1957, 08, 31) });


            var expresult = new List<OverThesholdDetail>();
            expresult.Add(new OverThesholdDetail { Sum = 159000, PersonBorn = new DateTime(1990, 12, 31), PersonName = "Nagy Ádám" });
            expresult.Add(new OverThesholdDetail { Sum = 114000, PersonBorn = new DateTime(1987, 11, 21), PersonName = "Ábel ANita" });




            var transRepo = new Mock<ITransactionRepository>();
            var accRepo = new Mock<IAccountRepository>();
            var persRepo = new Mock<IPersonRepository>();

            transRepo.Setup(x => x.ReadAll()).Returns(transactions.AsQueryable());
            accRepo.Setup(x => x.ReadAll()).Returns(accs.AsQueryable());
            persRepo.Setup(x => x.ReadAll()).Returns(persons.AsQueryable());

            var logic = new TransactionLogic(transRepo.Object, accRepo.Object, persRepo.Object);
            //Act
            var result = logic.GetOverTresholdDetails(100000);
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expresult));






        }

        [TestCase]
        public void GetAverageTransactionPerPersonWorksAsExpected()
        {
            var transactions = new List<Transaction>();
            transactions.Add(new Transaction { Id = 001, AccountId = 001, TransferTime = new DateTime(2011, 12, 25), Amount = 10000 });
            transactions.Add(new Transaction { Id = 002, AccountId = 002, TransferTime = new DateTime(2013, 12, 25), Amount = 15000 });
            transactions.Add(new Transaction { Id = 003, AccountId = 002, TransferTime = new DateTime(2015, 12, 25), Amount = 20000 });
            transactions.Add(new Transaction { Id = 004, AccountId = 003, TransferTime = new DateTime(2017, 12, 25), Amount = 30000 });
            transactions.Add(new Transaction { Id = 005, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 10000 });
            transactions.Add(new Transaction { Id = 006, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 20000 });
            transactions.Add(new Transaction { Id = 007, AccountId = 002, TransferTime = new DateTime(2018, 11, 25), Amount = 79000 });
            transactions.Add(new Transaction { Id = 008, AccountId = 001, TransferTime = new DateTime(2019, 10, 25), Amount = 90000 });
            transactions.Add(new Transaction { Id = 009, AccountId = 001, TransferTime = new DateTime(2019, 12, 26), Amount = 59000 });
            var begin = new DateTime(2015, 01, 01);
            var end = new DateTime(2020, 01, 01);
            var accs = new List<Account>();
            accs.Add(new Account { Id = 001 });
            accs.Add(new Account { Id = 002 });
            accs.Add(new Account { Id = 003 });
            accs.Add(new Account { Id = 004 });
            accs.Add(new Account { Id = 005 });

            var persons = new List<Person>();
            persons.Add(new Person { Id = 001, AccountId = 001, Name = "Nagy Ádám", DateOfBirth = new DateTime(1990, 12, 31) });
            persons.Add(new Person { Id = 002, AccountId = 002, Name = "Ábel ANita", DateOfBirth = new DateTime(1987, 11, 21) });
            persons.Add(new Person { Id = 003, AccountId = 003, Name = "Tordai Bence", DateOfBirth = new DateTime(1997, 12, 31) });
            persons.Add(new Person { Id = 004, AccountId = 004, Name = "Bede Zsolt", DateOfBirth = new DateTime(1988, 10, 23) });
            persons.Add(new Person { Id = 005, AccountId = 005, Name = "Orbán Viktor", DateOfBirth = new DateTime(1957, 08, 31) });


            var expresult = new List<AverageTransactionPerPerson>();
            expresult.Add(new AverageTransactionPerPerson { Average = 53000, PersonName = "Nagy Ádám" });
            expresult.Add(new AverageTransactionPerPerson { Average = 38000, PersonName = "Ábel ANita" });
            expresult.Add(new AverageTransactionPerPerson { Average = 20000, PersonName = "Tordai Bence" });




            var transRepo = new Mock<ITransactionRepository>();
            var accRepo = new Mock<IAccountRepository>();
            var persRepo = new Mock<IPersonRepository>();

            transRepo.Setup(x => x.ReadAll()).Returns(transactions.AsQueryable());
            accRepo.Setup(x => x.ReadAll()).Returns(accs.AsQueryable());
            persRepo.Setup(x => x.ReadAll()).Returns(persons.AsQueryable());

            var logic = new TransactionLogic(transRepo.Object, accRepo.Object, persRepo.Object);
            //Act
            var result = logic.GetAverageTransactionPerPerson();
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expresult));






        }

        [TestCase]
        public void GetPersonsWithMinusWorksAsExpected()
        {
            var transactions = new List<Transaction>();
            transactions.Add(new Transaction { Id = 001, AccountId = 001, TransferTime = new DateTime(2011, 12, 25), Amount = 10000 });
            transactions.Add(new Transaction { Id = 002, AccountId = 002, TransferTime = new DateTime(2013, 12, 25), Amount = 15000 });
            transactions.Add(new Transaction { Id = 003, AccountId = 002, TransferTime = new DateTime(2015, 12, 25), Amount = 20000 });
            transactions.Add(new Transaction { Id = 004, AccountId = 003, TransferTime = new DateTime(2017, 12, 25), Amount = 30000 });
            transactions.Add(new Transaction { Id = 005, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 10000 });
            transactions.Add(new Transaction { Id = 006, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 20000 });
            transactions.Add(new Transaction { Id = 007, AccountId = 002, TransferTime = new DateTime(2018, 11, 25), Amount = -79000 });
            transactions.Add(new Transaction { Id = 008, AccountId = 001, TransferTime = new DateTime(2019, 10, 25), Amount = -90000 });
            transactions.Add(new Transaction { Id = 009, AccountId = 001, TransferTime = new DateTime(2019, 12, 26), Amount = 59000 });
            var begin = new DateTime(2015, 01, 01);
            var end = new DateTime(2020, 01, 01);
            var accs = new List<Account>();
            accs.Add(new Account { Id = 001 });
            accs.Add(new Account { Id = 002 });
            accs.Add(new Account { Id = 003 });
            accs.Add(new Account { Id = 004 });
            accs.Add(new Account { Id = 005 });

            var persons = new List<Person>();
            persons.Add(new Person { Id = 001, AccountId = 001, Name = "Nagy Ádám", DateOfBirth = new DateTime(1990, 12, 31) });
            persons.Add(new Person { Id = 002, AccountId = 002, Name = "Ábel ANita", DateOfBirth = new DateTime(1987, 11, 21) });
            persons.Add(new Person { Id = 003, AccountId = 003, Name = "Tordai Bence", DateOfBirth = new DateTime(1997, 12, 31) });
            persons.Add(new Person { Id = 004, AccountId = 004, Name = "Bede Zsolt", DateOfBirth = new DateTime(1988, 10, 23) });
            persons.Add(new Person { Id = 005, AccountId = 005, Name = "Orbán Viktor", DateOfBirth = new DateTime(1957, 08, 31) });


            var expresult = new List<PersonsWithMinus>();
            expresult.Add(new PersonsWithMinus { Sum = -21000, PersonName = "Nagy Ádám" });
            expresult.Add(new PersonsWithMinus { Sum = -44000, PersonName = "Ábel ANita" });





            var transRepo = new Mock<ITransactionRepository>();
            var accRepo = new Mock<IAccountRepository>();
            var persRepo = new Mock<IPersonRepository>();

            transRepo.Setup(x => x.ReadAll()).Returns(transactions.AsQueryable());
            accRepo.Setup(x => x.ReadAll()).Returns(accs.AsQueryable());
            persRepo.Setup(x => x.ReadAll()).Returns(persons.AsQueryable());

            var logic = new TransactionLogic(transRepo.Object, accRepo.Object, persRepo.Object);
            //Act
            var result = logic.GetPersonsWithMinus();
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expresult));

        }
            [TestCase]
            public void GetInactiveTransactionCountWorksAsExpected()
            {
                var transactions = new List<Transaction>();
                transactions.Add(new Transaction { Id = 001, AccountId = 001, TransferTime = new DateTime(2011, 12, 25), Amount = 10000 });
                transactions.Add(new Transaction { Id = 002, AccountId = 002, TransferTime = new DateTime(2013, 12, 25), Amount = 15000 });
                transactions.Add(new Transaction { Id = 003, AccountId = 002, TransferTime = new DateTime(2015, 12, 25), Amount = 20000 });
                transactions.Add(new Transaction { Id = 004, AccountId = 003, TransferTime = new DateTime(2017, 12, 25), Amount = 30000 });
                transactions.Add(new Transaction { Id = 005, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 10000 });
                transactions.Add(new Transaction { Id = 006, AccountId = 003, TransferTime = new DateTime(2019, 12, 25), Amount = 20000 });
                transactions.Add(new Transaction { Id = 007, AccountId = 002, TransferTime = new DateTime(2018, 11, 25), Amount = -79000 });
                transactions.Add(new Transaction { Id = 008, AccountId = 001, TransferTime = new DateTime(2019, 10, 25), Amount = -90000 });
                transactions.Add(new Transaction { Id = 009, AccountId = 001, TransferTime = new DateTime(2019, 12, 26), Amount = 59000 });
                transactions.Add(new Transaction { Id = 010, AccountId = 004, TransferTime = new DateTime(2019, 12, 26), Amount = 59000 });
                var begin = new DateTime(2015, 01, 01);
                var end = new DateTime(2020, 01, 01);
                var accs = new List<Account>();
                accs.Add(new Account { Id = 001, IsInactive = true });
                accs.Add(new Account { Id = 002, IsInactive = true });
                accs.Add(new Account { Id = 003, IsInactive = false });
                accs.Add(new Account { Id = 004 });

            var expresult = new List<InactiveTransactionCount>();
            expresult.Add(new InactiveTransactionCount { AccountId = 001, Count = 3 });
            expresult.Add(new InactiveTransactionCount { AccountId = 002, Count = 3});





            var transRepo = new Mock<ITransactionRepository>();
            var accRepo = new Mock<IAccountRepository>();
            var persRepo = new Mock<IPersonRepository>();

            transRepo.Setup(x => x.ReadAll()).Returns(transactions.AsQueryable());
            accRepo.Setup(x => x.ReadAll()).Returns(accs.AsQueryable());
            //persRepo.Setup(x => x.ReadAll()).Returns(persons.AsQueryable());

            var logic = new TransactionLogic(transRepo.Object, accRepo.Object, persRepo.Object);
            //Act
            var result = logic.GetInactiveTransactionCount();
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expresult));

            


        }
        [TestCase]
        public void AccountCreateInvalidException()
        {
            //Arrange
            var transRepo = new Mock<ITransactionRepository>();
            var accRepo = new Mock<IAccountRepository>();
            var persRepo = new Mock<IPersonRepository>();

            //transRepo.Setup(x => x.ReadAll()).Returns(transactions.AsQueryable());
            // accRepo.Setup(x => x.ReadAll()).Returns(accs.AsQueryable());
            //persRepo.Setup(x => x.ReadAll()).Returns(persons.AsQueryable());

            var logic = new AccountLogic(persRepo.Object, accRepo.Object, transRepo.Object);

            Account acc = new Account
            {
                Name = "Account of Luis Hose Bolivar Saaranda Espacito Desperte Armanez"
            };
            //Act
            //logic.Create(acc);

            //Assert
            var exception =Assert.Throws(typeof(ArgumentOutOfRangeException), () => logic.Create(acc));
            Assert.That(exception, Is.Not.Null);
            //Assert.That(exception.Message, Is.EqualTo("The max length of the Name must be shorter than or equal to 30 characters!"));


           
            


            
        }
        [Test]
        public void PersonWithoutIdException()
        {
            //Arrange
            var transRepo = new Mock<ITransactionRepository>();
            var accRepo = new Mock<IAccountRepository>();
            var persRepo = new Mock<IPersonRepository>();

            //transRepo.Setup(x => x.ReadAll()).Returns(transactions.AsQueryable());
             //accRepo.Setup(x => x.ReadAll()).Returns(accs.AsQueryable());
           // persRepo.Setup(x => x.ReadAll()).Returns(persons.AsQueryable());

            var logic = new PersonLogic(persRepo.Object, accRepo.Object, transRepo.Object);

            Person per = new Person
            {
                Id = 1,
                Address = "Csillagvirág Klinika",
                Name = "Csillagvirág Klinika Sürgősségi Traumatológia és Pszichiátria "
            };
            

            
            var exception= Assert.Throws(typeof(ArgumentOutOfRangeException),() => logic.Create(per));

            //Assert
            Assert.That(exception, Is.Not.Null);






        }
        [Test]
        public void TransactionUpdateIsSuccessFull()
        {
            //Arrange
            var transRepo = new Mock<ITransactionRepository>();
            var accRepo = new Mock<IAccountRepository>();
            var persRepo = new Mock<IPersonRepository>();

            //transRepo.Setup(x => x.Read(6)).Returns(transaction)

            var logic = new TransactionLogic(transRepo.Object, accRepo.Object, persRepo.Object);

            Transaction transaction = new Transaction()
            {
                Id = 6,
                Type = "div",
                Amount = 6000
            };
            transRepo.Setup(x => x.Read(6)).Returns(transaction);
            logic.Create(transaction);
            transaction.Type = "int";
            //Act
            logic.Update(transaction);

            //Assert

            Assert.That(logic.Read(6).Type, Is.EqualTo("int"));

        }

        [Test]
        public void TransactionCreateThrowsException()
        {
            //Arrange
            var transRepo = new Mock<ITransactionRepository>();
            var accRepo = new Mock<IAccountRepository>();
            var persRepo = new Mock<IPersonRepository>();

            //transRepo.Setup(x => x.ReadAll()).Returns(transactions.AsQueryable());
            //accRepo.Setup(x => x.ReadAll()).Returns(accs.AsQueryable());
            // persRepo.Setup(x => x.ReadAll()).Returns(persons.AsQueryable());

            var logic = new TransactionLogic(transRepo.Object, accRepo.Object, persRepo.Object);

            Transaction transaction = new Transaction()
            {
                Id = 6,
                Type = "dividend",
                Amount = 6000,
                TransferTime = new DateTime(2022, 12, 21)
            };
            transRepo.Setup(x => x.Read(6)).Returns(transaction);

            //Act
            var exception = Assert.Throws(typeof(InvalidOperationException), () => logic.Create(transaction));
            //Assert
            Assert.That(exception, Is.Not.Null);


           
          
        }
        [Test]
        public void PersonIdIsNull()
        {
            //Arrange
            var transRepo = new Mock<ITransactionRepository>();
            var accRepo = new Mock<IAccountRepository>();
            var persRepo = new Mock<IPersonRepository>();



            var logic = new PersonLogic(persRepo.Object, accRepo.Object, transRepo.Object);

            Person person = new Person()
            {
                Name = "Dobó István"
            };
            //Act
            var exception = Assert.Throws(typeof(ArgumentNullException), () => logic.Create(person));

            //Assert

            Assert.That(exception, Is.Not.Null);

            
            


        }
    }
    }

