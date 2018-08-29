using System.ComponentModel.DataAnnotations;

namespace Twitter.MVC.Models
{
    public class TweetBindingModel
    {
        [Required]
        [MaxLength(140)]
        public string Text { get; set; }

        public int? ReplyToId { get; set; }
    }
}