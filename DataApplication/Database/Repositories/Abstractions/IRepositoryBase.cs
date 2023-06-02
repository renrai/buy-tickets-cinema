using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication.Database.Repositories.Abstractions
{
    public interface IRepositoryBase<MODEL> where MODEL : class
    {
        Task Add(MODEL model);
        void Update(MODEL model);
        void Remove(MODEL model);
        Task<MODEL> GetById(Guid id);
        Task<IEnumerable<MODEL>> GetWhere(Expression<Func<MODEL, bool>> filter, Expression<Func<IQueryable<MODEL>, IIncludableQueryable<MODEL, object>>> include = null);
        Task<MODEL> GetFirstWhere(Expression<Func<MODEL, bool>> filter, Expression<Func<IQueryable<MODEL>, IIncludableQueryable<MODEL, object>>> include = null);
        Task<IEnumerable<MODEL>> GetAll();

    }
}
