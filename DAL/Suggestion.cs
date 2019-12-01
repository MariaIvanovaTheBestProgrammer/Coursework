using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Suggestion
    {
        public Suggestion()
        {
            RealEstateSuggestions = new HashSet<RealEstateSuggestion>();
        }

        public int SuggestionId { get; set; }
        public Client Client { get; set; }
        public virtual ICollection<RealEstateSuggestion> RealEstateSuggestions { get; set; }

        public override string ToString()
        {
            return String.Format($"Client: {Client,-80}");
        }
    }
}
