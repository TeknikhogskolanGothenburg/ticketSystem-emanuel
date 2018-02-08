using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class ProductsController : Controller
    {
        ProdList prodList = new ProdList();
        public IActionResult Category(int? Amount, int Id)
        {

            for (int i = 0; i < 50; i++)
            {
                prodList.product.Add(new Product
                {
                    Id = i,
                    CatagoryId = 1,
                    Name = "Name",
                    Description = "Des",
                    Price = 499,
                    PicturePath = "../../images/cat1/Nike2.jpg"

                });
            }
            if (prodList.product.Count() == 0)
            {
                return View();
            }
            return View(prodList);

        }
        public IActionResult AddProduct(int ProdId, int? Amount, string url)
        {

            return Redirect(url);
        }

    }
}