using System.ComponentModel.DataAnnotations;

namespace WorldAPI.DTO.Country
{
    public class CreateCountryDTO
    {
       
        
        public string CountryName { get; set; }
        
        public string CountrySmallName { get; set; } 
        
        public string CountryCode { get; set; }
    }
}
