using System.ComponentModel.DataAnnotations;

namespace Ajax.Models
{
    public class City
    {
        [Key]
        [Required]
        public string CityName { get; set; }
    }
}