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
        public List<ClassLibrary.Order> Get(ClassLibrary.SerchRequest search)
        {
            string SelectDeliveryAndCoustumer = @"SELECT WebOrder.Id as OrderId, DeliveryDate, CommentOnDelivery,
                                                 FirstName,LastName,Adress, [Zip-Code], City, Email, Company
                                                
                                                 from WebOrder 
                                                 join Person on WebOrder.CustumerID = Person.id
                                                 join JoinProductOrder on WebOrder.Id = JoinProductOrder.WebOderId
                                                 group by WebOrder.Id, WebOrder.DeliveryDate,WebOrder.CommentOnDelivery, Person.FirstName,
                                                 Person.LastName, Person.Adress, Person.[Zip-Code],Person.City, Person.Email, Person.Company
                                                 ";
            string having = "HAVING ";
            if (search.email != null) { having += "Email = " + search.email + " AND "; }
            if (search.fName != null) { having += "FirstName = " + search.fName + " AND ";}
            if (search.lName != null) { having += "LastName = " + search.lName; }

             var hej = db.GetMatchingOrders(SelectDeliveryAndCoustumer);
            return hej;

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
