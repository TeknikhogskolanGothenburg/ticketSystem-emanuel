using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public static class Cart
    {
        public static int Total;
        public static List<ClassLibrary.CartItem> cartList = new List<ClassLibrary.CartItem>();


        public static void AddItem(ClassLibrary.Product product, int Amount)
        {
            bool add = true;
            if (cartList.Count == 0)
            {
                cartList.Add(new ClassLibrary.CartItem { Product = product, Amount = (int)Amount });
            }
            foreach (var item in cartList)
            {
                if (product.Id == item.Product.Id)
                {
                    item.Amount += Amount;
                    add = false;
                    break;
                }
            }
            if (add)
            {
                cartList.Add(new ClassLibrary.CartItem { Product = product, Amount = (int)Amount });

            }
        }
    }
}
