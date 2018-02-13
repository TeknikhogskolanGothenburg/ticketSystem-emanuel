using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;
using TicketSystem.RestApiClient;

namespace Webshop.Controllers
{
    public class ProductsController : Controller
    {
        TicketApi db = new TicketApi();
        public IActionResult Category(int? Amount, string Id)
        {
            List<ClassLibrary.Product> prodList = new List<ClassLibrary.Product>(); 
            prodList = db.GetProductsByCatId(Id);
            return View(prodList);

        }
        public IActionResult AddProduct(int ProdId, int? Amount, string url)
        {

            return Redirect(url);
        }

    }
}

