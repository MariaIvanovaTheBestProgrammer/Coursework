using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IAgencyContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<RealEstateSuggestion> RealEstateSuggestions { get; set; }
        int SaveChanges();
    }
}
