using System.ComponentModel.DataAnnotations;

namespace Twitter.MVC.Models
{
    public class MessageBindingModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
    }
}