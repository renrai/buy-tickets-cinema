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
    public class SeatRepository : RepositoryBase<Seat, SeatEntity>, ISeatRepository
    {
        private readonly CinemaContext _context;

        public SeatRepository(CinemaContext context) : base(context)
        {
            _context = context;
        }

    
    }
}
