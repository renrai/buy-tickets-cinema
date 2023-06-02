using DataApplication.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using System.Linq.Expressions;
using DataApplication.Database.Repositories.Abstractions;
using DataApplication.Database;
using DomainApplication.Models;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataApplication.Database.Repositories
{
    public class ShowtimesRepository : RepositoryBase<Showtime, ShowtimeEntity>, IShowtimesRepository
    {
        private readonly CinemaContext _context;
        public ShowtimesRepository(CinemaContext context) : base(context) 
        {
            _context = context;

        }

        public async Task<Showtime> GetWithMoviesByIdAsync(Guid id, CancellationToken cancel)
        {
            var showTime = await _context.Showtimes
                .Include(x => x.Movie)
                .FirstOrDefaultAsync(x => x.Id == id, cancel);
            return _mapper.Map<Showtime>(showTime);

        }

        public async Task<Showtime> GetWithTicketsByIdAsync(Guid id, CancellationToken cancel)
        {
            var showTime = await _context.Showtimes
                .Include(x => x.Tickets)
                .FirstOrDefaultAsync(x => x.Id == id, cancel);
            return _mapper.Map<Showtime>(showTime);

        }

        public async Task<Showtime> GetByDateAndAuditorium(Guid auditoriumId, DateTime date, CancellationToken cancel)
        {
            var showTime = await _context.Showtimes
                .FirstOrDefaultAsync(x => x.AuditoriumId == auditoriumId && x.SessionDate.Date == date.Date, cancel);
            return _mapper.Map<Showtime>(showTime);

        }

        public async Task<IEnumerable<Showtime>> GetAllAsync(Expression<Func<ShowtimeEntity, bool>> filter, CancellationToken cancel)
        {
            if (filter == null)
            {
                var showTimes = await _context.Showtimes
                .Include(x => x.Movie)
                .ToListAsync(cancel);
                return _mapper.Map<List<Showtime>>(showTimes);
            }
            var showTimesFilter = await _context.Showtimes
                .Include(x => x.Movie)
                .Where(filter)
                .ToListAsync(cancel);
            return _mapper.Map<List<Showtime>>(showTimesFilter);

        }

        public async Task<Showtime> CreateShowtime(ShowtimeEntity showtimeEntity, CancellationToken cancel)
        {
            var showtime = await _context.Showtimes.AddAsync(showtimeEntity, cancel);
            await _context.SaveChangesAsync(cancel);
            return _mapper.Map<Showtime>(showtime);

        }
    }
}
