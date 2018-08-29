using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Twitter.MVC.Models;

namespace Twitter.MVC.Controllers
{
    public class UserController : BaseController
    {
        [Authorize]
        [ActionName("Profile")]
        public ActionResult UserProfile(string userName)
        {
            var userId = this.User.Identity.GetUserId();

            if (userName.IsNullOrWhiteSpace())
            {
                userName = this.User.Identity.GetUserName();
            }

            if (!this.Data.Users.Any(u => u.UserName == userName))
            {
                return this.View("~/Views/Shared/Error.cshtml");
            }

            var user = this.Data.Users
                .Select(u => new ProfileViewModel
                {
                    Username = u.UserName,
                    Followers = u.Followers,
                    Tweets = u.Tweets,
                    //Enum would be better.
                    IsFollowed = "Follow"
                })
                .FirstOrDefault(u => u.Username == userName);

            if (this.Data.Users
                .FirstOrDefault(u => u.UserName == userName)
                .Followers
                .Any(f => f.Id == userId))
            {
                user.IsFollowed = "Unfollow";
            }

            else if (this.Data.Users.FirstOrDefault(u => u.UserName == userName).Id == userId)
            {
                user.IsFollowed = null;
            }

            return this.View("Profile", user);
        }

        public ActionResult Follow(string userName)
        {
            var curUserId = this.User.Identity.GetUserId();

            var userToFollow = this.Data.Users
                .FirstOrDefault(u => u.UserName == userName);

            if (userToFollow != null)
            {
                userToFollow.Followers
                    .Add(this.Data.Users.FirstOrDefault(u => u.Id == curUserId));

                this.Data.SaveChanges();
            }

            return this.RedirectToAction("Profile", "User", new {userName});
        }

        public ActionResult Unfollow(string userName)
        {
            var curUserId = this.User.Identity.GetUserId();

            var userToUnFollow = this.Data.Users
                .FirstOrDefault(u => u.UserName == userName);

            if (userToUnFollow != null)
            {
                userToUnFollow.Followers
                    .Remove(this.Data.Users.FirstOrDefault(u => u.Id == curUserId));

                this.Data.SaveChanges();
            }

            return this.RedirectToAction("Profile", "User", new {userName});
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return this.View("EditProfile");
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(UserProfileBindingModel m)
        {
            var userId = this.User.Identity.GetUserId();

            var user = this.Data.Users.FirstOrDefault(u => u.Id == userId);

            if (!this.ModelState.IsValid || user == null)
            {
                return this.RedirectToAction("UserProfile", user.UserName);
            }

            if (!m.UserName.IsNullOrWhiteSpace())
                user.UserName = m.UserName;

            if (!m.Password.IsNullOrWhiteSpace())
            {
                var passHash = new PasswordHasher();
                user.PasswordHash = passHash.HashPassword(m.Password);
            }

            this.Data.SaveChanges();

            return this.RedirectToAction("Profile", new {userName = user.UserName});
        }
    }
}