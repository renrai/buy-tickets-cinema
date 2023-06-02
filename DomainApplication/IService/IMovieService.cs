using DomainApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.IService
{
    public interface IMovieService
    {
        Task<Movie> CreateMovie(string imdbId);
        Task<IEnumerable<Movie>> GetAll();

    }
}
