using System.ComponentModel.DataAnnotations;

namespace Twitter.MVC.Models
{
    public class MessageViewModel
    {
        [Required]
        public string Sender { get; set; }

        [Required]
        public int MessageCount { get; set; }

        //[Required]

        //public DateTime SentOn { get; set; }

        //[Required]
        //[MaxLength(200)]
        //public bool IsSeen { get; set; }
    }
}