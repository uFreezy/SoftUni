using System.ComponentModel.DataAnnotations;

namespace _06_Phonebook.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmailAdress { get; set; }
    }
}