﻿using System;
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
            string orderToJson = JsonConvert.SerializeObject(order).ToString();
            string personToJson = JsonConvert.SerializeObject(person).ToString();
            string cart = JsonConvert.SerializeObject(Cart.cartList).ToString();

            ClassLibrary.Order OderToJason  = JsonConvert.DeserializeObject<ClassLibrary.Order>(orderToJson);
            ClassLibrary.Person PersonToJason = JsonConvert.DeserializeObject<ClassLibrary.Person>(personToJson);
            ClassLibrary.Cart cartObj = JsonConvert.DeserializeObject<ClassLibrary.Cart>(cart);

            Console.WriteLine(orderToJson);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(personToJson);

            return View();
        }

    }
}


