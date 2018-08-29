using System;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public virtual ApplicationUser Receiver { get; set; }

        [Required]
        public DateTime SentOn { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }

        //public bool IsSeen { get; set; }
    }
}