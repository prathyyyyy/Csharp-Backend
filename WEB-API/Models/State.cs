using System.ComponentModel.DataAnnotations;

namespace WorldAPI.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Population { get; set; }

        public int CountriesID {  get; set; }
        public Countries Countries { get; set; }
    }
}
