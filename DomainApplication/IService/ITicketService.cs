using DomainApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.IService
{
    public interface ITicketService
    {
        Task<Ticket> GetTicket(Guid ticketId);
        Task<Ticket> ConfirmReservation(Guid reservationId);
    }
}
