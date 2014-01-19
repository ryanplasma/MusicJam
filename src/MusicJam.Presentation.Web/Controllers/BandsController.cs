using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicJam.Presentation.Web.Controllers
{
    public class BandsController : ApiController
    {
        

        // GET api/bands
        [Route("api/bands")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/bands/5
        [Route("api/bands/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/bands
        [Route("api/bands")]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/bands/5
        [Route("api/bands/{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/bands/5
        [Route("api/bands/{id}")]
        public void Delete(int id)
        {
        }
    }
}
