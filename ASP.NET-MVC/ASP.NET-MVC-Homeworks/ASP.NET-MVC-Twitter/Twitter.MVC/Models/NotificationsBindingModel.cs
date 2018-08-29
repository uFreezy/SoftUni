using System.ComponentModel.DataAnnotations;

namespace Twitter.MVC.Models
{
    public class NotificationsBindingModel
    {
        [Required]
        public string SenderId { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}