using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Twitter.MVC.Models
{
    public class TweetViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        [Required]
        public string Username { get; set; }

        public virtual IEnumerable<ReplyViewModel> Replies { get; set; }
    }
}