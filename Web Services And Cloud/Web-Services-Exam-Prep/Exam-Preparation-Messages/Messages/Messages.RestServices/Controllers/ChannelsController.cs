using System.Linq;
using System.Net;
using System.Web.Http;
using Messages.Data.Models;
using Messages.RestServices.Models.BindingModels;

namespace Messages.RestServices.Controllers
{
    public class ChannelsController : BaseApiController
    {
        //GET /api/channels
        [HttpGet]
        [Route("api/channels")]
        public IHttpActionResult GetAllChannels()
        {
            var channels = Data.Channels.OrderBy(c => c.Name);

            return Ok(channels);
        }

        //GET /api/channels/{id}
        [HttpGet]
        [Route("api/channels/{id}")]
        public IHttpActionResult GetChannelById(int id)
        {
            if (!Data.Channels.Any(c => c.Id == id))
                return NotFound();

            var channel = Data.Channels.First(c => c.Id == id);

            return Ok(channel);
        }

        //POST /api/channels
        [HttpPost]
        [Route("api/channels")]
        public IHttpActionResult CreateChannel([FromBody] ChannelsBindingModel m)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrEmpty(m.Name))
                return BadRequest();

            if (Data.Channels.Any(c => c.Name == m.Name))
                return Conflict();

            var channel = new Channel
            {
                Name = m.Name
            };

            Data.Channels.Add(channel);

            Data.SaveChanges();

            return Created(HttpResponseHeader.Location.ToString(), channel);
        }

        //PUT /api/channels/{id}
        [HttpPut]
        [Route("api/channels/{id}")]
        public IHttpActionResult EditChannel(int id, [FromBody] ChannelsBindingModel m)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrEmpty(m.Name))
                return BadRequest();

            if (!Data.Channels.Any(c => c.Id == id))
                return NotFound();

            var channel = Data.Channels.First(c => c.Id == id);

            channel.Name = m.Name;

            Data.SaveChanges();

            return Ok("Channel #" + channel.Id + " edited successfully.");
        }

        //DELETE /api/channels/{id}
        [HttpDelete]
        [Route("api/channels/{id}")]
        public IHttpActionResult DeleteChannel(int id)
        {
            if (!Data.Channels.Any(c => c.Id == id))
                return NotFound();

            if (Data.ChannelMessages.Any(cm => cm.ChannelId == id))
                return Conflict();

            var channel = Data.Channels.First(c => c.Id == id);

            Data.Channels.Remove(channel);

            Data.SaveChanges();

            return Ok("Channel #" + channel.Id + " deleted.");
        }
    }
}