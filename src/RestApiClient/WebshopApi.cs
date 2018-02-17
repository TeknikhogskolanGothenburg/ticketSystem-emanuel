using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace TicketSystem.RestApiClient
{
   
    public class WebshopApi : IWebshopApi
    {
        // Implemented using RestSharp: http://restsharp.org/
        string localHost = "http://localhost:55441/";

        // does nothing atm
        public List<ClassLibrary.Product> GetProduct()
        {
            var client = new RestClient(localHost);
            var request = new RestRequest("api/values", Method.GET);          
            var response = client.Execute<List<ClassLibrary.Product>>(request);
            List<ClassLibrary.Product> test = response.Data;
            return test;
        }
         

        // gets all the products from the requested catagory
        public List<ClassLibrary.Product> GetProductsByCatId(string CategoryId)
        {
            var client = new RestClient(localHost);
            var request = new RestRequest("api/values/{id}", Method.GET);
            request.AddUrlSegment("id", CategoryId);
            var response = client.Execute<List<ClassLibrary.Product>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", CategoryId));
            }
            return response.Data;
        }

        public List<ClassLibrary.Order> GetMatchingOrders(ClassLibrary.SerchRequest serchRequest)
        {
            var client = new RestClient(localHost);
            var request = new RestRequest("api/Backoffice/{search}", Method.GET);
            request.AddUrlSegment("search", serchRequest.fName+","+serchRequest.lName+","+serchRequest.email);
            var response = client.Execute<List<ClassLibrary.Order>>(request);
            return response.Data;
        }

        //takes a order obj and put it in the database
        public void CustumerOrder(ClassLibrary.Order order)
        {

            var client = new RestClient(localHost);
            var request = new RestRequest("api/values/{id}", Method.POST);
            request.AddJsonBody(order);
            client.Execute(request);

            //Vad gör den här raden? - inget
        }

        
    }
}
