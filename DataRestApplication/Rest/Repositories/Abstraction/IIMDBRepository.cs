using DataRestApplication.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRestApplication.Repositories.Abstraction
{
    public interface IIMDBRepository
    {
         Task<IMDBMovieDTO> GetMoviesDetails(string movieId);
    }
}
