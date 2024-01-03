using WorldAPI.Models;

namespace WorldAPI.DTO.State
{
    public class StatesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }

        public int CountryID { get; set; }

      
    }
}
