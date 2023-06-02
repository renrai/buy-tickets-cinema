using DataApplication.Database.Entities;
using System.Threading.Tasks;
using System.Threading;
using DataApplication.Database.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using DomainApplication.Models;

namespace DataApplication.Database.Repositories
{
    public class AuditoriumsRepository : RepositoryBase<Auditorium, AuditoriumEntity>, IAuditoriumsRepository
    {
        private readonly CinemaContext _context;

        public AuditoriumsRepository(CinemaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AuditoriumEntity> GetAsync(Guid auditoriumId, CancellationToken cancel)
        {
            return await _context.Auditoriums
                .Include(x => x.Seats)
                .FirstOrDefaultAsync(x => x.Id == auditoriumId, cancel);
        }
    }
}
