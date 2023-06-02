using DataApplication.Database.Repositories.Abstractions;
using DomainApplication.Enum;
using DomainApplication.IService;
using DomainApplication.Models;
using DomainApplication.Requests;
using DomainApplication.Response;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApplication.Services
{
    public class ReservationService : IReservationService
    {
        private static IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReserveSeatPostResponse> CreateReservation(ReserveSeatPostRequest showTimePost)
        {
            var availableSeats = await GetAvailableSeatsBySessionId(showTimePost.ShowTimeId);
            foreach (var seatReservation in showTimePost.Seats)
            {
                if (!availableSeats.Any(a =>a.Id == seatReservation.Id))
                {
                    throw new Exception($"Seat number {seatReservation.SeatNumber} and row {seatReservation.Row} not available");
                }
            }
            if(!AreSeatsContiguous(showTimePost.Seats)) 
            {
                throw new Exception("Seats are not contiguous");
            }
            var showTime = await _unitOfWork.ShowtimesRepository.GetFirstWhere(a => a.Id == showTimePost.ShowTimeId, include: src => src.Include(b => b.Movie));
            var auditorium = await _unitOfWork.AuditoriumsRepository.GetById(showTime.AuditoriumId);
            var seats = await _unitOfWork.SeatRepository.GetWhere(a => showTimePost.Seats.Select(a => a.Id).ToList().Contains(a.Id));

            Reservation reservation = new Reservation
            {
                ShowtimeId = showTimePost.ShowTimeId,
                Showtime = showTime,
                Status = ReservationStatus.Pending,
                AvailableUntil = DateTime.Now.AddMinutes(10),
                AuditoriumId = showTime.AuditoriumId,
                Id = Guid.NewGuid()
                
            };

            await _unitOfWork.ReservationRepository.Add(reservation);
            foreach (var seat in seats)
            {
                await _unitOfWork.ReservationSeatsRepository.Add(new ReservationSeats { ReservationId = reservation.Id, SeatId = seat.Id });
            }
            await _unitOfWork.CommitAsync();
            return new ReserveSeatPostResponse
            {
                Movie = showTime.Movie,
                NumberOfSeats = showTimePost.Seats.Count(),
                ReservationId = reservation.Id,
                Seats = seats,
                Auditorium = auditorium
            };

        }

        public async Task<IEnumerable<Seat>> GetAvailableSeatsBySessionId(Guid showTimeId)
        {
            var session = await _unitOfWork.ShowtimesRepository.GetById(showTimeId);
            var auditorium = await _unitOfWork.AuditoriumsRepository.GetFirstWhere(a => a.Id == session.AuditoriumId, include: i => i.Include(a => a.Seats));
            var checkReservations = await _unitOfWork.ReservationRepository.GetWhere(a => (a.ShowtimeId == showTimeId && a.AvailableUntil > DateTime.Now &&
                    a.Status != DomainApplication.Enum.ReservationStatus.Pending) || (a.ShowtimeId == showTimeId &&
                    a.Status != DomainApplication.Enum.ReservationStatus.Completed), include: src => src.Include(b => b.Seats));
            var seatsNotAvailable = new List<Guid>(checkReservations.SelectMany(a => a.Seats).Select(a => a.SeatId).ToList());
            var seatsAvailable = auditorium.Seats.Where(a => !seatsNotAvailable.Contains(a.Id)).ToList();
            return seatsAvailable;
        }

        private bool AreSeatsContiguous(IEnumerable<SeatPostRequest> seats)
        {
            var sortedSeats = seats.OrderBy(seat => seat.SeatNumber).ToList();
            for (int i = 1; i < sortedSeats.Count; i++)
            {
                if (sortedSeats[i].SeatNumber != sortedSeats[i - 1].SeatNumber + 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
