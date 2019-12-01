using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class RealEstateSuggestion
    {
        public int SuggestionId { get; set; }
        public Suggestion Suggestion { get; set; }

        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
