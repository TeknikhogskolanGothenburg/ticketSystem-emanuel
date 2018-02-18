using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newAdmin2.Models;
using TicketSystem.RestApiClient;

namespace newAdmin2.Controllers
{
    public class HomeController : Controller
    {
        WebshopApi db = new WebshopApi();
        ClassLibrary.Validator Validator = new ClassLibrary.Validator();
        // använd rest API
        public IActionResult AddProd(string ProdName, string Description, int Price, string imgName, bool IsAddProd)
        {


            if (Description == null || Price == 1 || imgName == null && IsAddProd == true)
            {
                return View(); // return error promt 
            }

            if (Validator.ValidateName(ProdName) && Validator.ValidateDes(Description) && Validator.ValidatePrice(Price) && Validator.validateImgName(imgName))
            {
                db.AddProduct(new ClassLibrary.Product { Name = ProdName, Description = Description, Price = Price, ImgName = imgName });
            }

            return View(); // return promt "Prod added"
        }


        public IActionResult FindPurchase(string fname, string lname, string mail, bool isSearchCall)
        {




            if (fname == null && lname == null && mail == null && isSearchCall == false)
            {
                return View(); // Return the same view (blank ~/home/FindPurchase or a error promt) if no fields is given values, 
            }

            if (fname == null || Validator.ValidateName(fname) && lname==null || Validator.ValidateName(lname) && mail==null || Validator.ValidateEmail(mail))
            {
                List<ClassLibrary.Order> matchedOrders = db.GetMatchingOrders
                (new ClassLibrary.SerchRequest { fName = fname, lName = lname, email = mail });
                return View(matchedOrders);
            }

            else
            {
                return View();
            }
            //should return the orders that matches the search result
        }

    }
}
