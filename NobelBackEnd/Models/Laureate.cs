using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelBackEnd.Models
{
    public class Laureate
    {
        public Laureate() 
        {
            this.Prizes = new HashSet<Prize>();
        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime? Born { get; set; }
        public DateTime? Died { get; set; }
        public string Gender { get; set; }
        public string Borncountry { get; set; }

        //Navigation Properties
        public virtual ICollection<Prize> Prizes { get; set; }
    }
}