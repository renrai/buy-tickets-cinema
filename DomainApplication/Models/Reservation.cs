using DomainApplication.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainApplication.Models
{
    public class Reservation : Base
    {
        public Guid ShowtimeId { get; set; }
        public Guid AuditoriumId { get; set; }
        public Showtime Showtime { get; set; }
        public ICollection<ReservationSeats> Seats { get; set; }
        public ReservationStatus Status { get; set; }
        public DateTime AvailableUntil { get; set; }
    }
}
