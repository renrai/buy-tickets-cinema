using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using DomainApplication.IService;
using DomainApplication.Models;
using DomainApplication.Requests;
using System.Net.Mime;
using System.Net;
using ApiApplication.Filter;

namespace ApiApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogRequestTimeFilter))]
    public class ShowTimeController : ControllerBase
    {
        private readonly IShowTimeService _serviceShowTime;
        public ShowTimeController(IShowTimeService showTimeService)
        {
            _serviceShowTime = showTimeService;

        }
        /// <summary>
        /// Creates a new showtime.
        /// </summary>
        /// <param name="showTimePostRequest">The showtime post request.</param>
        /// <returns>The response of the showtime creation.</returns>
         /// <response code="200">boolean</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        public async Task<IActionResult> CreateShowTime(ShowTimePostRequest showTimePostRequest)
        {

            var response = await _serviceShowTime.CreateShowTime(showTimePostRequest);
            return Ok(response);
        }
        /// <summary>
        /// Gets all show times from the database.
        /// </summary>
        /// <returns>A list of show times.</returns>
        /// <response code="200">Showtime list</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var showTimes = await _serviceShowTime.GetAll();
            return Ok(showTimes);
        }
        /// <summary>
        /// Gets show time by id from database
        /// </summary>
        /// <returns>A complete show time.</returns>
        /// <response code="200">Showtime object</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [Route("get-by-id/id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var showTimes = await _serviceShowTime.GetById(id);
            return Ok(showTimes);
        }
    }
}
