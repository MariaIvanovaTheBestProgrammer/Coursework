using BLL;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class QueryTests
    {
        [TestMethod]
        public void GetAllClients_orders_by_firstName()
        {
            var data = new List<Client>
            {
                new Client { ClientId = 1, FirstName = "Marusya4", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 2, FirstName = "Marusya1", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 3, FirstName = "Marusya3", LastName = "Lazorenko", BankAccount = 12435  },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(c => c.Clients).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            var clients = service.AllClientsSortedByFirstName();

            Assert.AreEqual(3, clients.Count);
            Assert.AreEqual("Marusya1", clients.FirstOrDefault().FirstName);
        }

        [TestMethod]
        public void GetClientById()
        {
            var data = new List<Client>
            {
                new Client { ClientId = 1, FirstName = "Marusya4", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 2, FirstName = "Marusya1", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 3, FirstName = "Marusya3", LastName = "Lazorenko", BankAccount = 12435  },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(c => c.Clients).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            var client = service.FindClientById(2);

            Assert.AreEqual("Marusya1", client.FirstName);
        }
        [TestMethod]
        public void GetClientByFirstName()
        {
            var data = new List<Client>
            {
                new Client { ClientId = 1, FirstName = "Marusya4", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 2, FirstName = "Marusya1", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 3, FirstName = "Marusya3", LastName = "Lazorenko", BankAccount = 12435  },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(c => c.Clients).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            var clients = service.FindClientsByFirstName("Marusya1");

            Assert.AreEqual(1, clients.Count);
            Assert.AreEqual("Marusya1", clients.FirstOrDefault().FirstName);
        }
        [TestMethod]
        public void GetClientByLastName()
        {
            var data = new List<Client>
            {
                new Client { ClientId = 1, FirstName = "Marusya4", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 2, FirstName = "Marusya1", LastName = "Ivanova", BankAccount = 12435  },
                new Client { ClientId = 3, FirstName = "Marusya3", LastName = "Nazarenko", BankAccount = 12435  },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(c => c.Clients).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            var clients = service.FindClientsByLastName("Ivanova");

            Assert.AreEqual(1, clients.Count);
            Assert.AreEqual("Ivanova", clients.FirstOrDefault().LastName);
        }
        [TestMethod]
        public void GetAllClients_orders_by_lastName()
        {
            var data = new List<Client>
            {
                new Client { ClientId = 1, FirstName = "Marusya4", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 2, FirstName = "Marusya1", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 3, FirstName = "Marusya3", LastName = "Lazorenko", BankAccount = 12435  },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(c => c.Clients).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            var clients = service.AllClientsSortedByLastName();

            Assert.AreEqual(3, clients.Count);
            Assert.AreEqual("Lazorenko", clients.FirstOrDefault().LastName);
        }
        [TestMethod]
        public void GetAllClients_by_key_word_in_first_name()
        {
            var data = new List<Client>
            {
                new Client { ClientId = 1, FirstName = "Anya", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 2, FirstName = "Marusya", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 3, FirstName = "Olya", LastName = "Lazorenko", BankAccount = 12435  },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(c => c.Clients).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            var clients = service.ContainsClientsByKeyWordInFirstName("Mar");

            Assert.AreEqual(1, clients.Count);
            Assert.AreEqual("Marusya", clients.FirstOrDefault().FirstName);
        }
        [TestMethod]
        public void GetAllClients_by_key_word_in_last_name()
        {
            var data = new List<Client>
            {
                new Client { ClientId = 1, FirstName = "Anya", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 2, FirstName = "Marusya", LastName = "Ivanova", BankAccount = 12435  },
                new Client { ClientId = 3, FirstName = "Olya", LastName = "Petrova", BankAccount = 12435  },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(c => c.Clients).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            var clients = service.ContainsClientsByKeyWordInLastName("Iva");

            Assert.AreEqual(1, clients.Count);
            Assert.AreEqual("Ivanova", clients.FirstOrDefault().LastName);
        }
        [TestMethod]
        public void GetClientByBankAccount()
        {
            var data = new List<Client>
            {
                new Client { ClientId = 1, FirstName = "Marusya4", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 2, FirstName = "Marusya1", LastName = "Lazorenko", BankAccount = 54312  },
                new Client { ClientId = 3, FirstName = "Marusya3", LastName = "Lazorenko", BankAccount = 17841  },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(c => c.Clients).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            var client = service.FindClientByBankAccount(12435);

            Assert.AreEqual("Marusya4", client.FirstName);
        }
        [TestMethod]
        public void GetAllClients_orders_by_bankAccount()
        {
            var data = new List<Client>
            {
                new Client { ClientId = 1, FirstName = "Marusya4", LastName = "Lazorenko", BankAccount = 12435  },
                new Client { ClientId = 2, FirstName = "Marusya1", LastName = "Lazorenko", BankAccount = 21435  },
                new Client { ClientId = 3, FirstName = "Marusya3", LastName = "Lazorenko", BankAccount = 52435  },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Client>>();
            mockSet.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(c => c.Clients).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            var clients = service.AllClientsSortedByBankAccount();
            Assert.AreEqual(3, clients.Count);
            Assert.AreEqual(12435, clients.FirstOrDefault().BankAccount);
        }

    }
}
