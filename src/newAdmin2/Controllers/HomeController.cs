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

        public IActionResult EngSv()
        {
            if (EngSve.IsEng==true) { EngSve.IsEng = false; return View("AddProdSv"); }
            else { EngSve.IsEng = true;  return View("AddProdEN"); }
            
        }


        // använd rest API
        public IActionResult AddProd(string ProdName, string Description, int Price, string imgName, bool IsAddProd)
        {


            if (Description == null || Price == 1 || imgName == null && IsAddProd == true)
            {
                if (EngSve.IsEng == false) { return View("AddProdSv"); }
                else { return View("AddProdEN"); }
            }

            if (Validator.ValidateName(ProdName) && Validator.ValidateDes(Description) && Validator.ValidatePrice(Price) && Validator.validateImgName(imgName))
            {
                db.AddProduct(new ClassLibrary.Product { Name = ProdName, Description = Description, Price = Price, ImgName = imgName });
            }

            if (EngSve.IsEng == false) { return View("AddProdSv"); }
            else { return View("AddProdEN"); }
        }





        public IActionResult FindPurchase(string fname, string lname, string mail, bool isSearchCall)
        {

            if (fname == null && lname == null && mail == null && isSearchCall == false)
            {
                if (EngSve.IsEng == false) { return View("FindPurchaseSv"); }
                else { return View("FindPurchaseEN"); }
            }

            if (fname == null || Validator.ValidateName(fname) && lname==null || Validator.ValidateName(lname) && mail==null || Validator.ValidateEmail(mail))
            {
                List<ClassLibrary.Order> matchedOrders = db.GetMatchingOrders
                (new ClassLibrary.SerchRequest { fName = fname, lName = lname, email = mail });
                if (EngSve.IsEng == false) { return View("FindPurchaseSv", matchedOrders); }
                else { return View("FindPurchaseEN", matchedOrders); }
            }

            else
            {
                if (EngSve.IsEng == false) { return View("FindPurchaseSv"); }
                else { return View("FindPurchaseEN"); }
            }
            //should return the orders that matches the search result
        }

    }
}
