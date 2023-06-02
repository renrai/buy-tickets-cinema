using DataApplication.Database.Entities;
using DomainApplication.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DataApplication.Database.Repositories.Abstractions
{
    public interface IAuditoriumsRepository : IRepositoryBase<Auditorium>
    {
        Task<AuditoriumEntity> GetAsync(Guid auditoriumId, CancellationToken cancel);
    }
}