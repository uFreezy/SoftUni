using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _06_Phonebook.Models
{
    public class Contact
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string SiteUrl { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

    }
}