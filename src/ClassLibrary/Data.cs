﻿using System;
using System.Collections.Generic;

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
                return "../../images/cat" + CatagoryId + "/" + ImgName;

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

}
        

