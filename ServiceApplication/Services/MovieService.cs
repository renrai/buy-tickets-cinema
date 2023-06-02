using AutoMapper;
using DataApplication.Database.Repositories.Abstractions;
using DataRestApplication.Repositories;
using DomainApplication.IService;
using DomainApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRestApplication.Repositories.Abstraction;
using DataRestApplication.DTO;
using StackExchange.Redis;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Google.Protobuf.WellKnownTypes;

namespace ServiceApplication.Services
{
    public class MovieService : IMovieService
    {
        private static IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IIMDBRepository _imdbRepository;
        private readonly IOptions<ConfigOption> _options;


        public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IIMDBRepository imdbRepository, IOptions<ConfigOption> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imdbRepository = imdbRepository;
            _options = options;
        }

        public async Task<Movie> CreateMovie(string imdbId)
        {
            try
            {
                var movieExistDb = await _unitOfWork.MovieRepository.GetWhere(a => a.ImdbId == imdbId);
                if (movieExistDb != null && movieExistDb.Count() > 0)
                    throw new Exception("Movie already exists");

                 var redis = ConnectionMultiplexer.Connect(_options.Value.CacheHost);
                 var cache = redis.GetDatabase();
                IMDBMovieDTO imdbMovie = new IMDBMovieDTO();
                var imdbInfo = await _imdbRepository.GetMoviesDetails(imdbId);
                if (imdbInfo == null)
                {
                    var cachedResponse = cache.StringGet(imdbId);
                    if (!string.IsNullOrEmpty(cachedResponse))
                    {
                        imdbInfo = JsonConvert.DeserializeObject<IMDBMovieDTO>(cachedResponse);
                    }
                    else
                    {
                        throw new Exception("Error getting movie data");
                    }

                }
                else
                {
                    imdbMovie = imdbInfo;
                    var serializedResponse = JsonConvert.SerializeObject(imdbMovie);
                    cache.StringSet(imdbId, serializedResponse);

                }
                var newMovie = _mapper.Map<Movie>(imdbMovie);
                newMovie.Id = Guid.NewGuid();
                await _unitOfWork.MovieRepository.Add(newMovie);
                await _unitOfWork.CommitAsync();
                return newMovie;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<Movie>> GetAll()
        {
            try
            {
                return await _unitOfWork.MovieRepository.GetAll();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
