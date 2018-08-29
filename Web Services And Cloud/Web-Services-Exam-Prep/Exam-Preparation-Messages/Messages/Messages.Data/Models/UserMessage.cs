using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Messages.Data.Models
{
    public class UserMessage
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime DateSent { get; set; }

        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        public virtual User Receiver { get; set; }
    }
}
