using System.Collections.Generic;

namespace TicketSystem.RestApiClient
{
    public interface ITicketApi
    {
        /// <summary>
        /// Get all tickets in the system 
        /// </summary>
        /// <returns></returns>
        List<ClassLibrary.SuperClass> Get();

        /// <summary>
        /// Get a ticket by ID from the system Returns a single ticket
        /// </summary>
        /// <param name="ticketId">ID of the ticket</param>
        /// <returns></returns>
        ClassLibrary.SuperClass TicketTicketIdGet(int ticketId);
    }
}
