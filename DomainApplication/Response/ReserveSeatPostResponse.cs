using DomainApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.Response
{
    public class ReserveSeatPostResponse
    {
        public Guid ReservationId { get; set; }
        public int NumberOfSeats { get; set; }
        public IEnumerable<Seat>? Seats { get; set; }
        public Auditorium? Auditorium { get; set; }
        public Movie? Movie { get; set; }
    }
}
