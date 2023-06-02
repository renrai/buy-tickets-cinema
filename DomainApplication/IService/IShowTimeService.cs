using DomainApplication.Models;
using DomainApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.IService
{
    public interface IShowTimeService
    {
        Task<List<Showtime>> GetAll();
        Task<Showtime> GetById(Guid id);

        Task<Showtime> CreateShowTime(ShowTimePostRequest showTimePost);
    }
}
