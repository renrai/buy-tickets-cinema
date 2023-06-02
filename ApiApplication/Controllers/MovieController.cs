using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DomainApplication.IService;
using DomainApplication.Models;
using System.Net;
using ApiApplication.Filter;

namespace ApiApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogRequestTimeFilter))]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _serviceMovie;
        public MovieController(IMovieService serviceMovie)
        {
            _serviceMovie = serviceMovie;

        }
        /// <summary>
        /// Gets all movies from the database.
        /// </summary>
        /// <returns>A list of movies.</returns>
        /// <response code="200">All movies list</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _serviceMovie.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Creates a movie with the given IMDB ID.
        /// </summary>
        /// <param name="imdbId">The IMDB ID of the movie.</param>
        /// <returns>The result of the movie creation.</returns>
        /// <response code="200">Movie object</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        public async Task<IActionResult> CreateMovie(string imdbId)
        {
            var result = await _serviceMovie.CreateMovie(imdbId);
            return Ok(result);
        }
    }
}
