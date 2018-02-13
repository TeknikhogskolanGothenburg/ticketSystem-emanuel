using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

       public IActionResult Order_Pay()
       {           
                return View();
                       
        }

       public IActionResult Thanks(ClassLibrary.Order order)
       {         


           return View();
       }

       //public IActionResult Error()
       //{
       //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
       //}
    }
}
