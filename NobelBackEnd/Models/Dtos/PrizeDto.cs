using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelBackEnd.Models.Dtos
{
    public class PrizeDto
    {
        public PrizeDto()
        {
        }

        public PrizeDto(Prize prize) 
        {
            Id = prize.Id;
            Category= prize.Category;
            Year= prize.Year;
            Laureates = prize.Laureates.Select(laureate => new LaureateDto()
            {
                Id = laureate.Id,
                Borncountry = laureate.Borncountry,
                Firstname = laureate.Firstname,
                Gender = laureate.Gender,
                Surname = laureate.Surname,
            }) as List<LaureateDto>;
                

        }
        public int Id { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public List<LaureateDto> Laureates { get; set; }
    }
}