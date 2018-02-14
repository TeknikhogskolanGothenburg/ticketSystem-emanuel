using System;
using System.Collections.Generic;


namespace Webshop.Models
{
    public class CartItem
    {
        public int Amount { get; set; }
        public ClassLibrary.Product Product { get; set; }
    }

    public static class Cart
    {
        public static int Total;
        static public List<CartItem> cart = new List<CartItem>();


        public static void AddItem(ClassLibrary.Product product, int Amount)
        {
            bool add = true;
            if (cart.Count == 0)
            {
                    cart.Add(new CartItem { Product = product, Amount = (int)Amount });
            }
            foreach (var item in cart)
            {
                if (product.Id==item.Product.Id)
                {
                    item.Amount += Amount;
                    add = false;
                    break;
                }                
            }
            if (add)
            {
                cart.Add(new CartItem { Product = product, Amount = (int)Amount });

            }
        }
    }

}
