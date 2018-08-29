using System;
using System.Linq;
using System.Web.Http;
using Messages.Data.Models;
using Messages.RestServices.Models.BindingModels;
using Messages.RestServices.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace Messages.RestServices.Controllers
{
    public class ChannelMessagesController : BaseApiController
    {
        //GET /api/channel-messages/{channelName}
        [HttpGet]
        [Route("api/channel-messages/{channelName}")]
        public IHttpActionResult GetChannelMessages(string channelName)
        {
            if (!Data.Channels.Any(c => c.Name == channelName))
                return NotFound();

            var channelMessages = Data.ChannelMessages.Select(cm => new ChannelMessagesViewModel
            {
                Id = cm.Id,
                Text = cm.Text,
                DateSent = cm.DateSent,
                Sender = cm.Sender.UserName
            })
                .OrderByDescending(cm => cm.DateSent);

            return Ok(channelMessages);
        }

        //GET /api/channel-messages/{channel}?limit={limit}
        [HttpGet]
        [Route("api/channel-messages/{channel}")]
        public IHttpActionResult GetChannelMessagesWithLimit(string channel, int limit)
        {
            if (!Data.Channels.Any(c => c.Name == channel))
                return NotFound();

            if (limit <= 0 || limit > 1000)
                return BadRequest();

            var messages = Data.ChannelMessages
                .Where(cm => cm.Channel.Name == channel)
                .OrderByDescending(cm => cm.DateSent)
                .Take(limit)
                .Select(cm => new ChannelMessagesViewModel
                {
                    Id = cm.Id,
                    Text = cm.Text,
                    DateSent = cm.DateSent,
                    Sender = cm.Sender.UserName
                });

            return Ok(messages);
        }

        //POST /api/channel-messages/{channel-name}
        [HttpPost]
        [Route("api/channel-messages/{channelName}")]
        public IHttpActionResult PostMessagesToChannel(string channelName, ChannelMessagesBindingModel m)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrEmpty(channelName))
                return BadRequest();

            if (!Data.Channels.Any(c => c.Name == channelName))
                return NotFound();

            var channelId = Data.Channels.First(c => c.Name == channelName).Id;

            var message = new ChannelMessage
            {
                Text = m.Text,
                DateSent = DateTime.Now,
                ChannelId = channelId
            };

            Data.ChannelMessages.Add(message);

            Data.SaveChanges();

            return Ok(new
            {
                message.Id,
                Message = "Anonymous message sent to channel " + channelName + "."
            });
        }
    }
}