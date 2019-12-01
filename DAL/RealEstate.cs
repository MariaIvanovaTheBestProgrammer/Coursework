using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
    public class RealEstate
    {
        public RealEstate()
        {
            RealEstateSuggestions = new HashSet<RealEstateSuggestion>();
        }

        public int RealEstateId { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Type { get; set; }
        public virtual ICollection<RealEstateSuggestion> RealEstateSuggestions { get; set; }
        public override string ToString()
        {
            return String.Format($"ID: {RealEstateId,-5} Type: {Type,-30} Price: {Price,-10}");
        }
    }
}
