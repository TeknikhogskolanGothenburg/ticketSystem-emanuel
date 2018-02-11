using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class SuperClass
    {
        public List<Product> productList = new List<Product>();
    }
    public class Product
    {
       public int Id;
       public int CategoryId;
       public string Name;
       public string Description;
       public int Price;
       public string ImgFileName;

       public string ImgFilePath
        {
            get
            {
                return "../../images/cat"+CategoryId+"/"+ImgFileName;
            }
        }
    }
    public class Order
    {

    }
    public class Newclass
    {

    }
        
}
