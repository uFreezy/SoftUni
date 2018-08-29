﻿using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Favourite
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}