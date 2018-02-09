using TicketSystem.DatabaseRepository;
using System;

namespace TicketSystem.DatabaseRepositoryTestclient
{
    class Program
    {
        static void Main(string[] args)
        {
            //ITicketDatabase ticketDatabase = new TicketDatabase();
            //var tevent = ticketDatabase.EventAdd("Event1", "Some desciption");
            //Console.WriteLine("TicketEventId: " + tevent.TicketEventId);
            //var venue = ticketDatabase.VenueAdd("venue1", "Some address", "city1","country1");
            //Console.WriteLine("VenueId: " + venue.VenueId);

            //var venues1 = ticketDatabase.VenuesFind("ven");
            //foreach (var ven in venues1)
            //{
            //    Console.WriteLine("Find(ven) - VenueId: " + ven.VenueId);
            //}

            //var venues2 = ticketDatabase.VenuesFind("y1");
            //foreach (var ven in venues2)
            //{
            //    Console.WriteLine("Find(y1) - VenueId: " + ven.VenueId);
            //}
            //Console.WriteLine("Done!");

            WebshopDatabase db = new WebshopDatabase();
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



                db.AddProdToBd(new ClassLibrary.Product { Id = id, CategoryId = catId, Description = des, Price = price, ImgFileName = imgFilename });


            }
            Console.ReadKey();
        }
    }
}
