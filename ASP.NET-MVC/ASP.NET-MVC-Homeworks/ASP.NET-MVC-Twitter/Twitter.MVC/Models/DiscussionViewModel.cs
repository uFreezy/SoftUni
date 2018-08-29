using System;
using System.ComponentModel.DataAnnotations;

namespace Twitter.MVC.Models
{
    public class DiscussionViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public DateTime SentOn { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
    }
}