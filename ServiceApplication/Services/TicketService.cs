using AutoMapper;
using DataApplication.Database.Repositories.Abstractions;
using DataRestApplication.Repositories.Abstraction;
using DomainApplication.IService;
using DomainApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApplication.Services
{
    public class TicketService : ITicketService
    {
        private static IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Ticket> ConfirmReservation(Guid reservationId)
        {
            try
            {
                var reservation = await _unitOfWork.ReservationRepository.GetFirstWhere(a => a.Id == reservationId, include: i => i.Include(a => a.Showtime).ThenInclude(a => a.Movie).Include(a => a.Seats));
                if (reservation == null)
                {
                    throw new Exception("Reservation don't exists");
                }
                if (reservation.Status == DomainApplication.Enum.ReservationStatus.Canceled || (reservation.Status == DomainApplication.Enum.ReservationStatus.Pending && reservation.AvailableUntil < DateTime.Now))
                {
                    throw new Exception("Reservation canceled, please make other one");
                }
                if (reservation.Status == DomainApplication.Enum.ReservationStatus.Completed)
                {
                    throw new Exception("Reservation already completed, generate the ticket");
                }
                reservation.UpdateDate = DateTime.Now;
                reservation.Status = DomainApplication.Enum.ReservationStatus.Completed;
                _unitOfWork.ReservationRepository.Update(reservation);
                Ticket ticket = new Ticket
                {
                    Id = Guid.NewGuid(),
                    Paid = true,
                    ReservationId = reservationId,
                    Reservation = reservation,
                };
                await _unitOfWork.TicketsRepository.Add(ticket);
                await _unitOfWork.CommitAsync();
                return ticket;
            }catch(Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Ticket> GetTicket(Guid ticketId)
        {
            try { 
            return await _unitOfWork.TicketsRepository.GetFirstWhere(a => a.Id == ticketId, include: i => 
            i.Include(a => a.Reservation).ThenInclude(b => b.Showtime).ThenInclude(b => b.Movie)
            .Include(b => b.Reservation).ThenInclude(c => c.Seats));
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
