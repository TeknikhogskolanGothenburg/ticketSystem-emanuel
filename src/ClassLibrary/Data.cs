using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
    public class Product
    {
            public int Id { get; set; }
            public int CatagoryId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public string ImgName { get; set; }

        public string ImgFilePath
        {
            get
            {
                return "../../images/" + ImgName;

            }

        }
    }

    public class Order
    {
        public int id;
        public Delivery delivery;
        public List<CartItem> cart;
        public Person person;

    }
    public class Delivery
    {

        public DateTime DeliveryDate { get; set; }
        public string CommentOnDelivery { get; set; }

    }

    public class Cart
    {
        public List<CartItem> cartList = new List<CartItem>();

    }

    public class CartItem
    {
        public int Amount { get; set; }
        public Product Product { get; set; }
    }

    public class CardInfo
    {
        public string cardNumber;
        public DateTime date;
        public string CVC;
    }

    public class SerchRequest
    {
        public string fName;
        public string lName;
        public string email;
    }


    public class Validator
    {
        public bool ValidateName(string name)
        {
            int i = 0;
            i += Regex.Matches(name, @"[a-zA-Z0-9 ]").Count;

            return i == name.Length && name != null && name != "";
        }

        public bool ValidateDes(string des)
        {
            int i = 0;
            i += Regex.Matches(des, @"[a-zA-Z0-9 ]").Count;

            return i == des.Length && des != null && des != "";
        }

        public bool ValidatePrice(int price)
        {
            return Regex.IsMatch(price.ToString(), @"[0-9]");

        }

        public bool ValidateEmail(string email)
        {
            Regex rx = new Regex(
             @"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");
            return rx.IsMatch(email);
        }

        public bool ValidateAdress(string adress)
        {
            int i = 0;
            i += Regex.Matches(adress, @"[a-zA-Z0-9 ]").Count;

            return i == adress.Length && adress != null && adress != "";
        }

        public bool ValidateZip(string zip)
        {
            if (zip.Length != 5) { return false; }
            return Regex.IsMatch(zip.ToString(), @"[0-9]");
        }

        public bool ValidateCity(string City)
        {
            int i = 0;
            i += Regex.Matches(City, @"[a-öA-Ö ]").Count;

            return i == City.Length && City != null && City != "";
        }
        public bool ValidateCrdnumber(string cardnumber)
        {
            if (cardnumber.Length != 16 && true) { return false; }
            try { Int64 d = Int64.Parse(cardnumber); return true; }
            catch
            {
                return false;
            }
        }
        public bool ValidateDate(string date)
        {
            try { DateTime d = DateTime.Parse(date); return true; }
            catch
            {
                return false;
            }

        }

        public bool VallidteCvc(string cvc)
        {
            if (cvc.Length != 3) { return false; }
            try { int d = int.Parse(cvc); return true; }
            catch
            {
                return false;
            }
        }
        public bool validateImgName(string img)
        {
            int i = 0;
            i += Regex.Matches(img, @"[a-zA-Z0-9\.]").Count;

            return i == img.Length && img != null && img != "";
        }

    }

}
        

