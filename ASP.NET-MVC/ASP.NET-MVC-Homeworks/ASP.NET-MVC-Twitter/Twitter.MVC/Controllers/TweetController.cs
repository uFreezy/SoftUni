using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Twitter.Models;
using Twitter.MVC.Hubs;
using Twitter.MVC.Models;

namespace Twitter.MVC.Controllers
{
    [System.Web.Mvc.Authorize]
    public class TweetController : BaseController
    {
        public ActionResult GetTweets(int startIndex = 0, int pageSize = 10)
        {
            if (!this.Data.Tweets.Any())
            {
                return this.Content("<h1>No Tweets!</h1>");
            }

            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (this.Data.Tweets.Count() < startIndex)
            {
                if (this.Data.Tweets.Count() - pageSize < 0)
                {
                    startIndex = 0;
                }
                else
                {
                    startIndex = this.Data.Tweets.Count() - pageSize;
                }
            }

            // If user is logged
            // Repeating code, I know, I know.
            if (this.User.Identity.GetUserId() != null)
            {
                var userId = this.User.Identity.GetUserId();

                var user = this.Data.Users
                    .FirstOrDefault(u => u.Id == userId);

                var tweets = this.Data.Tweets
                    .Where(t => t.Author.Followers.Any(f => f.Id == userId)
                                && !t.ReplyToId.HasValue
                                || t.AuthorId == userId)
                    .OrderByDescending(t => t.PostedOn)
                    .Skip(startIndex)
                    .Take(pageSize)
                    .Select(t => new TweetViewModel
                    {
                        Id = t.Id,
                        Text = t.Text,
                        PostedOn = t.PostedOn,
                        Username = t.Author.UserName,
                        Replies = t.Replies.Select(r => new ReplyViewModel
                        {
                            Text = r.Text,
                            PostedOn = r.PostedOn,
                            Username = r.Author.UserName
                        })
                    });

                if (!tweets.Any())
                {
                    return this.Content("<h1>No Tweets!</h1>");
                }

                this.ViewBag.StartIndex = startIndex;
                this.ViewBag.PageSize = pageSize;

                return this.PartialView("_GetTweets", tweets);
            }

            else
            {
                var tweets = this.Data.Tweets
                    .Where(t => t.ReplyToId == null)
                    .OrderByDescending(t => t.PostedOn)
                    .Skip(startIndex)
                    .Take(pageSize)
                    .Select(t => new TweetViewModel
                    {
                        Id = t.Id,
                        Text = t.Text,
                        PostedOn = t.PostedOn,
                        Username = t.Author.UserName,
                        Replies = t.Replies.Select(r => new ReplyViewModel
                        {
                            Text = r.Text,
                            PostedOn = r.PostedOn,
                            Username = r.Author.UserName
                        })
                    });

                this.ViewBag.StartIndex = startIndex;
                this.ViewBag.PageSize = pageSize;

                return this.PartialView("_GetTweets", tweets);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostTweet(TweetBindingModel m)
        {
            if (string.IsNullOrEmpty(m.Text))
            {
                return this.RedirectToAction("Index", "Home");
            }

            var userId = this.User.Identity.GetUserId();

            var tweet = this.Data.Tweets.Add(new Tweet
            {
                Text = m.Text,
                AuthorId = userId,
                ReplyToId = m.ReplyToId,
                PostedOn = DateTime.Now
            });

            if (tweet.ReplyToId != null)
            {
                var addReply = this.Data.Tweets.FirstOrDefault(t => t.Id == tweet.ReplyToId);

                addReply.Replies.Add(tweet);
            }

            this.Data.SaveChanges();

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<TweetHub>();
            hubContext.Clients.All.receiveTweets();

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Retweet(int tweetId)
        {
            var userId = this.User.Identity.GetUserId();

            if (!this.Data.Retweets.Any(r => r.TweetId == tweetId && r.UserId == userId))
            {
                this.Data.Retweets.Add(new Retweet
                {
                    TweetId = tweetId,
                    UserId = userId
                });

                this.Data.SaveChanges();
            }

            var addNotification = new NotificationsController();

            addNotification.PostNotification(new NotificationsBindingModel
            {
                ReceiverId = this.Data.Tweets.FirstOrDefault(t => t.Id == tweetId).AuthorId,
                Content = "Retweeted your tweet.",
                SenderId = userId
            });

            //TODO: Add the retweeted tweet to the person who retweeted it.

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Favourite(int tweetId)
        {
            var userId = this.User.Identity.GetUserId();

            if (!this.Data.Favourites.Any(r => r.TweetId == tweetId && r.UserId == userId))
            {
                this.Data.Favourites.Add(new Favourite
                {
                    TweetId = tweetId,
                    UserId = userId
                });

                this.Data.SaveChanges();
            }

            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Report(int tweetId, string reason)
        {
            var userId = this.User.Identity.GetUserId();

            this.Data.TweetReports.Add(new TweetReport
            {
                TweetId = tweetId,
                PostedOn = DateTime.Now,
                Reason = reason
            });

            this.Data.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }
    }
}