using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using DomainApplication.IService;
using System.Net.Mime;
using System.Net;
using DomainApplication.Models;
using ApiApplication.Filter;

namespace ApiApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogRequestTimeFilter))]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;

        }
        /// <summary>
        /// Confirms a reservation with the given reservationId.
        /// </summary>
        /// <param name="reservationId">The Id of the reservation to be confirmed.</param>
        /// <returns>
        /// An Ok response with the response from the ticket service.
        /// </returns>
        /// <response code="200">Ticket Object</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [Route("confirm-reservation/{reservationId}")]

        public async Task<IActionResult> ConfirmReservation(Guid reservationId)
        {
            var response = await _ticketService.ConfirmReservation(reservationId);
            return Ok(response);
        }

        /// <summary>
        /// Gets a ticket by its Id.
        /// </summary>
        /// <param name="ticketId">The Id of the ticket.</param>
        /// <returns>The ticket with the specified Id.</returns>
        /// <response code="200">Ticket created</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [Route("get-by-id/{ticketId}")]

        public async Task<IActionResult> GetById(Guid ticketId)
        {
            var response = await _ticketService.GetTicket(ticketId);
            return Ok(response);
        }
    }
}
