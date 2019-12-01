using System;
using System.Linq;

namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AgencyContext())
            {
                // Create
                Console.WriteLine("Inserting a new Client");
                Client c = new Client { FirstName = "Irina", LastName = "Ivanova", BankAccount = 0987654321 };
                RealEstate re1 = new RealEstate { Price = 19000, Type = "1-room flat" };
                RealEstate re2 = new RealEstate { Price = 28500, Type = "2-room flat" };
                RealEstate re3 = new RealEstate { Price = 30000, Type = "3-room flat" };
                RealEstate re4 = new RealEstate { Price = 35000, Type = "4-room flat" };
                Suggestion suggestion = new Suggestion
                {
                    Client = c
                };
                RealEstateSuggestion res1 = new RealEstateSuggestion
                {
                    RealEstate = re1,
                    Suggestion = suggestion
                };
                RealEstateSuggestion res2 = new RealEstateSuggestion
                {
                    RealEstate = re2,
                    Suggestion = suggestion
                };
                RealEstateSuggestion res3 = new RealEstateSuggestion
                {
                    RealEstate = re3,
                    Suggestion = suggestion
                };
                RealEstateSuggestion res4 = new RealEstateSuggestion
                {
                    RealEstate = re4,
                    Suggestion = suggestion
                };
                db.Add(c);
                db.Add(re1);
                db.Add(re2);
                db.Add(re3);
                db.Add(re4);
                db.Add(suggestion);
                db.Add(res1);
                db.Add(res2);
                db.Add(res3);
                db.Add(res4);
                db.SaveChanges();
                var blog = db.Clients;
                var s = db.Suggestions;
                var res = db.RealEstates;
            }
        }
    }
}
