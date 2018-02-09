using System;
using TicketSystem.DatabaseRepository;

namespace DbStartUp
{
    class Program
    {

        static void Main(string[] args)
        {
            TicketDatabase db = new TicketDatabase();


            db.GetAllProd();
            Console.ReadKey();
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter values of chose");
            bool statement = true; 
            while (statement)
            {
                Console.Write("Please insert Value Id: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Please insert Value CatagoryId: ");
                int catId = int.Parse(Console.ReadLine());

                Console.Write("Please insert Value Description: ");
                string des = Console.ReadLine();


                Console.Write("Please insert Value Price: ");
                int price = int.Parse(Console.ReadLine());


                Console.Write("Please insert Value ImgFilename: ");
                string imgFilename = Console.ReadLine();



                db.AddProdToBd(new ClassLibrary.Product {Id=id, CategoryId=catId, Description=des, Price=price, ImgFileName=imgFilename});
                

            }


            Console.ReadKey();
        }
    }
}
