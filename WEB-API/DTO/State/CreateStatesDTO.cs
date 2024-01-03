using WorldAPI.Models;

namespace WorldAPI.DTO.State
{
    public class CreateStatesDTO
    {
        
        public string Name { get; set; }
        public double Population { get; set; }

        public int CountriesID { get; set; }

        
    }
}
