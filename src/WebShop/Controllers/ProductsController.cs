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
            List<ClassLibrary.Product> prodList = new List<ClassLibrary.Product>(); 
            prodList = db.GetProductsByCatId(Id);
            return View(prodList);

        }
        public IActionResult AddProduct(int ProdId, int? Amount, string url)
        {
            if (Amount != null)
            {
                ClassLibrary.Cart.cart.Add(new ClassLibrary.CartItem { PrductId = ProdId, Amount = (int)Amount });
            }
            return null;
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


