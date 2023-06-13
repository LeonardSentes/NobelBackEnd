using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelBackEnd.Models
{
    public class Prize
    {
        public Prize() 
        { 
            this.Laureates = new HashSet<Laureate>();
        }
        public int Id { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }

        //Navigation Properties
        public virtual ICollection<Laureate> Laureates { get; set; }
    }
}