using DataApplication.Database.Entities;
using DataApplication.Database.Repositories.Abstractions;
using DomainApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication.Database.Repositories
{
    public class ReservationRepository : RepositoryBase<Reservation, ReservationEntity>, IReservationRepository
    {
        private readonly CinemaContext _context;
        public ReservationRepository(CinemaContext context) : base(context)
        {
            _context = context;

        }

    }
}
