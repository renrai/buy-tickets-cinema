using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.Models
{
    public class ReservationSeats : Base
    {
        public Guid ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public Guid SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}
