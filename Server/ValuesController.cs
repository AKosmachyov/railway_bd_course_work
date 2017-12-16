using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        prod_dbContext db = new prod_dbContext();
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {            
            return Json(db.User);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //MySqlConnection connection = new MySqlConnection
            //{
            //    ConnectionString = "server=localhost;user id=root;password=123456;persistsecurityinfo=True;port=3306;database=prod_db;CharSet=utf8"
            //};

            //MySqlCommand command = new MySqlCommand("SELECT * FROM city;", connection);

            //connection.Open();
            //using (MySqlDataReader reader = command.ExecuteReader())
            //{

            //    var results = new List<Dictionary<string, object>>();
            //    var cols = new List<string>();
            //    for (var i = 0; i < reader.FieldCount; i++)
            //        cols.Add(reader.GetName(i));

            //    while (reader.Read())
            //        results.Add(SerializeRow(cols, reader));

            //    string json = JsonConvert.SerializeObject(results, Formatting.Indented);
            //    ViewData["Message"] = json;
            //}
            
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
