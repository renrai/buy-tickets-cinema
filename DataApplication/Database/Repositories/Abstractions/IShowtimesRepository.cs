using DataApplication.Database.Entities;
using DomainApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DataApplication.Database.Repositories.Abstractions
{
    public interface IShowtimesRepository : IRepositoryBase<Showtime>
    {
        Task<Showtime> CreateShowtime(ShowtimeEntity showtimeEntity, CancellationToken cancel);
        Task<IEnumerable<Showtime>> GetAllAsync(Expression<Func<ShowtimeEntity, bool>> filter, CancellationToken cancel);
        Task<Showtime> GetWithMoviesByIdAsync(Guid id, CancellationToken cancel);
        Task<Showtime> GetWithTicketsByIdAsync(Guid id, CancellationToken cancel);
        Task<Showtime> GetByDateAndAuditorium(Guid auditoriumId, DateTime date, CancellationToken cancel);

    }
}