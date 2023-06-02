using DataApplication.Database.Entities;
using DataApplication.Database.Repositories;
using DataApplication.Database.Repositories.Abstractions;
using DomainApplication.IService;
using DomainApplication.Models;
using DomainApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApplication.Services
{
    public class ShowTimeService : IShowTimeService
    {
        private static IUnitOfWork _unitOfWork;
        public ShowTimeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Showtime> CreateShowTime(ShowTimePostRequest showTimePost)
        {
            var showTimeMovie = await _unitOfWork.MovieRepository.GetFirstWhere(a => a.Id == showTimePost.MovieId);
            if (showTimeMovie == null)
                throw new Exception("Movie not found, create the movie first");


            var checkIfSessionDateIsAvailable = await _unitOfWork.ShowtimesRepository.GetByDateAndAuditorium(showTimePost.AuditoriumId, showTimePost.SessionDate, CancellationToken.None);

            if (checkIfSessionDateIsAvailable != null)
                throw new Exception("There's already a showtime for at the same date and auditorium");

            Showtime addShowtime = new Showtime
            {
                AuditoriumId = showTimePost.AuditoriumId,
                SessionDate = showTimePost.SessionDate.Date,
                Movie = showTimeMovie,
                Id = Guid.NewGuid()
            };
            await _unitOfWork.ShowtimesRepository.Add(addShowtime);
            await _unitOfWork.CommitAsync();
            return addShowtime; 
            
        }
        public async Task<List<Showtime>> GetAll()
        {
            var showTimes = await _unitOfWork.ShowtimesRepository.GetAllAsync(null, CancellationToken.None);
            if (showTimes.Any())
                return showTimes.ToList();

            return null;
        }

        public async Task<Showtime> GetById(Guid id)
        {
            return await _unitOfWork.ShowtimesRepository.GetById(id);
        }
    }
}
