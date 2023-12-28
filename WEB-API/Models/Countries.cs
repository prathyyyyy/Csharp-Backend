using System.ComponentModel.DataAnnotations;

namespace WorldAPI.Models
{
    public class Countries
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string CountryName { get; set; }
        [Required]
        [MaxLength(5)]
        public string CountrySmallName { get; set; }
        [Required]
        [MaxLength(10)]
        public string CountryCode { get; set; }
    }
}
