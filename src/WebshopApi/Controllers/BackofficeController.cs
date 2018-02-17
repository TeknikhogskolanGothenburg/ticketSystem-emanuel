using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.DatabaseRepository;

namespace WebshopApi.Controllers
{
    
    [Route("api/[controller]")]
    public class BackofficeController : Controller
    {
        TicketDatabase db = new TicketDatabase();
        // GET: api/Backoffice
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Backoffice/5
        [HttpGet("{search}")]
        public List<ClassLibrary.Order> Get(string search)
        {
            string SelectDeliveryAndCoustumer = @"SELECT WebOrder.Id as OrderId, DeliveryDate, CommentOnDelivery,
                                                 FirstName,LastName,Adress, [Zip-Code], City, Email
                                                
                                                 from WebOrder 
                                                 join Person on WebOrder.CustumerID = Person.id
                                                 join JoinProductOrder on WebOrder.Id = JoinProductOrder.WebOderId
                                                 group by WebOrder.Id, WebOrder.DeliveryDate,WebOrder.CommentOnDelivery, Person.FirstName,
                                                 Person.LastName, Person.Adress, Person.[Zip-Code],Person.City, Person.Email";
            string[] a = search.Split(',');
            string having = " HAVING ";


            if (a[0] != "" && a[1] == "" && a[2] == "") { having += "FirstName = '" + a[0]+"' "; }
            else if(a[0] !="") { having += "FirstName = ' " + a[0] + " ' AND "; }

            if (a[1] != "" && a[2] == "") { having += "LastName = '" + a[1]+"'"; }
            else if(a[1] !=""){ having += "LastName = '" + a[1] + "' AND "; }

            if (a[2] != "") { having += "Email = '" + a[2]+"'"; }

            var hej = db.GetMatchingOrders(SelectDeliveryAndCoustumer + having);
            return hej;
        }
        
        // POST: api/Backoffice
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Backoffice/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
