using DataApplication.Database.Repositories;
using DataApplication.Database.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CinemaContext _context;
        private ITicketsRepository _ticketsRepository;
        private IShowtimesRepository _showtimesRepository;
        private IAuditoriumsRepository _auditoriumsRepository;
        private IMovieRepository _movieRepository;
        private IReservationRepository _reservationRepository;
        private ISeatRepository _seatRepository;
        private IReservationSeatsRepository _reservationSeatsRepository;

        public UnitOfWork(CinemaContext context)
        {
            _context = context;
        }
        public ITicketsRepository TicketsRepository => _ticketsRepository ?? (_ticketsRepository = new TicketsRepository(_context));
        public IShowtimesRepository ShowtimesRepository => _showtimesRepository ?? (_showtimesRepository = new ShowtimesRepository(_context));
        public IAuditoriumsRepository AuditoriumsRepository => _auditoriumsRepository ?? (_auditoriumsRepository = new AuditoriumsRepository(_context));
        public IMovieRepository MovieRepository => _movieRepository ?? (_movieRepository = new MovieRepository(_context));
        public IReservationRepository ReservationRepository => _reservationRepository ?? (_reservationRepository = new ReservationRepository(_context));
        public ISeatRepository SeatRepository => _seatRepository ?? (_seatRepository = new SeatRepository(_context));
        public IReservationSeatsRepository ReservationSeatsRepository => _reservationSeatsRepository ?? (_reservationSeatsRepository = new ReservationSeatsRepository(_context));

        public int Commit()
        {
            var n = _context.SaveChanges();
            DetachAllEntities();

            return n;
        }

        public async Task<int> CommitAsync()
        {
            var n = await _context.SaveChangesAsync();
            DetachAllEntities();

            return n;
        }

        private void DetachAllEntities()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
