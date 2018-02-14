using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;
using TicketSystem.RestApiClient;
using Newtonsoft.Json;

namespace Webshop.Controllers
{
    public class ProductsController : Controller
    {
        WebshopApi db = new WebshopApi();
       
        public IActionResult Category(int? Amount, string Id)
        {

            return View(db.GetProductsByCatId(Id));

        }
        public IActionResult AddProduct(ClassLibrary.Product prod, int? Amount, string url)
        {
            if (Amount != null && Amount > 0)
            {
                Cart.AddItem(prod, (int)Amount);
            }
            return Redirect(url);
        }
        public IActionResult Order_Pay()
        {
            return View();
        }

        public IActionResult Thanks(ClassLibrary.Order order, ClassLibrary.Person person)
        {
            string OrderToJson = JsonConvert.SerializeObject(order).ToString();
            ClassLibrary.Order JsonToOrder  = JsonConvert.DeserializeObject<ClassLibrary.Order>(OrderToJson);

            string jsonString2 = JsonConvert.ToString(person);
            Console.WriteLine();
            return View();
        }

    }
}


