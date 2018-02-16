using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;

namespace WebshopApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        TicketDatabase db = new TicketDatabase();
       //GET api/values
       [HttpGet]
       public string[] Get()
       {
            return null;
       }

       // GET api/values/5
       [HttpGet("{id}")]
       public List<ClassLibrary.Product> Get(string id)
       {
            return db.GetAllProd(id);
       }

        //POST api/values
        [HttpPost("{id}")]
        public void Post([FromBody]ClassLibrary.Order order)
        {

            db.AddOrder(order);
        }

        [HttpPost()]
        public void Posta([FromBody]string value)
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
