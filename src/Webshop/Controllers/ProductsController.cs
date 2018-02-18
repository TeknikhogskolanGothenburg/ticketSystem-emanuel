using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using TicketSystem.RestApiClient;
using Newtonsoft.Json;

namespace Webshop.Controllers
{
    public class ProductsController : Controller
    {
        WebshopApi db = new WebshopApi();
        ClassLibrary.Validator val = new ClassLibrary.Validator();
        public IActionResult Category()
        {

            return View(db.GetProductsByCatId());

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

        public IActionResult Thanks(ClassLibrary.Delivery delivery, ClassLibrary.Person person, ClassLibrary.CardInfo card)
        {


            if (val.ValidateName(person.FirstName) && val.ValidateName(person.LastName) && val.ValidateAdress(person.Adress) &&
                val.ValidateZip(person.ZipCode) && val.ValidateCity(person.City) && val.ValidateEmail(person.Email) &&
                val.ValidateDes(delivery.CommentOnDelivery)
                )
            {
                db.CustumerOrder(new ClassLibrary.Order { delivery = delivery, person = person, cart = Cart.cartList });
                Cart.cartList.Clear();
                Cart.Total = 0;
                return View();
            }
            else
            {
                return View();
            }
        }

    }
}


