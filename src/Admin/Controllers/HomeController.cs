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

        // använd rest API
        public IActionResult AddProd(string ProdName, string CatagoryId, string Description, int Price, string imgName, bool IsAddProd)
        {
            TicketApi api = new TicketApi();

            api.Get();
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

            oder.Add(new Oder {ObjectVarfname="Emanuel",ObjectVarlname="Johansson", ObjectVarmail="Emanuel_joh@hotmail.com", OderNumber=100 });
            oder.Add(new Oder {ObjectVarfname="Göran",ObjectVarlname="Valflesk",ObjectVarmail="valflask@alltid.nu", OderNumber=101 });
            oder.Add(new Oder {ObjectVarfname="Carina", ObjectVarlname= "Johansson",ObjectVarmail="RandomMail", OderNumber=102 });
            oder.Add(new Oder {ObjectVarfname= "SORAN",ObjectVarlname="ISMAIL",ObjectVarmail="soran@soran.se", OderNumber=103 });

            result.oderList = AddToList(oder, new SearchResult { ObjectVarfname = fname, ObjectVarlname = lname, ObjectVarmail = mail }); // Se  korligt ut men det är det ej! 
                                                                                                                                          //Oderlist klassen innhåller bara en lista på odrar som propety.Jag skapar en ny lista med odrar som jag kallar för result. Denna lista kommer att innhålla alla de sökresultat som fick en matching. ( Genom metoden "AddTolist" )

            return View(result); //should return the orders that matches the search result
        }


         
       public List<Oder> AddToList(List<Oder> oderList, SearchResult searchResult )
        {
            List<Oder> returnList = new List<Oder>();
            foreach (Oder oder in oderList)
            {
                if (
                    oder.ObjectVarfname==searchResult.ObjectVarfname ||
                    oder.ObjectVarlname==searchResult.ObjectVarlname ||
                    oder.ObjectVarmail==searchResult.ObjectVarmail                    
                    ){ returnList.Add(oder); }
            }
            return returnList;
        }

    }
}
