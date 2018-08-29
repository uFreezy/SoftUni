using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Twitter.Models;

namespace Twitter.MVC.Models
{
    public class ProfileViewModel
    {
        [Required]
        public string Username { get; set; }

        //Enum would be better.
        public string IsFollowed { get; set; }

        public virtual ICollection<ApplicationUser> Followers { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}