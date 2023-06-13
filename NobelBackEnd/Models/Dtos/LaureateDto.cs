using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace NobelBackEnd.Models.Dtos

{
    public class LaureateDto
    {
        public LaureateDto()
        {
        }

        public LaureateDto(Laureate laureate)
        {
            Id = laureate.Id;
            Borncountry = laureate.Borncountry;
            Firstname = laureate.Firstname;
            Gender = laureate.Gender;
            Surname = laureate.Surname;
            
            Prizes = laureate.Prizes.Select(prize => new PrizeDto()
            {
                Id = prize.Id,
                Category = prize.Category,
                Year = prize.Year,
            }) as List<PrizeDto>;


        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Borncountry { get; set; }
        public List<PrizeDto> Prizes { get; set; }
    }
}
