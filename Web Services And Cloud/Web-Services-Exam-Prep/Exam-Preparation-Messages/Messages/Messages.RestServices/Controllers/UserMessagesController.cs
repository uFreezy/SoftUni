using System;
using System.Linq;
using System.Web.Http;
using Messages.Data.Models;
using Messages.RestServices.Models.BindingModels;
using Messages.RestServices.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.SqlServer.Server;

namespace Messages.RestServices.Controllers
{
    public class UserMessagesController : BaseApiController
    {
        //GET /api/user/personal-messages
        [HttpGet]
        [Authorize]
        [Route("api/user/personal-messages")]
        public IHttpActionResult GetPersonalMessages()
        {
            var uId = User.Identity.GetUserId();

            var messages = Data.UserMessages
                .Where(um => um.ReceiverId == uId)
                .OrderByDescending(um => um.DateSent)
                .Select(um => new UserMessagesViewModel
                {
                    Id = um.Id,
                    Text = um.Text,
                    DateSent = um.DateSent,
                    Sender = um.Sender.UserName
                });

            return Ok(messages);
        }

        //POST /api/user/personal-messages
        [HttpPost]
        [Route("api/user/personal-messages")]
        public IHttpActionResult SendUserMessages(UserMessagesBindingModel m)
        {
            if (!ModelState.IsValid ||
                !Data.Users.Any(u => u.UserName == m.Recipient) ||
                string.IsNullOrEmpty(m.Text.Trim()))
                return BadRequest();


            if (User.Identity.GetUserName() != null)
            {
                var message = new UserMessage
                {
                    ReceiverId = Data.Users.First(u => u.UserName == m.Recipient).Id,
                    SenderId = User.Identity.GetUserId(),
                    Text = m.Text,
                    DateSent = DateTime.Now
                };

                Data.UserMessages.Add(message);

                Data.SaveChanges();

                return Ok(new
                {
                    message.Id,
                    Sender = User.Identity.GetUserName(),
                    Message = "Message sent successfully to user " + m.Recipient + "."
                });
            }

            else
            {
                var message = new UserMessage
                {
                    ReceiverId = Data.Users.First(u => u.UserName == m.Recipient).Id,
                    Text = m.Text,
                    DateSent = DateTime.Now
                };

                Data.UserMessages.Add(message);

                Data.SaveChanges();

                return Ok(new
                {
                    message.Id,
                    Message = "Anonymous message sent successfully to user " + m.Recipient + "."
                });
            }
        }
    }
}