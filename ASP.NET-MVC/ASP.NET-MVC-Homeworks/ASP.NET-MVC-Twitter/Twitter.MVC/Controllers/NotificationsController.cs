using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.Models;
using Twitter.MVC.Hubs;
using Twitter.MVC.Models;

namespace Twitter.MVC.Controllers
{
    [Authorize]
    public class NotificationsController : BaseController
    {
        public ActionResult Index(int? id = null)
        {
            if (id != null)
            {
                //TODO: Single notification logic
            }

            return this.View("AllNotifications");
        }

        public ActionResult GetNotifications()
        {
            var userId = this.User.Identity.GetUserId();

            var notifications = this.Data.Notifications
                .Where(n => n.ReceiverId == userId)
                .OrderByDescending(n => n.PostedOn)
                .Select(n => new NotificationsViewModel
                {
                    Sender = n.Sender.UserName,
                    Receiver = n.Receiver.UserName,
                    Content = n.Content,
                    PostedOn = n.PostedOn
                });

            if (!notifications.Any())
            {
                return this.Content("No notifications!");
            }

            return this.PartialView("_GetNotifications", notifications);
            //return View("AllNotifications",notifications);
        }

        //TODO: Fix
        public ActionResult GetById(int id)
        {
            var userId = this.User.Identity.GetUserId();

            var notification = this.Data.Notifications
                .FirstOrDefault(n => n.Id == id && n.ReceiverId == userId);
            return this.View("SingleNotification", notification);
        }

        public void PostNotification(NotificationsBindingModel m)
        {
            if (!this.ModelState.IsValid)
            {
                return;
            }

            var notification = new Notification
            {
                SenderId = m.SenderId,
                ReceiverId = m.ReceiverId,
                Content = m.Content,
                PostedOn = DateTime.Now
            };

            this.Data.Notifications.Add(notification);

            this.Data.SaveChanges();

            var receiverName = this.Data.Users.FirstOrDefault(u => u.Id == m.ReceiverId).UserName;

            var hub = new NotificationsHub();
            hub.GetNotifications(receiverName);
        }
    }
}