using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DAL;
using Microsoft.EntityFrameworkCore;
using BLL;

namespace UnitTestProject
{
    [TestClass]
    public class NonQueryTest
    {
        [TestMethod]
        public void CreateClient_saves_a_client_via_context()
        {
            var mockSet = new Mock<DbSet<Client>>();

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(m => m.Clients).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            service.AddClient(new Client { FirstName = "Marusya", LastName = "Lazorenko", BankAccount = 12435 });

            mockSet.Verify(m => m.Add(It.IsAny<Client>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [TestMethod]
        public void DeleteClient_deletes_a_client_via_context()
        {
            var mockSet = new Mock<DbSet<Client>>();

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(m => m.Clients).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            Client client = new Client { FirstName = "Marusya", LastName = "Lazorenko", BankAccount = 12435 };
            service.DeleteClient(client);
            mockSet.Verify(m => m.Remove(It.IsAny<Client>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
            [TestMethod]
            public void CreateRealEstate_saves_a_client_via_context()
            {
                var mockSet = new Mock<DbSet<RealEstate>>();

                var mockContext = new Mock<AgencyContext>();
                mockContext.Setup(m => m.RealEstates).Returns(mockSet.Object);

                var service = new BusinessLogic(mockContext.Object);
                service.AddRealEstate(new RealEstate {Type = "3-room flat", Price = 50000});

                mockSet.Verify(m => m.Add(It.IsAny<RealEstate>()), Times.Once());
                mockContext.Verify(m => m.SaveChanges(), Times.Once());
            }
            [TestMethod]
            public void DeleteRealEstate_deletes_a_realestate_via_context()
            {
                var mockSet = new Mock<DbSet<RealEstate>>();

                var mockContext = new Mock<AgencyContext>();
                mockContext.Setup(m => m.RealEstates).Returns(mockSet.Object);

                var service = new BusinessLogic(mockContext.Object);
                RealEstate realEstate = new RealEstate { Type = "3-room flat", Price = 50000 };
                
                service.DeleteRealEstate(realEstate);
                mockSet.Verify(m => m.Remove(It.IsAny<RealEstate>()), Times.Once());
                mockContext.Verify(m => m.SaveChanges(), Times.Once());
            }
        [TestMethod]
        public void CreateSuggestion_saves_a_suggestion_via_context()
        {
            var mockSet = new Mock<DbSet<Suggestion>>();

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(m => m.Suggestions).Returns(mockSet.Object);
            Client client = new Client { FirstName = "Marusya", LastName = "Lazorenko", BankAccount = 12435 };
            var service = new BusinessLogic(mockContext.Object);
            service.AddSuggestion(new Suggestion { Client = client, SuggestionId = 1 });

            mockSet.Verify(m => m.Add(It.IsAny<Suggestion>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        [TestMethod]
        public void DeleteSuggestion_deletes_a_client_via_context()
        {
            var mockSet = new Mock<DbSet<Suggestion>>();

            var mockContext = new Mock<AgencyContext>();
            mockContext.Setup(m => m.Suggestions).Returns(mockSet.Object);

            var service = new BusinessLogic(mockContext.Object);
            Client client = new Client { FirstName = "Marusya", LastName = "Lazorenko", BankAccount = 12435 };
            Suggestion suggestion = new Suggestion { Client = client, SuggestionId =1 };
            service.DeleteSuggestion(suggestion);
            mockSet.Verify(m => m.Remove(It.IsAny<Suggestion>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
       

    }
}
