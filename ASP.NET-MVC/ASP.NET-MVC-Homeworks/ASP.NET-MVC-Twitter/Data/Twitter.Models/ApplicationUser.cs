using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Twitter.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<ApplicationUser> _followers;
        private ICollection<Message> _messages;
        private ICollection<Notification> _notifications;
        private ICollection<Tweet> _tweets;

        public ApplicationUser()
        {
            this._followers = new HashSet<ApplicationUser>();
            this._messages = new HashSet<Message>();
            this._tweets = new HashSet<Tweet>();
            this._notifications = new HashSet<Notification>();
        }

        public virtual ICollection<ApplicationUser> Followers
        {
            get { return this._followers; }
            set { this._followers = value; }
        }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this._tweets; }
            set { this._tweets = value; }
        }

        public virtual ICollection<Message> Messages
        {
            get { return this._messages; }
            set { this._messages = value; }
        }

        public virtual ICollection<Notification> Notifications
        {
            get { return this._notifications; }
            set { this._notifications = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}