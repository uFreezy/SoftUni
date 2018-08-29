using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CalcDistanceREST.Controllers
{
    public class PointsController : ApiController
    {
        // GET api/points
        public float Get(int startX, int startY, int endX, int endY)
        {
            return (float)Math.Sqrt(Math.Pow(startX - endX, 2) + Math.Pow(startY - endY, 2));
        }

        // GET api/points/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/points
        public void Post([FromBody]string value)
        {
        }

        // PUT api/points/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/points/5
        public void Delete(int id)
        {
        }
    }
}
