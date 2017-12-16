using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Server
{
    [Route("api/[controller]")]
    public class StationController : Controller
    {
        prod_dbContext db = new prod_dbContext();
        
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                var a = db.City.Include(x=>x.Region);

                // .Where(x => true);
                JsonResult temp = Json(a);
                return temp;
            }catch(Exception e)
            {
                var t = e.Message;
                return Json("qew");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {            
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}