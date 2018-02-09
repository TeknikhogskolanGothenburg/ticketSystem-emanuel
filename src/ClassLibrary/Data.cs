using System;

namespace ClassLibrary
{
    public class SuperClass
    {

    }
    public class Product
    {
       public int id;
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
