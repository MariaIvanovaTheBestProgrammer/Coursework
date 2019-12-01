using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BusinessLogic
    {
        private AgencyContext context;

        public BusinessLogic(AgencyContext context)
        {
            this.context = context;
        }
        public void AddClient(Client client)
        {
            context.Add(client);
            context.SaveChanges();
        }
        public void DeleteClient(Client client)
        {
            context.Clients.Remove(client);
            context.SaveChanges();
        }
        public Client FindClientById(int id)
        {
            return context.Clients.Where(e => e.ClientId == id).FirstOrDefault<Client>();
        }
        public ICollection<Client> FindClientsByFirstName(String name)
        {
            return context.Clients.Where(e => e.FirstName == name).ToList<Client>();
        }
        public ICollection<Client> FindClientsByLastName(String name)
        {
            return context.Clients.Where(e => e.LastName == name).ToList<Client>();
        }
        public Client FindClientByBankAccount(int bankAccount)
        {
            return context.Clients.Where(e => e.BankAccount == bankAccount).FirstOrDefault<Client>();
        }
        public ICollection<Client> AllClientsSortedByFirstName()
        {
            var data = context.Clients;
            return data.OrderBy(e => e.FirstName).ToList<Client>();
        }
        public ICollection<Client> AllClientsSortedByLastName()
        {
            return context.Clients.OrderBy(e => e.LastName).ToList<Client>();
        }
        public ICollection<Client> AllClientsSortedByBankAccount()
        {
            return context.Clients.OrderBy(e => e.BankAccount).ToList<Client>();
        }
        public void AddRealEstate(RealEstate realEstate)
        {
            context.Add(realEstate);
            context.SaveChanges();
        }
        public void DeleteRealEstate(RealEstate realEstate)
        {
            context.RealEstates.Remove(realEstate);
            context.SaveChanges();
        }
        public ICollection<RealEstate> FindRealEstatesByType(String name)
        {
            return context.RealEstates.Where(e => e.Type == name).ToList<RealEstate>();
        }
        public ICollection<RealEstate> FindRealEstatesByPrice(int price)
        {
            return context.RealEstates.Where(e => e.Price == price).ToList<RealEstate>();
        }
        public ICollection<RealEstate> AllRealEstatesSortedByType()
        {
            return context.RealEstates.OrderBy(e => e.Type).ToList<RealEstate>();
        }
        public ICollection<RealEstate> AllRealEstatesSortedByPrice()
        {
            return context.RealEstates.OrderBy(e => e.Price).ToList<RealEstate>();
        }
        public void AddSuggestion(Suggestion suggestion)
        {
            context.Add(suggestion);
            context.SaveChanges();
        }
        public void DeleteSuggestion(Suggestion suggestion)
        {
            context.Suggestions.Remove(suggestion);
            context.SaveChanges();
        }
        public ICollection<Suggestion> FindSuggestionsByClientId(int clientId)
        {
            return context.Suggestions.Where(e => e.Client.ClientId == clientId).ToList<Suggestion>();
        }

        public void AddRealEstateSuggestion(RealEstateSuggestion realEstateSuggestion)
        {
            context.Add(realEstateSuggestion);
            context.SaveChanges();
        }
        public void DeleteRealEstateSuggestion(RealEstateSuggestion realEstateSuggestion)
        {
            context.RealEstateSuggestions.Remove(realEstateSuggestion);
            context.SaveChanges();
        }
    }
}
