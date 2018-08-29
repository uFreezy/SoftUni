using System.ComponentModel.DataAnnotations;

namespace _06_Phonebook.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [Required]  
        public string PhoneNumber { get; set; }
    }
}