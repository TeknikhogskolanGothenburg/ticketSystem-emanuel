using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace TicketSystem.RestApiClient
{
   
    public class WebshopApi : IWebshopApi
    {
        // Implemented using RestSharp: http://restsharp.org/
        string localHost = "http://localhost:62034/";

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
        public List<ClassLibrary.Product> GetProductsByCatId()
        {
            var client = new RestClient(localHost);
            var request = new RestRequest("api/values/{id}", Method.GET);
            var response = client.Execute<List<ClassLibrary.Product>>(request);     
            return response.Data;
        }

        public List<ClassLibrary.Order> GetMatchingOrders(ClassLibrary.SerchRequest serchRequest)
        {
            var client = new RestClient(localHost);
            var request = new RestRequest("api/Backoffice/{search}", Method.GET);
            request.AddUrlSegment("search", serchRequest.fName+","+serchRequest.lName+","+serchRequest.email);
            var response = client.Execute<List<ClassLibrary.Order>>(request);
            List<ClassLibrary.Order> list = JsonConvert.DeserializeObject<List<ClassLibrary.Order>>(response.Content);

            return list;
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
        public void AddProduct(ClassLibrary.Product product)
        {
            var client = new RestClient(localHost);
            var request = new RestRequest("api/Backoffice", Method.POST);
            request.AddJsonBody(product);
            client.Execute(request);

        }
        
    }
}
