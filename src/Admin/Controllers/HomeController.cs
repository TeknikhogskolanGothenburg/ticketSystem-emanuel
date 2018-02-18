﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Admin.Models;
using TicketSystem.RestApiClient;

namespace Admin.Controllers
{

    public class HomeController : Controller
    {
        WebshopApi db = new WebshopApi();
        // använd rest API
        public IActionResult AddProd(string ProdName, int CatagoryId, string Description, int Price, string imgName, bool IsAddProd)
        {

            
            if (CatagoryId == null || Description == null || Price == 1|| imgName == null && IsAddProd == true)
            {
                return View(); // return error promt 
            }

            db.AddProduct(new ClassLibrary.Product {Name=ProdName, CatagoryId=CatagoryId, Description=Description,Price=Price, ImgName=imgName});
            return View(); // return promt "Prod added"
        }
                 

        public IActionResult FindPurchase(string fname, string lname, string mail, bool isSearchCall)
        {

           
            OderList result = new OderList();

            if (fname == null && lname == null && mail == null && isSearchCall == false)
            {
            return View(result); // Return the same view (blank ~/home/FindPurchase or a error promt) if no fields is given values, 
            }

            List<ClassLibrary.Order> matchedOrders = db.GetMatchingOrders
                (new ClassLibrary.SerchRequest {fName=fname, lName=lname, email =mail});
            return View(result); //should return the orders that matches the search result
        }

    }
}
