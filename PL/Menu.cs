using BLL;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PL
{
    public class Menu
    {
        private BusinessLogic businessLogic;
        public Menu()
        {
            businessLogic = new BusinessLogic(new AgencyContext());
        }
        public int menu()
        {
            //Console.Clear();
            Console.WriteLine("1 - Add client ");
            Console.WriteLine("2 - Print client list  ");
            Console.WriteLine("3 - Edit client by ID ");
            Console.WriteLine("4 - Delete client by ID ");
            Console.WriteLine("5 - Add real estate ");
            Console.WriteLine("6 - Edit real estate by ID ");
            Console.WriteLine("7 - Delete real estate");
            Console.WriteLine("8 - Print real estate list ");
            Console.WriteLine("9 - Print clients by key word ");
            Console.WriteLine("10 - Print real estates by key word ");
            Console.WriteLine("11 - Add suggestion ");
            Console.WriteLine("12 - Print suggestion by ID ");
            Console.WriteLine("13 - Edit suggestion by ID ");
            Console.WriteLine("14 - Delete suggestion by ID");
            Console.WriteLine("99 - exit: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public void addClient()
        {
            Console.Clear();
            try
            {
                
                Console.WriteLine("Enter first name ");
                String fName = Console.ReadLine();
                Console.WriteLine("Enter last name ");
                String lName = Console.ReadLine();
                Console.WriteLine("Enter bank account ");
                int account = Convert.ToInt32(Console.ReadLine());
                Client client = new Client { FirstName = fName, LastName = lName, BankAccount = account};
                businessLogic.AddClient(client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }
        }
        public void editClient()
        {
            Console.Clear();
            Console.WriteLine("Enter client ID ");
            int id = Convert.ToInt32(Console.ReadLine());
            
            try
            {
                Client client = businessLogic.FindClientById(id);
                Console.WriteLine("Enter first name ");
                String fName = Console.ReadLine();
                Console.WriteLine("Enter last name ");
                String lName = Console.ReadLine();
                Console.WriteLine("Enter bank account ");
                int account = Convert.ToInt32(Console.ReadLine());
                client.FirstName = fName;
                client.LastName = lName; 
                client.BankAccount = account ;
                businessLogic.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }
        }
        public void deleteClient()
        {
            Console.Clear();
            Console.WriteLine("Enter client ID ");
            int id = Convert.ToInt32(Console.ReadLine());
            
            try
            {
                Client client = businessLogic.FindClientById(id);
                businessLogic.DeleteClient(client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }
        }
        public void addRealEstate()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Enter real estate type ");
                String reType = Console.ReadLine();
                Console.WriteLine("Enter real estate price ");
                int rePrice = Convert.ToInt32(Console.ReadLine());
                RealEstate realEstate = new RealEstate { Price = rePrice, Type =reType };
                businessLogic.AddRealEstate(realEstate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }
        }
        public void editRealEstate()
        {
            Console.Clear();
            Console.WriteLine("Enter real estate ID ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                RealEstate realEstate = businessLogic.FindRealEstateById(id);
                Console.WriteLine("Enter type ");
                String retype = Console.ReadLine();
                Console.WriteLine("Enter price ");
                int  reprice = Convert.ToInt32(Console.ReadLine());
                realEstate.Price = reprice;
                realEstate.Type = retype;
                businessLogic.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }
        }
        public void deleteRealEstate()
        {
            Console.Clear();
            Console.WriteLine("Enter real estate ID ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                RealEstate realEstate = businessLogic.FindRealEstateById(id);
                businessLogic.DeleteRealEstate(realEstate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }
        }
        public void printRealEstateByKeyWord()
        {
            Console.WriteLine("1 - find real estate by key word in type");
            Console.WriteLine("2 - find real estate by price");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                Console.WriteLine("Please, enter key word");
                String s = Console.ReadLine();
                foreach (RealEstate re in businessLogic.ContainsRealEsateByKeyWordInType(s))
                {
                    Console.WriteLine(re.ToString());
                }
            }
            if (num == 2)
            {
                Console.WriteLine("Please, enter price limits(from, to)");
                int from = Convert.ToInt32(Console.ReadLine());
                int to = Convert.ToInt32(Console.ReadLine());
                foreach (RealEstate re in businessLogic.AllRealEstatesSortedByPrice())
                {
                   if(re.Price>=from && re.Price<=to) Console.WriteLine(re.ToString());
                }
            }
        }
        public void printRealEstateData()
        {
            foreach (RealEstate re in businessLogic.AllRealEstatesSortedByPrice())
            {
                Console.WriteLine(re.ToString());
            }
        }
        public void printClientData()
        {
            foreach (Client c in businessLogic.AllClientsSortedByFirstName())
            {
                Console.WriteLine(c.ToString());
            }
        }

        public void printClientByKeyWord()
        {
            Console.WriteLine("1 - find client by key word in firstname");
            Console.WriteLine("2 - find client by key in lastname");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                Console.WriteLine("Please, enter key word");
                String s = Console.ReadLine();
                foreach (Client c in businessLogic.ContainsClientsByKeyWordInFirstName(s))
                {
                    Console.WriteLine(c.ToString());
                }
            }
            if (num == 2)
            {
                Console.WriteLine("Please, enter key word");
                String s = Console.ReadLine();
                foreach (Client c in businessLogic.ContainsClientsByKeyWordInLastName(s))
                {
                    Console.WriteLine(c.ToString());
                }
            }
        }
        public void addSuggestion()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Enter client ID ");
                int id = Convert.ToInt32(Console.ReadLine());
                Client client = searchClientByID(id);
                Console.WriteLine("Enter number of real estates (1-4) ");
                int number = Convert.ToInt32(Console.ReadLine());
                Suggestion s = new Suggestion { Client = client };
                businessLogic.AddSuggestion(s);
                for(int i=0; i<number; i++)
                {
                    Console.WriteLine("Enter real estate ID ");
                    int reID = Convert.ToInt32(Console.ReadLine());
                    RealEstate realEstate = searchRealEstateByID(reID);
                    RealEstateSuggestion res = new RealEstateSuggestion { Suggestion = s, RealEstate = realEstate };
                    businessLogic.AddRealEstateSuggestion(res);
                    realEstate.RealEstateSuggestions.Add(res);
                    s.RealEstateSuggestions.Add(res);
                }
                businessLogic.Commit();
            }
            catch (Exception e)
            {   
                Console.WriteLine(e.Message);
                Console.Write("Press Eneter key to continue.. ");
                Console.ReadLine();
            }
        }
        public void printSuggestion()
        {
            Console.WriteLine("Enter suggestion ID ");
            int suggestionId = Convert.ToInt32(Console.ReadLine());
            foreach (Suggestion s in businessLogic.FindSuggestionsByClientId(suggestionId)){
                Console.WriteLine("Suggestion Id: " + s.SuggestionId);
                Client c = businessLogic.FindClientById(suggestionId);
                Console.WriteLine(c.ToString());
                foreach(RealEstateSuggestion res in s.RealEstateSuggestions)
                {
                    RealEstate re = businessLogic.FindRealEstateById(res.RealEstateId);
                    Console.WriteLine(re.ToString());
                }
                    
            }
        }
        public void editSuggestion()
        {
            Console.WriteLine("Enter suggestion ID ");
            int suggestionId = Convert.ToInt32(Console.ReadLine());
            Suggestion s = businessLogic.FindSuggestionById(suggestionId);
            Client c = businessLogic.FindClientById(s.Client.ClientId);
            Console.WriteLine(c.ToString());
            foreach (RealEstateSuggestion res in s.RealEstateSuggestions)
            {
                RealEstate re = businessLogic.FindRealEstateById(res.RealEstateId);
                Console.WriteLine(re.ToString());
            }
            Console.WriteLine("Enter real estate ID ");
            int reID = Convert.ToInt32(Console.ReadLine());
            foreach (RealEstateSuggestion res in s.RealEstateSuggestions)
            {
                if (res.RealEstateId == reID)
                {
                    businessLogic.DeleteRealEstateSuggestion(res);
                    break;
                }
            }
        }
        public void deleteSuggestion()
        {
            Console.WriteLine("Enter suggestion ID ");
            int suggestionId = Convert.ToInt32(Console.ReadLine());
            Suggestion s = businessLogic.FindSuggestionById(suggestionId);
            businessLogic.DeleteSuggestion(s);
        }
        public ICollection<Client> searchClientByFirstName(string fname)
        {
            return businessLogic.FindClientsByFirstName(fname);
        }
        public ICollection<Client> searchClientByLastName(string lname)
        {
            return businessLogic.FindClientsByLastName(lname);
        }
        public Client searchClientByCard(int card)
        {
            return businessLogic.FindClientByBankAccount(card);
        }
        public Client searchClientByID(int id)
        {
            return businessLogic.FindClientById(id);
        }
        public RealEstate searchRealEstateByID(int id)
        {
            return businessLogic.FindRealEstateById(id); 
        }
        public ICollection<RealEstate> searchRealEstateByType(string type)
        {
            return businessLogic.FindRealEstatesByType(type);
        }
        public ICollection<RealEstate> searchRealEstateByPrice(int price)
        {
            return businessLogic.FindRealEstatesByPrice(price);
        }
    }
}
