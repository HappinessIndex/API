using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PharrellAPI.Controllers
{
    public class HappinessController : ApiController
    {
        HiDbContext db = new HiDbContext();
        // GET: api/Happiness
        public IHttpActionResult Get()
        {
            return Ok(db.Tweets);
        }

        //// GET: api/Happiness/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Happiness
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Happiness/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Happiness/5
        //public void Delete(int id)
        //{
        //}
    }
}
