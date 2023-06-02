using DataApplication.Database.Entities;
using DomainApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication.Database.Repositories.Abstractions
{
    public interface IMovieRepository : IRepositoryBase<Movie>
    { 
    }
}
