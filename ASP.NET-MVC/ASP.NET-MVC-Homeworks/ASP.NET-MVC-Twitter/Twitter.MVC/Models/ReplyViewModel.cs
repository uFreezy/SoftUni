using System;
using System.ComponentModel.DataAnnotations;

namespace Twitter.MVC.Models
{
    public class ReplyViewModel
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        [Required]
        public string Username { get; set; }
    }
}