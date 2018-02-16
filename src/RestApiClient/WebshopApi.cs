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

        public List<ClassLibrary.Product> GetProduct()
        {
            var client = new RestClient(localHost);
            var request = new RestRequest("api/values", Method.GET);          
            var response = client.Execute<List<ClassLibrary.Product>>(request);
            List<ClassLibrary.Product> test = response.Data;
            return test;
        }
         
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

        public void CustumerOrder(ClassLibrary.Order order)
        {

            var client = new RestClient(localHost);
            var request = new RestRequest("api/values/{id}", Method.POST);
            request.AddJsonBody(order);
            client.Execute(request);

            //Vad gör den här raden?
        }
    }
}
