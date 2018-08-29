using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Messages.Data;

namespace Messages.RestServices.Controllers
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
            : this(new MessagesDbContext())
        {
        }

        public BaseApiController(MessagesDbContext data)
        {
            this.Data = data;
        }

        protected MessagesDbContext Data { get; }
    }
}
