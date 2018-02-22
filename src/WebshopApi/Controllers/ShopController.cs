using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;

namespace WebshopApi.Controllers
{
    [Route("api/[controller]")]
    public class ShopController : Controller
    {
        TicketDatabase db = new TicketDatabase();
        //GET api/value

       // GET api/values/5
       [HttpGet("{id}")]
       public List<ClassLibrary.Product> Get()
       {
            return db.GetAllProd();
       }

        //POST api/values
        [HttpPost("{id}")]
        public void Post([FromBody]ClassLibrary.Order order)
        {

            db.AddOrder(order);
        }

    }
}
