using DataApplication.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using DataApplication.Database.Repositories.Abstractions;
using DataApplication.Database;
using DomainApplication.Models;

namespace DataApplication.Database.Repositories
{
    public class TicketsRepository : RepositoryBase<Ticket, TicketEntity>, ITicketsRepository
    {
        private readonly CinemaContext _context;

        public TicketsRepository(CinemaContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<TicketEntity> ConfirmPaymentAsync(TicketEntity ticket, CancellationToken cancel)
        {
            ticket.Paid = true;
            _context.Update(ticket);
            await _context.SaveChangesAsync(cancel);
            return ticket;
        }
    }
}
