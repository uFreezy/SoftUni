using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Tweet
    {
        private ICollection<Favourite> _favourites;
        private ICollection<Tweet> _replies;
        private ICollection<Retweet> _retweets;
        private ICollection<TweetReport> _tweetReports;

        public Tweet()
        {
            this._tweetReports = new HashSet<TweetReport>();
            this._favourites = new HashSet<Favourite>();
            this._retweets = new HashSet<Retweet>();
            this._replies = new HashSet<Tweet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        [Required]
        [MaxLength(140)]
        public string Text { get; set; }

        public int? ReplyToId { get; set; }

        public virtual Tweet ReplyTo { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<TweetReport> TweetReports
        {
            get { return this._tweetReports; }
            set { this._tweetReports = value; }
        }

        public virtual ICollection<Favourite> Favourites
        {
            get { return this._favourites; }
            set { this._favourites = value; }
        }

        public virtual ICollection<Retweet> Retweets
        {
            get { return this._retweets; }
            set { this._retweets = value; }
        }

        public virtual ICollection<Tweet> Replies
        {
            get { return this._replies; }
            set { this._replies = value; }
        }
    }
}