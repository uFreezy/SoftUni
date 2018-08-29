using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATM.Models
{
    public class CardAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        [Column(TypeName = "Char")]
        public string CardNumber { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        [Column(TypeName = "Char")]
        public string CardPIN { get; set; }
        
        [Required]
        [Column(TypeName = "Money")]
        public decimal CardCash { get; set; }
 
    }
}