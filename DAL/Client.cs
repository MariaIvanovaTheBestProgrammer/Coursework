using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
    public class Client
    {
        public Client()
        {
            Suggestions = new HashSet<Suggestion>();
        }

        public int ClientId { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        public int BankAccount { get; set; }
        public virtual ICollection<Suggestion> Suggestions { get; set; }
        public override string ToString()
        {
            return String.Format($"ID: {ClientId,-5} FirstName: {FirstName,-30} LastName: {LastName,-30}");
        }
    }
}
