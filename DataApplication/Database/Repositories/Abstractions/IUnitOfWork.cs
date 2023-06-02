using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication.Database.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        IAuditoriumsRepository AuditoriumsRepository { get; }
        IShowtimesRepository ShowtimesRepository { get; }
        ITicketsRepository TicketsRepository { get; }
        IMovieRepository MovieRepository { get; }
        IReservationRepository ReservationRepository { get; }
        ISeatRepository SeatRepository { get; }
        IReservationSeatsRepository ReservationSeatsRepository { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
