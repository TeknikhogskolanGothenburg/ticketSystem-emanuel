using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class HelpMethod
    {
  
        public Product Json2Charp(string json)
        {
            //"id": 5,"catagoryId": 1, "name": "Nike1","description": "nike1", "price": 499, "imgName": "Nike1.jpg", "imgFilePath": "../../images/cat1/Nike1.jpg"

            return null;
        }
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
        public string fname;
        public string lna

    }
    public class Newclass
    {

    }
        
}
