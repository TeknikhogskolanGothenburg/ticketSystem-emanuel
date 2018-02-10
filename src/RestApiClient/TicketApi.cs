using RestSharp;
using System;
using System.Collections.Generic;

namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        // Implemented using RestSharp: http://restsharp.org/

        public List<ClassLibrary.SuperClass> TicketPost()
        {
            var client = new RestClient("http://localhost:60949/");
            var request = new RestRequest("ticket", Method.POST);

            // result : GET http://localhst:60949/
            var response = client.Execute<List<ClassLibrary.SuperClass>>(request);
            return response.Data;
        }

        public ClassLibrary.SuperClass TicketTicketIdGet(int ticketId)
        {
            var client = new RestClient("http://localhost:60949/");
            var request = new RestRequest("ticket/{id}", Method.GET);
            request.AddUrlSegment("id", ticketId);
            var response = client.Execute<ClassLibrary.SuperClass>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", ticketId));
            }

            return response.Data;
        }
    }
}
