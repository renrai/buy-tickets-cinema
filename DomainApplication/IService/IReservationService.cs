using DomainApplication.Models;
using DomainApplication.Requests;
using DomainApplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.IService
{
    public interface IReservationService
    {
        Task<ReserveSeatPostResponse> CreateReservation(ReserveSeatPostRequest showTimePost);
        Task<IEnumerable<Seat>> GetAvailableSeatsBySessionId(Guid showTimeId);
    }
}
