using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication.Database.Entities
{
    public class ReservationSeatsEntity: BaseEntity
    {

        public Guid ReservationId { get; set; }
        public ReservationEntity Reservation { get; set; }
        public Guid SeatId { get; set; }
        public SeatEntity Seat { get; set; }
    }
}
