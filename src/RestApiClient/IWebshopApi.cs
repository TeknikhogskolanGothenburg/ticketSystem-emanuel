using System.Collections.Generic;

namespace TicketSystem.RestApiClient
{
    public interface IWebshopApi
    {
        /// <summary>
        /// Get all tickets in the system 
        /// </summary>
        /// <returns></returns>
        List<ClassLibrary.Product> GetProduct();

        /// <summary>
        /// Get a ticket by ID from the system Returns a single ticket
        /// </summary>
        /// <param name="ticketId">ID of the ticket</param>
        /// <returns></returns>
        List<ClassLibrary.Product> GetProductsByCatId(string ticketId);
    }
}
