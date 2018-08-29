using System;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Notification
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
        public DateTime PostedOn { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        //[Required]

        //public bool IsSeen { get; set; }
    }
}