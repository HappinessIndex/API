using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace PharrellAPI.Controllers
{
    public class HappinessController : ApiController
    {
        private HiDbContext _db = new HiDbContext();

        // GET: api/Happiness
        public async Task<IHttpActionResult> Get()
        {
            List<ApiFeature> features = new List<ApiFeature>();
            foreach (var region in _db.Regions)
            {
                var index = 0;
                if (region.Tweets.Any())
                {
                    index = (int) Math.Floor(region.Tweets.Average(t => t.HappinessIndex));
                }
                features.Add(new ApiFeature
                {
                    type = "Feature",
                    id = region.Id,
                    properties = new ApiProperties
                    {
                        AU12 = region.AU12,
                        happinessIndex = index,
                    },
                    geometry = new ApiGeometry
                    {
                        type = "Polygon",
                        coordinates = region.Polygon,
                    }
                });
            }

            return Ok(new ApiFeatureCollection {type = "FeatureCollection", features = features});
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
