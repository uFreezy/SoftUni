using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Twitter.Models;
using Twitter.MVC.Models;

namespace Twitter.MVC.Controllers
{
    [Authorize]
    public class MessagesController : BaseController
    {
        [ActionName("UserMessages")]
        public ActionResult GetAllByUserName()
        {
            var userId = this.User.Identity.GetUserId();
            var userName = this.User.Identity.GetUserName();

            var messages = this.Data.Messages
                .Where(m => m.ReceiverId == userId)
                .GroupBy(g => g.Sender.UserName)
                .Select(m => new MessageViewModel
                {
                    Sender = m.Key,
                    MessageCount = m.Count()
                });

            return this.View("~/Views/Messages/Messages.cshtml", messages);
        }

        public ActionResult GetConversation(string friendName)
        {
            var userId = this.User.Identity.GetUserId();

            var friendId = this.Data.Users.FirstOrDefault(u => u.UserName == friendName).Id;

            var conversation = this.Data.Messages
                .Where(m => (m.ReceiverId == friendId && m.SenderId == userId) ||
                            (m.ReceiverId == userId && m.SenderId == friendId))
                .OrderBy(m => m.SentOn)
                .Select(m => new DiscussionViewModel
                {
                    UserName = m.Sender.UserName,
                    Text = m.Text,
                    SentOn = m.SentOn
                });

            return this.View("~/Views/Messages/Conversation.cshtml", conversation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostMessage(MessageBindingModel m)
        {
            var userId = this.User.Identity.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("UserMessages", "Messages");
            }

            if (!this.Data.Users.Any(u => u.UserName == m.UserName))
            {
                return this.RedirectToAction("UserMessages", "Messages");
            }

            this.Data.Messages.Add(new Message
            {
                ReceiverId = this.Data.Users
                    .FirstOrDefault(u => u.UserName == m.UserName).Id,
                SenderId = userId,
                Text = m.Text,
                SentOn = DateTime.Now
            });

            this.Data.SaveChanges();

            return this.RedirectToAction("UserMessages", "Messages");
        }

        public ActionResult DeleteMessage()
        {
            return this.RedirectToAction("UserMessages", "Messages");
        }
    }
}