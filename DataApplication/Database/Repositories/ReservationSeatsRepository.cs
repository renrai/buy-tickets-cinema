using DataApplication.Database.Entities;
using DataApplication.Database.Repositories.Abstractions;
using DomainApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication.Database.Repositories
{
    public class ReservationSeatsRepository : RepositoryBase<ReservationSeats, ReservationSeatsEntity>, IReservationSeatsRepository
    {
        private readonly CinemaContext _context;
        public ReservationSeatsRepository(CinemaContext context) : base(context)
        {
            _context = context;

        }
    }
}
