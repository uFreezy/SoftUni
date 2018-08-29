using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Messages.Data.Models
{
    public class ChannelMessage
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime DateSent { get; set; }

        [Required]
        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }

        public string SenderId { get; set; }

        public virtual User Sender { get; set; }


    }
}
