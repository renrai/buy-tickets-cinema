using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DomainApplication.IService;
using DomainApplication.Requests;
using ApiApplication.Filter;

namespace ApiApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogRequestTimeFilter))]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;

        }
        /// <summary>
        /// Creates a reservation for the specified seats.
        /// </summary>
        /// <param name="reservation">The reservation details.</param>
        /// <returns>
        /// The result of the reservation request.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> ReserveSeats(ReserveSeatPostRequest reservation)
        {
            var response = await _reservationService.CreateReservation(reservation);
            return Ok(response);
        }
        /// <summary>
        /// Gets the available seats for a given show time.
        /// </summary>
        /// <param name="showTimeId">The show time identifier.</param>
        /// <returns>A list of available seats.</returns>
        [HttpGet]
        [Route("get-available-seats/{showTimeId}")]
        public async Task<IActionResult> GetAvailableSeats(Guid showTimeId)
        {
            var seats = await _reservationService.GetAvailableSeatsBySessionId(showTimeId);
            return Ok(seats);
        }
    }
}
