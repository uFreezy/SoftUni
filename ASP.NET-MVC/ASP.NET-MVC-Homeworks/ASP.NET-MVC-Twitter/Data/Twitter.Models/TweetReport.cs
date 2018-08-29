using System;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class TweetReport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TweetId { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        [Required]
        [MaxLength(200)]
        public string Reason { get; set; }
    }
}