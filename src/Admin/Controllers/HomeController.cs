using System;
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
        public IActionResult AddProd(string ProdName, string CatagoryId, string Description, int Price, string imgName, bool IsAddProd)
        {

            
            if (CatagoryId == null || Description == null || Price == 1|| imgName == null && IsAddProd == true)
            {
                return View(); // return error promt 
            }
            
            return View(); // return promt "Prod added"
        }
                 

        public IActionResult FindPurchase(string fname, string lname, string mail, bool isSearchCall)
        {

            List<Oder> oder = new List<Oder>(); // Skapar en lista men odrar för att testa, detta ska läsas från min datorbas senare. (Alla odrar kommer att vara i denna lista) Eller så skickar jag bara sök-objhektet till APIn som gör qury på mi sql-databas
            // Api retunerar de odrar som fick träff i en lista. 
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
