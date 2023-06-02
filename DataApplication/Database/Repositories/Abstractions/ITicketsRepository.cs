using DataApplication.Database.Entities;
using DomainApplication.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataApplication.Database.Repositories.Abstractions
{
    public interface ITicketsRepository : IRepositoryBase<Ticket>
    {
        Task<TicketEntity> ConfirmPaymentAsync(TicketEntity ticket, CancellationToken cancel);

    }
}