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

        public IActionResult EnSv()
        {
            if (EngSv.IsEng == false) { EngSv.IsEng = true; return View("CategoryEn", db.GetProducts()); }
            else {EngSv.IsEng = false; return View("CategorySv", db.GetProducts()); }
        }

        public IActionResult Category()
        {
            if (EngSv.IsEng == true) {return View("CategoryEn", db.GetProducts()); }
            else {return View("CategorySv", db.GetProducts()); }

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
            if (EngSv.IsEng == true) { return View("Order_PayEn"); }
            else { return View("Order_PaySv"); }
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
        public IActionResult AboutProd()
        {
            return View();
        }

    }
}


