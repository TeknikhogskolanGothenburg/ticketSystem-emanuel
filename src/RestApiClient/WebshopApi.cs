﻿using RestSharp;
using System;
using System.Collections.Generic;

namespace TicketSystem.RestApiClient
{
   
    public class WebshopApi : IWebshopApi
    {
        // Implemented using RestSharp: http://restsharp.org/

        public List<ClassLibrary.Product> GetProduct()
        {
            var client = new RestClient("http://localhost:55441/");
            var request = new RestRequest("api/values", Method.GET);          
            var response = client.Execute<List<ClassLibrary.Product>>(request);
            List<ClassLibrary.Product> test = response.Data;
            return test;
        }
         
        public List<ClassLibrary.Product> GetProductsByCatId(string ticketId)
        {
            var client = new RestClient("http://localhost:55441//");
            var request = new RestRequest("api/values/{id}", Method.GET);
            request.AddUrlSegment("id", ticketId);
            IRestResponse<List<ClassLibrary.Product>> response = client.Execute<List<ClassLibrary.Product>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", ticketId));
            }
            return response.Data;
        }

        public void CustumerOrder(string Order)
        {
            var client = new RestClient("http://localhost:55441/");
            var request = new RestRequest("api/values/{id}", Method.POST);
            request.AddUrlSegment("id", Order);
            IRestRequest irequest = (IRestRequest)client.Execute(request);

        }
    }
}
