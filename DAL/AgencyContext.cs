using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class AgencyContext : DbContext
    {
        private static bool _created = false;
        public AgencyContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<RealEstateSuggestion> RealEstateSuggestions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealEstateSuggestion>().HasKey(res => new { res.SuggestionId, res.RealEstateId });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=d:/agency.db");
    }
}
