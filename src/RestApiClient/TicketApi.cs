using RestSharp;
using System;
using System.Collections.Generic;

namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        // Implemented using RestSharp: http://restsharp.org/

        public List<ClassLibrary.Product> Get()
        {
            var client = new RestClient("localhost:53936/");
            var request = new RestRequest("api/values", Method.GET);
           
            var response = client.Execute<List<ClassLibrary.Product>>(request);
            return response.Data;
        }

        public ClassLibrary.Product TicketTicketIdGet(int ticketId)
        {
            var client = new RestClient("http://localhost:53936");
            var request = new RestRequest("ticket/{id}", Method.GET);
            request.AddUrlSegment("id", ticketId);
            var response = client.Execute<ClassLibrary.Product>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", ticketId));
            }

            return response.Data;
        }
    }
}
