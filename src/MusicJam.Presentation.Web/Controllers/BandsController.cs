using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicJam.Core.Domain.Model;
using MusicJam.Core.Domain.Repositories;

namespace MusicJam.Presentation.Web.Controllers
{
    public class BandsController : ApiController
    {
        private IBandRepository _repo;

        public BandsController(IBandRepository repo)
        {
            _repo = repo;
        }

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
            var band = new Band()
            {
                Name = "Super Gnar",
                Photo = "/path/to/photo.jpg",
                Bio = "Yay!!!"
            };
            var band2 = new Band()
            {
                Name = "Ultra Gnar",
                Photo = "/path/to/ultragnar.jpg",
                Bio = "This gnar is gnar!!!"
            };
            _repo.Add(band);
            _repo.Add(band2);
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
